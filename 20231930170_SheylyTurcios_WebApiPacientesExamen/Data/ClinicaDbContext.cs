using Microsoft.EntityFrameworkCore;
using _20231930170_SheylyTurcios_WebApiPacientesExamen.Models;

namespace _20231930170_SheylyTurcios_WebApiPacientesExamen.Data
{
    public class ClinicaDbContext : DbContext
    {
        public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options)
            : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
    }
}