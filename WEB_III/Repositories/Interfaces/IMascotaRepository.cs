using WEB_III.Models;

namespace WEB_III.Repositories.Interfaces
{
    /// <summary>
    /// Repositorio específico para Mascota con consultas adicionales.
    /// </summary>
    public interface IMascotaRepository : IRepository<Mascota>
    {
        /// <summary>Obtiene todas las mascotas de un propietario.</summary>
        IEnumerable<Mascota> ObtenerPorPropietario(int propietarioId);

        /// <summary>Obtiene solo las mascotas con estado Activo.</summary>
        IEnumerable<Mascota> ObtenerActivas();
    }
}
