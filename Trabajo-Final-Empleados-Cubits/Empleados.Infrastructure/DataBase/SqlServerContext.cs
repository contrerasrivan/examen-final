using Empleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Empleados.Infrastructure.DataBase
{
    public class SqlServerContext : DbContext // configuro mi context para usar mis opciones
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) // Inyecto la config del contexto
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // data base first
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<EmpleadosCargo>()
            //    .ToTable("empleados")
            //    .HasKey(e => e.Id);
        }
    }
}
