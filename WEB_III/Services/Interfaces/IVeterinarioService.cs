using WEB_III.Models;

namespace WEB_III.Services.Interfaces
{
    /// <summary>
    /// Contrato de lógica de negocio para Veterinarios.
    /// </summary>
    public interface IVeterinarioService
    {
        IEnumerable<Veterinario> ObtenerTodos();
        Veterinario? ObtenerPorId(int id);
        void Crear(Veterinario veterinario);
        void Actualizar(Veterinario veterinario);
        void Eliminar(int id);
        IEnumerable<Veterinario> ObtenerActivos();
        IEnumerable<Veterinario> ObtenerPorEspecialidad(string especialidad);
    }
}
