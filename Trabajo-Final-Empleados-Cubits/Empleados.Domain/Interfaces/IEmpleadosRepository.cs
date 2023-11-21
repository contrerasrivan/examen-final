using Empleados.Domain.Entities;

namespace Empleados.Domain.Interfaces
{
    public interface IEmpleadosRepository
    {
        List<EmpleadosCargo> GetList();
    }
}
