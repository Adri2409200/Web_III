using WEB_III.Models;
using WEB_III.Models.Enums;
using WEB_III.Repositories.Interfaces;
using WEB_III.Services.Interfaces;

namespace WEB_III.Services.Implementations
{
    /// <summary>
    /// Lógica de negocio para la gestión de Citas.
    /// Resuelve referencias de navegación hacia Mascota y Veterinario.
    /// </summary>
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository        _citaRepo;
        private readonly IMascotaRepository     _mascotaRepo;
        private readonly IVeterinarioRepository _vetRepo;

        public CitaService(
            ICitaRepository        citaRepo,
            IMascotaRepository     mascotaRepo,
            IVeterinarioRepository vetRepo)
        {
            _citaRepo    = citaRepo;
            _mascotaRepo = mascotaRepo;
            _vetRepo     = vetRepo;
        }

        public IEnumerable<Cita> ObtenerTodos() => _citaRepo.ObtenerTodos();

        public Cita? ObtenerPorId(int id) => _citaRepo.ObtenerPorId(id);

        public IEnumerable<Cita> ObtenerTodosConDetalles()
        {
            var citas = _citaRepo.ObtenerTodos().ToList();
            ResolverNavegacion(citas);
            return citas;
        }

        public Cita? ObtenerPorIdConDetalles(int id)
        {
            var cita = _citaRepo.ObtenerPorId(id);
            if (cita is not null)
            {
                cita.Mascota     = _mascotaRepo.ObtenerPorId(cita.MascotaId);
                cita.Veterinario = _vetRepo.ObtenerPorId(cita.VeterinarioId);
            }
            return cita;
        }

        public void Crear(Cita cita)
        {
            cita.Motivo     = cita.Motivo.Trim();
            cita.Diagnostico = cita.Diagnostico?.Trim();
            _citaRepo.Agregar(cita);
        }

        public void Actualizar(Cita cita)
        {
            cita.Motivo      = cita.Motivo.Trim();
            cita.Diagnostico = cita.Diagnostico?.Trim();
            _citaRepo.Actualizar(cita);
        }

        public void Eliminar(int id) => _citaRepo.Eliminar(id);

        public IEnumerable<Cita> ObtenerPorMascota(int mascotaId)
        {
            var citas = _citaRepo.ObtenerPorMascota(mascotaId).ToList();
            ResolverNavegacion(citas);
            return citas;
        }

        public IEnumerable<Cita> ObtenerPorVeterinario(int veterinarioId)
        {
            var citas = _citaRepo.ObtenerPorVeterinario(veterinarioId).ToList();
            ResolverNavegacion(citas);
            return citas;
        }

        public IEnumerable<Cita> ObtenerPorEstado(EstadoCita estado)
        {
            var citas = _citaRepo.ObtenerPorEstado(estado).ToList();
            ResolverNavegacion(citas);
            return citas;
        }

        public IEnumerable<Cita> ObtenerPorRangoFecha(DateTime desde, DateTime hasta)
        {
            var citas = _citaRepo.ObtenerPorRangoFecha(desde, hasta).ToList();
            ResolverNavegacion(citas);
            return citas;
        }

        // ── Helpers ──────────────────────────────────────────────────────────
        private void ResolverNavegacion(IEnumerable<Cita> citas)
        {
            foreach (var c in citas)
            {
                c.Mascota     = _mascotaRepo.ObtenerPorId(c.MascotaId);
                c.Veterinario = _vetRepo.ObtenerPorId(c.VeterinarioId);
            }
        }
    }
}
