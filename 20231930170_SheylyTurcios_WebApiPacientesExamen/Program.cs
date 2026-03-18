using Microsoft.EntityFrameworkCore;
using _20231930170_SheylyTurcios_WebApiPacientesExamen.Data;
using _20231930170_SheylyTurcios_WebApiPacientesExamen.Repositories;
using _20231930170_SheylyTurcios_WebApiPacientesExamen.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ClinicaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Estas lineas conectan tus archivos con la API
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<PacienteService>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();