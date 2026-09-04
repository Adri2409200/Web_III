using WEB_III.Models;

namespace WEB_III.Repositories.Interfaces
{
    /// <summary>
    /// Repositorio específico para Propietario con consultas adicionales.
    /// </summary>
    public interface IPropietarioRepository : IRepository<Propietario>
    {
        /// <summary>Busca propietarios por nombre o apellido (búsqueda parcial).</summary>
        IEnumerable<Propietario> BuscarPorNombre(string termino);

        /// <summary>Obtiene solo los propietarios con estado Activo.</summary>
        IEnumerable<Propietario> ObtenerActivos();
    }
}
