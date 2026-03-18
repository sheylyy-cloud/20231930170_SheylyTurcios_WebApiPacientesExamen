namespace _20231930170_SheylyTurcios_WebApiPacientesExamen.Models
{
    public class Paciente
    {
        public int Id { get; set; } // Clave primaria
        public string NombreCompleto { get; set; } // Nombre del paciente
        public string NumeroIdentidad { get; set; } // 13 dígitos sin guiones
        public DateTime FechaNacimiento { get; set; } // Fecha de nacimiento
        public string Telefono { get; set; } // Al menos 8 dígitos
        public bool Activo { get; set; } = true; // Para inactivar pacientes
    }
}