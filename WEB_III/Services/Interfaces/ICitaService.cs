using WEB_III.Models;
using WEB_III.Models.Enums;

namespace WEB_III.Services.Interfaces
{
    /// <summary>
    /// Contrato de lógica de negocio para Citas.
    /// </summary>
    public interface ICitaService
    {
        IEnumerable<Cita> ObtenerTodos();
        Cita? ObtenerPorId(int id);
        void Crear(Cita cita);
        void Actualizar(Cita cita);
        void Eliminar(int id);
        IEnumerable<Cita> ObtenerPorMascota(int mascotaId);
        IEnumerable<Cita> ObtenerPorVeterinario(int veterinarioId);
        IEnumerable<Cita> ObtenerPorEstado(EstadoCita estado);
        IEnumerable<Cita> ObtenerPorRangoFecha(DateTime desde, DateTime hasta);

        /// <summary>
        /// Resuelve las referencias de navegación (Mascota y Veterinario) en una lista de citas.
        /// </summary>
        IEnumerable<Cita> ObtenerTodosConDetalles();

        /// <summary>
        /// Resuelve las referencias de navegación para una sola cita.
        /// </summary>
        Cita? ObtenerPorIdConDetalles(int id);
    }
}
