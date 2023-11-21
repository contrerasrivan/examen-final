using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Empleados.Application
{
    public static class Installer
    {
        public static void InstallMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            
        }
    }
}
