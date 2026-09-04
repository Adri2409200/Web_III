using WEB_III.Models;
using WEB_III.Models.Enums;

namespace WEB_III.Repositories.Interfaces
{
    /// <summary>
    /// Repositorio específico para Cita con consultas adicionales.
    /// </summary>
    public interface ICitaRepository : IRepository<Cita>
    {
        /// <summary>Obtiene todas las citas de una mascota.</summary>
        IEnumerable<Cita> ObtenerPorMascota(int mascotaId);

        /// <summary>Obtiene todas las citas asignadas a un veterinario.</summary>
        IEnumerable<Cita> ObtenerPorVeterinario(int veterinarioId);

        /// <summary>Obtiene citas filtradas por estado.</summary>
        IEnumerable<Cita> ObtenerPorEstado(EstadoCita estado);

        /// <summary>Obtiene citas dentro de un rango de fechas.</summary>
        IEnumerable<Cita> ObtenerPorRangoFecha(DateTime desde, DateTime hasta);
    }
}
