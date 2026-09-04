using System.ComponentModel.DataAnnotations;
using WEB_III.Models.Enums;

namespace WEB_III.Models
{
    /// <summary>
    /// Representa una cita médica agendada en la veterinaria.
    /// </summary>
    public class Cita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una mascota.")]
        public int MascotaId { get; set; }

        // Referencia de navegación (se resuelve en memoria)
        public Mascota? Mascota { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un veterinario.")]
        public int VeterinarioId { get; set; }

        // Referencia de navegación (se resuelve en memoria)
        public Veterinario? Veterinario { get; set; }

        [Required(ErrorMessage = "La fecha y hora de atención son obligatorias.")]
        [DataType(DataType.DateTime)]
        public DateTime FechaHoraAtencion { get; set; }

        [Required(ErrorMessage = "El motivo es obligatorio.")]
        [StringLength(300, ErrorMessage = "Máximo 300 caracteres.")]
        public string Motivo { get; set; } = string.Empty;

        public EstadoCita Estado { get; set; } = EstadoCita.Pendiente;

        [StringLength(1000, ErrorMessage = "Máximo 1000 caracteres.")]
        public string? Diagnostico { get; set; }
    }
}
