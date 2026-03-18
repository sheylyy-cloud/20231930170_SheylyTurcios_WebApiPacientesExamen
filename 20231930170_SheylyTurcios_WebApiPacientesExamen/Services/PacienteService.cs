using _20231930170_SheylyTurcios_WebApiPacientesExamen.Models;
using _20231930170_SheylyTurcios_WebApiPacientesExamen.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _20231930170_SheylyTurcios_WebApiPacientesExamen.Services
{
    public class PacienteService
    {
        private readonly IPacienteRepository _repository;

        public PacienteService(IPacienteRepository repository)
        {
            _repository = repository;
        }

        // Agregar paciente con validaciones
        public async Task AgregarPaciente(Paciente paciente)
        {
            if (string.IsNullOrWhiteSpace(paciente.NombreCompleto))
                throw new Exception("El nombre completo no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(paciente.NumeroIdentidad) || paciente.NumeroIdentidad.Length != 13)
                throw new Exception("La identidad debe tener 13 dígitos.");

            if (string.IsNullOrWhiteSpace(paciente.Telefono) || paciente.Telefono.Length < 8)
                throw new Exception("El teléfono debe tener al menos 8 dígitos.");

            if (paciente.FechaNacimiento > DateTime.Now)
                throw new Exception("La fecha de nacimiento no puede ser mayor a la fecha actual.");

            await _repository.Agregar(paciente);
        }

        // Métodos para listar, obtener, actualizar y eliminar
        public async Task<List<Paciente>> ObtenerTodos()
        {
            return await _repository.ObtenerTodos();
        }

        public async Task<Paciente> ObtenerPorId(int id)
        {
            return await _repository.ObtenerPorId(id);
        }

        public async Task ActualizarPaciente(Paciente paciente)
        {
            await _repository.Actualizar(paciente);
        }

        public async Task EliminarPaciente(int id)
        {
            await _repository.Eliminar(id);
        }
    }
}