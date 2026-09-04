using WEB_III.Models;

namespace WEB_III.Repositories.Interfaces
{
    /// <summary>
    /// Repositorio específico para Veterinario con consultas adicionales.
    /// </summary>
    public interface IVeterinarioRepository : IRepository<Veterinario>
    {
        /// <summary>Obtiene solo los veterinarios con estado Activo.</summary>
        IEnumerable<Veterinario> ObtenerActivos();

        /// <summary>Busca veterinarios por especialidad.</summary>
        IEnumerable<Veterinario> ObtenerPorEspecialidad(string especialidad);
    }
}
