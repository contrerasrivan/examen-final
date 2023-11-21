using Empleados.Domain.Interfaces;
using Empleados.Infrastructure.DataBase;
using Empleados.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Empleados.Infrastructure
{
    public static class Installer
    {
        public static void AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SqlServerContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IEmpleadosRepository, EmpleadosRepository>();

        }
    }
}
