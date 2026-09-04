using System.ComponentModel.DataAnnotations;
using WEB_III.Models.Enums;

namespace WEB_III.Models
{
    /// <summary>
    /// Representa al dueño de una o más mascotas registradas en la veterinaria.
    /// </summary>
    public class Propietario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Formato de teléfono inválido.")]
        [StringLength(15, ErrorMessage = "Máximo 15 caracteres.")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido.")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Correo { get; set; } = string.Empty;

        public EstadoPersona Estado { get; set; } = EstadoPersona.Activo;

        // Propiedad calculada para mostrar nombre completo
        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}
