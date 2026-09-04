using WEB_III.Models;
using WEB_III.Models.Enums;
using WEB_III.Repositories.Interfaces;

namespace WEB_III.Repositories.Implementations
{
    /// <summary>
    /// Implementación en memoria del repositorio de Propietarios.
    /// Simula una base de datos usando una lista estática compartida.
    /// </summary>
    public class PropietarioRepository : IPropietarioRepository
    {
        // Lista estática para persistir datos durante la vida de la aplicación
        private static readonly List<Propietario> _propietarios = new()
        {
            new Propietario { Id = 1, Nombre = "Carlos", Apellido = "Mendoza", Telefono = "5551234567", Correo = "carlos@email.com", Estado = EstadoPersona.Activo },
            new Propietario { Id = 2, Nombre = "Laura",  Apellido = "Pérez",   Telefono = "5557654321", Correo = "laura@email.com",  Estado = EstadoPersona.Activo },
            new Propietario { Id = 3, Nombre = "Miguel", Apellido = "Torres",  Telefono = "5559876543", Correo = "miguel@email.com", Estado = EstadoPersona.Inactivo }
        };

        private static int _nextId = 4;

        public IEnumerable<Propietario> ObtenerTodos() => _propietarios.ToList();

        public Propietario? ObtenerPorId(int id) =>
            _propietarios.FirstOrDefault(p => p.Id == id);

        public void Agregar(Propietario propietario)
        {
            propietario.Id = _nextId++;
            _propietarios.Add(propietario);
        }

        public void Actualizar(Propietario propietario)
        {
            int index = _propietarios.FindIndex(p => p.Id == propietario.Id);
            if (index >= 0)
                _propietarios[index] = propietario;
        }

        public void Eliminar(int id)
        {
            var propietario = _propietarios.FirstOrDefault(p => p.Id == id);
            if (propietario is not null)
                _propietarios.Remove(propietario);
        }

        public IEnumerable<Propietario> BuscarPorNombre(string termino) =>
            _propietarios.Where(p =>
                p.Nombre.Contains(termino, StringComparison.OrdinalIgnoreCase) ||
                p.Apellido.Contains(termino, StringComparison.OrdinalIgnoreCase));

        public IEnumerable<Propietario> ObtenerActivos() =>
            _propietarios.Where(p => p.Estado == EstadoPersona.Activo);
    }
}
