using WEB_III.Models;
using WEB_III.Repositories.Interfaces;
using WEB_III.Services.Interfaces;

namespace WEB_III.Services.Implementations
{
    /// <summary>
    /// Lógica de negocio para la gestión de Propietarios.
    /// </summary>
    public class PropietarioService : IPropietarioService
    {
        private readonly IPropietarioRepository _repo;

        public PropietarioService(IPropietarioRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Propietario> ObtenerTodos() => _repo.ObtenerTodos();

        public Propietario? ObtenerPorId(int id) => _repo.ObtenerPorId(id);

        public void Crear(Propietario propietario)
        {
            // Normalizar datos antes de persistir
            propietario.Nombre   = propietario.Nombre.Trim();
            propietario.Apellido = propietario.Apellido.Trim();
            propietario.Correo   = propietario.Correo.Trim().ToLower();
            propietario.Telefono = propietario.Telefono.Trim();
            _repo.Agregar(propietario);
        }

        public void Actualizar(Propietario propietario)
        {
            propietario.Nombre   = propietario.Nombre.Trim();
            propietario.Apellido = propietario.Apellido.Trim();
            propietario.Correo   = propietario.Correo.Trim().ToLower();
            propietario.Telefono = propietario.Telefono.Trim();
            _repo.Actualizar(propietario);
        }

        public void Eliminar(int id) => _repo.Eliminar(id);

        public IEnumerable<Propietario> Buscar(string termino) =>
            string.IsNullOrWhiteSpace(termino)
                ? _repo.ObtenerTodos()
                : _repo.BuscarPorNombre(termino.Trim());

        public IEnumerable<Propietario> ObtenerActivos() => _repo.ObtenerActivos();
    }
}
