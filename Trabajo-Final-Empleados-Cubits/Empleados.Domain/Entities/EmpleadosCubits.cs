
namespace Empleados.Domain.Entities
{
    public class EmpleadosCubits
    {
        public int Id { get; set; }
        public string? Apellido_Nombre { get; set; }
        public string? Correo { get; set; }
        public int IdCargo { get; set; }
    }
}
