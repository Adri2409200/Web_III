using WEB_III.Models;
using WEB_III.Repositories.Interfaces;
using WEB_III.Services.Interfaces;

namespace WEB_III.Services.Implementations
{
    /// <summary>
    /// Lógica de negocio para la gestión de Mascotas.
    /// Resuelve la referencia al Propietario en cada mascota.
    /// </summary>
    public class MascotaService : IMascotaService
    {
        private readonly IMascotaRepository      _mascotaRepo;
        private readonly IPropietarioRepository  _propietarioRepo;

        public MascotaService(IMascotaRepository mascotaRepo, IPropietarioRepository propietarioRepo)
        {
            _mascotaRepo      = mascotaRepo;
            _propietarioRepo  = propietarioRepo;
        }

        public IEnumerable<Mascota> ObtenerTodos()
        {
            var mascotas = _mascotaRepo.ObtenerTodos().ToList();
            ResolverPropietarios(mascotas);
            return mascotas;
        }

        public Mascota? ObtenerPorId(int id)
        {
            var mascota = _mascotaRepo.ObtenerPorId(id);
            if (mascota is not null)
                mascota.Propietario = _propietarioRepo.ObtenerPorId(mascota.PropietarioId);
            return mascota;
        }

        public void Crear(Mascota mascota)
        {
            mascota.Nombre = mascota.Nombre.Trim();
            mascota.Raza   = mascota.Raza.Trim();
            mascota.Color  = mascota.Color.Trim();
            _mascotaRepo.Agregar(mascota);
        }

        public void Actualizar(Mascota mascota)
        {
            mascota.Nombre = mascota.Nombre.Trim();
            mascota.Raza   = mascota.Raza.Trim();
            mascota.Color  = mascota.Color.Trim();
            _mascotaRepo.Actualizar(mascota);
        }

        public void Eliminar(int id) => _mascotaRepo.Eliminar(id);

        public IEnumerable<Mascota> ObtenerPorPropietario(int propietarioId)
        {
            var mascotas = _mascotaRepo.ObtenerPorPropietario(propietarioId).ToList();
            ResolverPropietarios(mascotas);
            return mascotas;
        }

        public IEnumerable<Mascota> ObtenerActivas()
        {
            var mascotas = _mascotaRepo.ObtenerActivas().ToList();
            ResolverPropietarios(mascotas);
            return mascotas;
        }

        // ── Helpers ──────────────────────────────────────────────────────────
        private void ResolverPropietarios(IEnumerable<Mascota> mascotas)
        {
            foreach (var m in mascotas)
                m.Propietario = _propietarioRepo.ObtenerPorId(m.PropietarioId);
        }
    }
}
