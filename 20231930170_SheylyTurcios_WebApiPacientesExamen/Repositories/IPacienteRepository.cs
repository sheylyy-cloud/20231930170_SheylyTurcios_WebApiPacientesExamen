using _20231930170_SheylyTurcios_WebApiPacientesExamen.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _20231930170_SheylyTurcios_WebApiPacientesExamen.Repositories
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> ObtenerTodos();
        Task<Paciente> ObtenerPorId(int id);
        Task Agregar(Paciente paciente);
        Task Actualizar(Paciente paciente);
        Task Eliminar(int id);
    }
}