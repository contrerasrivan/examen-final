
using Empleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empleados.Infrastructure.Configuration
{
    public class EmpleadosConfiguration : IEntityTypeConfiguration<EmpleadosCubits>
    {
        public void Configure(EntityTypeBuilder<EmpleadosCubits> builder) // Code First
        {
            builder.ToTable("empleados");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Apellido_Nombre).HasColumnName("apellido_nombre");
            builder.Property(e => e.Correo).HasColumnName("correo");
        }
    }
}
