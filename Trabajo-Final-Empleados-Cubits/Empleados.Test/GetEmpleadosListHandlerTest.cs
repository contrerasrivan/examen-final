using AutoMapper;
using Empleados.Application.Contrats;
using Empleados.Application.Handlers;
using Empleados.Application.Models;
using Empleados.Domain.Entities;
using Empleados.Domain.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using System.ComponentModel.DataAnnotations;
using Xunit;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Empleados.Test
{
    public class GetEmpleadosListHandlerTest
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IEmpleadosRepository> _empeladosRepository;
        private readonly Mock<IValidator<GetEmpleadosListRequest>> _validator;
        

        private EmpleadosListHandler handler;
        public GetEmpleadosListHandlerTest(List<EmpleadosCubits> empleadosList1, List<EmpleadosCubits> empleados)
        {
            var resultado = new ValidationResult(); // obligo a que mi lista sea vacia 
            var pruebalist = new List<EmpleadosCargo>
            {
                new EmpleadosCargo
                {
                    Apellido_nombre = "xxx",
                },

                new EmpleadosCargo
                {
                    Apellido_nombre = "x",
                },
            };
            var empleadosDto = new EmpleadosDto
            {
                Apellido_nombre = "xxx",
                Correo = "xx@gmail.com",
                Nombre_cargo = "Dev",

            }; // gardo el dato verdadero para validar en mi test


            _validator = new Mock<IValidator<GetEmpleadosListRequest>>();
            _validator
                .Setup(validator => validator.Validate(It.IsAny<GetEmpleadosListRequest>()))
                .Returns(resultado);


            _mapper = new Mock<IMapper>();
            _mapper
                .Setup(m => m.Map<EmpleadosDto>(It.IsAny<EmpleadosCubits>())) // configuro el maper
                .Returns(empleadosDto);

            _empeladosRepository = new Mock<IEmpleadosRepository>();
            _empeladosRepository
                .Setup(repository => repository.GetList())
                .Returns(pruebalist);

            handler = new EmpleadosListHandler(_empeladosRepository.Object, _mapper.Object, _validator.Object);
        }
        [Fact]
        public async void ValidoRequestValido_RetornoReponseValido()
        {
            //arrange

            //act
            var response = await handler.Handle(new GetEmpleadosListRequest(),CancellationToken.None);

            //assert
            Assert.NotNull(response);
            Assert.NotNull(response.EmpleadosList);
        }
    }
}