using Empleados.Domain.Entities;
using Empleados.Domain.Interfaces;
using Empleados.Infrastructure.DataBase;
using System.Collections.Generic;

namespace Empleados.Infrastructure.Repositories
{
    public class EmpleadosRepository : IEmpleadosRepository
    {
        private readonly SqlServerContext _context;

        public EmpleadosRepository(SqlServerContext context)
        {
            _context = context;
        }

        public List<EmpleadosCargo> GetList()
        {
            var query = (from e in _context.Set<EmpleadosCubits>()
                        join c in _context.Set<CargosCubits>()
                        on e.IdCargo equals c.Id
                        select new EmpleadosCargo
                        {
                            Apellido_nombre = e.Apellido_Nombre,
                            Correo = e.Correo,
                            Nombre_cargo = c.Nombre_Cargo
                        }).ToList();

            return query;

            //var empleadosList =
            //    _context
            //    .Set<EmpleadosCubits>()
            //    .ToList(); // 1 forma vieja

            //return empleadosList;
            //return new List<EmpleadosCargo>
            //{
            //    new EmpleadosCargo{ Id = 1,Apellido_nombre = "Contreras Iván",correo = "ivan.contreras@cablasociados.com",idcargo = 1},

            //    new EmpleadosCargo{ Id = 2,Apellido_nombre = "Mengano Pela",correo = "mp@cablasociados.com",idcargo = 2}
            //};
        }
    }
}
