using WEB_III.Models;
using WEB_III.Models.Enums;
using WEB_III.Repositories.Interfaces;

namespace WEB_III.Repositories.Implementations
{
    /// <summary>
    /// Implementación en memoria del repositorio de Veterinarios.
    /// </summary>
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private static readonly List<Veterinario> _veterinarios = new()
        {
            new Veterinario { Id = 1, Nombre = "Sofía",   Apellido = "Ramírez", Especialidad = "Medicina General",  Telefono = "5551112233", Estado = EstadoPersona.Activo },
            new Veterinario { Id = 2, Nombre = "Andrés",  Apellido = "Castro",  Especialidad = "Cirugía",           Telefono = "5554445566", Estado = EstadoPersona.Activo },
            new Veterinario { Id = 3, Nombre = "Valeria", Apellido = "Mora",    Especialidad = "Dermatología",      Telefono = "5557778899", Estado = EstadoPersona.Inactivo }
        };

        private static int _nextId = 4;

        public IEnumerable<Veterinario> ObtenerTodos() => _veterinarios.ToList();

        public Veterinario? ObtenerPorId(int id) =>
            _veterinarios.FirstOrDefault(v => v.Id == id);

        public void Agregar(Veterinario veterinario)
        {
            veterinario.Id = _nextId++;
            _veterinarios.Add(veterinario);
        }

        public void Actualizar(Veterinario veterinario)
        {
            int index = _veterinarios.FindIndex(v => v.Id == veterinario.Id);
            if (index >= 0)
                _veterinarios[index] = veterinario;
        }

        public void Eliminar(int id)
        {
            var veterinario = _veterinarios.FirstOrDefault(v => v.Id == id);
            if (veterinario is not null)
                _veterinarios.Remove(veterinario);
        }

        public IEnumerable<Veterinario> ObtenerActivos() =>
            _veterinarios.Where(v => v.Estado == EstadoPersona.Activo);

        public IEnumerable<Veterinario> ObtenerPorEspecialidad(string especialidad) =>
            _veterinarios.Where(v =>
                v.Especialidad.Contains(especialidad, StringComparison.OrdinalIgnoreCase));
    }
}
