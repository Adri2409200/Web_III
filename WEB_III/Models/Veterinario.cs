using System.ComponentModel.DataAnnotations;
using WEB_III.Models.Enums;

namespace WEB_III.Models
{
    /// <summary>
    /// Representa un médico veterinario que atiende citas en la clínica.
    /// </summary>
    public class Veterinario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "La especialidad es obligatoria.")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Especialidad { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Formato de teléfono inválido.")]
        [StringLength(15, ErrorMessage = "Máximo 15 caracteres.")]
        public string Telefono { get; set; } = string.Empty;

        public EstadoPersona Estado { get; set; } = EstadoPersona.Activo;

        // Propiedad calculada para mostrar nombre completo
        public string NombreCompleto => $"Dr. {Nombre} {Apellido}";
    }
}
