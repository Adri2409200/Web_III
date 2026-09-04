using System.ComponentModel.DataAnnotations;
using WEB_III.Models.Enums;

namespace WEB_III.Models
{
    /// <summary>
    /// Representa una mascota registrada en la veterinaria.
    /// </summary>
    public class Mascota
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un propietario.")]
        public int PropietarioId { get; set; }

        // Referencia de navegación (se resuelve en memoria)
        public Propietario? Propietario { get; set; }

        [Required(ErrorMessage = "La especie es obligatoria.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Especie { get; set; } = string.Empty;

        [Required(ErrorMessage = "La raza es obligatoria.")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Raza { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        public DateOnly FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El color es obligatorio.")]
        [StringLength(30, ErrorMessage = "Máximo 30 caracteres.")]
        public string Color { get; set; } = string.Empty;

        public EstadoMascota Estado { get; set; } = EstadoMascota.Activo;
    }
}
