using WEB_III.Models;
using WEB_III.Models.Enums;
using WEB_III.Repositories.Interfaces;

namespace WEB_III.Repositories.Implementations
{
    /// <summary>
    /// Implementación en memoria del repositorio de Mascotas.
    /// </summary>
    public class MascotaRepository : IMascotaRepository
    {
        private static readonly List<Mascota> _mascotas = new()
        {
            new Mascota { Id = 1, Nombre = "Toby",   PropietarioId = 1, Especie = "Perro", Raza = "Labrador",   FechaNacimiento = new DateOnly(2020, 3, 15), Color = "Amarillo", Estado = EstadoMascota.Activo },
            new Mascota { Id = 2, Nombre = "Luna",   PropietarioId = 1, Especie = "Gato",  Raza = "Persa",      FechaNacimiento = new DateOnly(2021, 7, 22), Color = "Blanco",   Estado = EstadoMascota.Activo },
            new Mascota { Id = 3, Nombre = "Rocky",  PropietarioId = 2, Especie = "Perro", Raza = "Bulldog",    FechaNacimiento = new DateOnly(2019, 1, 10), Color = "Gris",     Estado = EstadoMascota.Activo },
            new Mascota { Id = 4, Nombre = "Michi",  PropietarioId = 3, Especie = "Gato",  Raza = "Siamés",     FechaNacimiento = new DateOnly(2022, 5, 8),  Color = "Café",     Estado = EstadoMascota.Inactivo }
        };

        private static int _nextId = 5;

        public IEnumerable<Mascota> ObtenerTodos() => _mascotas.ToList();

        public Mascota? ObtenerPorId(int id) =>
            _mascotas.FirstOrDefault(m => m.Id == id);

        public void Agregar(Mascota mascota)
        {
            mascota.Id = _nextId++;
            _mascotas.Add(mascota);
        }

        public void Actualizar(Mascota mascota)
        {
            int index = _mascotas.FindIndex(m => m.Id == mascota.Id);
            if (index >= 0)
                _mascotas[index] = mascota;
        }

        public void Eliminar(int id)
        {
            var mascota = _mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota is not null)
                _mascotas.Remove(mascota);
        }

        public IEnumerable<Mascota> ObtenerPorPropietario(int propietarioId) =>
            _mascotas.Where(m => m.PropietarioId == propietarioId);

        public IEnumerable<Mascota> ObtenerActivas() =>
            _mascotas.Where(m => m.Estado == EstadoMascota.Activo);
    }
}
