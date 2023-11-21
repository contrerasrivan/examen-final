using Empleados.Application.Contrats;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Application.Validators
{
    public class GetEmpleadosListValidator : AbstractValidator<GetEmpleadosListRequest>
    {
        public GetEmpleadosListValidator()
        {
            //RuleFor(e => e.Query)
            //    .NotEmpty()
            //    .NotNull()
            //    .WithMessage("Query erronea");
        }
    }
}
