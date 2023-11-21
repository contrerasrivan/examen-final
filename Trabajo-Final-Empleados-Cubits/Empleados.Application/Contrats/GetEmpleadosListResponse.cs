using Empleados.Application.Models;
using Empleados.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Application.Contrats
{
    public class GetEmpleadosListResponse 
    {
        public List<EmpleadosDto>? EmpleadosList { get; set; }
    }
}
