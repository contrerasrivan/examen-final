using AutoMapper;
using Empleados.Application.Models;
using Empleados.Domain.Entities;

namespace Empleados.Application.Profiles
{
    public class EmpleadosProfile : Profile
    {
        public EmpleadosProfile()
        {
            CreateMap<EmpleadosCargo, EmpleadosDto>();
        }
    }
}
