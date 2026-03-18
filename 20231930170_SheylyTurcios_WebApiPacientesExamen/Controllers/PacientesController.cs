using _20231930170_SheylyTurcios_WebApiPacientesExamen.Models;
using _20231930170_SheylyTurcios_WebApiPacientesExamen.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace _20231930170_SheylyTurcios_WebApiPacientesExamen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly PacienteService _service;

        public PacientesController(PacienteService service)
        {
            _service = service;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var pacientes = await _service.ObtenerTodos();
            return Ok(pacientes);
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var paciente = await _service.ObtenerPorId(id);
            if (paciente == null) return NotFound();
            return Ok(paciente);
        }

        // POST: api/Pacientes
        [HttpPost]
        public async Task<IActionResult> Agregar(Paciente paciente)
        {
            try
            {
                await _service.AgregarPaciente(paciente);
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Pacientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Paciente paciente)
        {
            if (id != paciente.Id) return BadRequest("El Id no coincide.");
            await _service.ActualizarPaciente(paciente);
            return Ok(paciente);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _service.EliminarPaciente(id);
            return Ok();
        }
    }
}