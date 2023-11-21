using AutoMapper;
using Empleados.Application.Contrats;
using Empleados.Application.Models;
using Empleados.Domain.Entities;
using Empleados.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Empleados.Application.Handlers
{
    public class EmpleadosListHandler : IRequestHandler<GetEmpleadosListRequest, GetEmpleadosListResponse>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<GetEmpleadosListRequest> _validator;
        private readonly IEmpleadosRepository _empeladosRepository;

        public EmpleadosListHandler(IEmpleadosRepository empeladosRepository, IMapper mapper, IValidator<GetEmpleadosListRequest> validator)
        {
            _empeladosRepository = empeladosRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GetEmpleadosListResponse> Handle(
            GetEmpleadosListRequest request, CancellationToken cancellationToken)
        {
            var response = new GetEmpleadosListResponse();

           // var result = _validator.Validate(request);


            //if (string.IsNullOrEmpty(request.Query))  // Validacion valida
            //{

            //}
            // Lógica
            //if (request.From.HasValue)
            //{

            //}

            //if (request.To.HasValue)
            //{

            //}

            var empleadosList = _empeladosRepository.GetList();

            //if (empleadosList.Any())
            //{

            //}

            //if (empleadosList.Count>2)
            //{

            //}
            //var empleadosDtoList = new List<EmpleadosDto>();

            //foreach (var empleados in empleadosList) //1er forma de pasar los datos de Dto
            //{
            //    empleadosDtoList.Add(new EmpleadosDto
            //    {
            //        Apellido_nombre = empleados.Apellido_nombre,
            //        Correo = empleados.correo,
            //    });
            //}

            //response.EmpleadosList = empleadosDtoList;

            response.EmpleadosList = empleadosList.Select(Mapto).ToList();

            return response;
        }

        private EmpleadosDto Mapto(EmpleadosCargo empleados)
        {
            //Con Automapper
            return _mapper.Map<EmpleadosDto>(empleados);

            //Sin AutoMapper
            //return new EmpleadosDto
            //{
            //    Apellido_nombre = empleados.Apellido_nombre,
            //    Correo = empleados.correo,
            //};
        }
    }
}
