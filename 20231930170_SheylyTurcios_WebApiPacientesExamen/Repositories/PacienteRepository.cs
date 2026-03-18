using _20231930170_SheylyTurcios_WebApiPacientesExamen.Data;
using _20231930170_SheylyTurcios_WebApiPacientesExamen.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20231930170_SheylyTurcios_WebApiPacientesExamen.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ClinicaDbContext _context;

        public PacienteRepository(ClinicaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> ObtenerTodos()
        {
            return await _context.Pacientes.Where(p => p.Activo).ToListAsync();
        }

        public async Task<Paciente> ObtenerPorId(int id)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(p => p.Id == id && p.Activo);
        }

        public async Task Agregar(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var paciente = await ObtenerPorId(id);
            if (paciente != null)
            {
                paciente.Activo = false; // Inactivar paciente en lugar de eliminar
                await _context.SaveChangesAsync();
            }
        }
    }
}