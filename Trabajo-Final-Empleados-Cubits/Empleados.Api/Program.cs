using Empleados.Application;
using Empleados.Domain.Interfaces;
using Empleados.Infrastructure;
using Empleados.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Conexion");

//builder.Services.AddTransient<IEmpleadosRepository, EmpleadosRepository>(); //cada ves que necesite la dependencia la vuelvo a generar

//builder.Services.AddScoped<IEmpleadosRepository, EmpleadosRepository>(); //por cada request me genera la dependencia

//builder.Services.AddSingleton<IEmpleadosRepository, EmpleadosRepository>(); //levanta y carga las aplicaciones por mucho tiempo
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InstallMapper();

builder.Services.AddCors(options =>
    options.AddPolicy("Default",
    policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    }));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.UseCors("Default");

app.MapControllers();

app.Run();
