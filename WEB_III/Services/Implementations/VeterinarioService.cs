using WEB_III.Models;
using WEB_III.Repositories.Interfaces;
using WEB_III.Services.Interfaces;

namespace WEB_III.Services.Implementations
{
    /// <summary>
    /// Lógica de negocio para la gestión de Veterinarios.
    /// </summary>
    public class VeterinarioService : IVeterinarioService
    {
        private readonly IVeterinarioRepository _repo;

        public VeterinarioService(IVeterinarioRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Veterinario> ObtenerTodos() => _repo.ObtenerTodos();

        public Veterinario? ObtenerPorId(int id) => _repo.ObtenerPorId(id);

        public void Crear(Veterinario veterinario)
        {
            veterinario.Nombre        = veterinario.Nombre.Trim();
            veterinario.Apellido      = veterinario.Apellido.Trim();
            veterinario.Especialidad  = veterinario.Especialidad.Trim();
            veterinario.Telefono      = veterinario.Telefono.Trim();
            _repo.Agregar(veterinario);
        }

        public void Actualizar(Veterinario veterinario)
        {
            veterinario.Nombre        = veterinario.Nombre.Trim();
            veterinario.Apellido      = veterinario.Apellido.Trim();
            veterinario.Especialidad  = veterinario.Especialidad.Trim();
            veterinario.Telefono      = veterinario.Telefono.Trim();
            _repo.Actualizar(veterinario);
        }

        public void Eliminar(int id) => _repo.Eliminar(id);

        public IEnumerable<Veterinario> ObtenerActivos() => _repo.ObtenerActivos();

        public IEnumerable<Veterinario> ObtenerPorEspecialidad(string especialidad) =>
            _repo.ObtenerPorEspecialidad(especialidad);
    }
}
