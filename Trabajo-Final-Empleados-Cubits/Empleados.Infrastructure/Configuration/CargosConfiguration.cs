using Empleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Infrastructure.Configuration
{
    public class CargosConfiguration : IEntityTypeConfiguration<CargosCubits>
    {
        public void Configure(EntityTypeBuilder<CargosCubits> builder)
        {
            builder.ToTable("cargos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nombre_Cargo).HasColumnName("nombre_cargo");
        }
    }
}
