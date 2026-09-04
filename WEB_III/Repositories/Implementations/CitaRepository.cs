using WEB_III.Models;
using WEB_III.Models.Enums;
using WEB_III.Repositories.Interfaces;

namespace WEB_III.Repositories.Implementations
{
    /// <summary>
    /// Implementación en memoria del repositorio de Citas.
    /// </summary>
    public class CitaRepository : ICitaRepository
    {
        private static readonly List<Cita> _citas = new()
        {
            new Cita
            {
                Id              = 1,
                MascotaId       = 1,
                VeterinarioId   = 1,
                FechaHoraAtencion = new DateTime(2026, 9, 5, 10, 0, 0),
                Motivo          = "Vacunación anual",
                Estado          = EstadoCita.Pendiente,
                Diagnostico     = null
            },
            new Cita
            {
                Id              = 2,
                MascotaId       = 3,
                VeterinarioId   = 2,
                FechaHoraAtencion = new DateTime(2026, 9, 3, 14, 30, 0),
                Motivo          = "Revisión post-operatoria",
                Estado          = EstadoCita.Completada,
                Diagnostico     = "Recuperación satisfactoria, sin complicaciones."
            },
            new Cita
            {
                Id              = 3,
                MascotaId       = 2,
                VeterinarioId   = 1,
                FechaHoraAtencion = new DateTime(2026, 9, 2, 9, 0, 0),
                Motivo          = "Alergia en la piel",
                Estado          = EstadoCita.Cancelada,
                Diagnostico     = null
            }
        };

        private static int _nextId = 4;

        public IEnumerable<Cita> ObtenerTodos() => _citas.ToList();

        public Cita? ObtenerPorId(int id) =>
            _citas.FirstOrDefault(c => c.Id == id);

        public void Agregar(Cita cita)
        {
            cita.Id = _nextId++;
            _citas.Add(cita);
        }

        public void Actualizar(Cita cita)
        {
            int index = _citas.FindIndex(c => c.Id == cita.Id);
            if (index >= 0)
                _citas[index] = cita;
        }

        public void Eliminar(int id)
        {
            var cita = _citas.FirstOrDefault(c => c.Id == id);
            if (cita is not null)
                _citas.Remove(cita);
        }

        public IEnumerable<Cita> ObtenerPorMascota(int mascotaId) =>
            _citas.Where(c => c.MascotaId == mascotaId);

        public IEnumerable<Cita> ObtenerPorVeterinario(int veterinarioId) =>
            _citas.Where(c => c.VeterinarioId == veterinarioId);

        public IEnumerable<Cita> ObtenerPorEstado(EstadoCita estado) =>
            _citas.Where(c => c.Estado == estado);

        public IEnumerable<Cita> ObtenerPorRangoFecha(DateTime desde, DateTime hasta) =>
            _citas.Where(c => c.FechaHoraAtencion >= desde && c.FechaHoraAtencion <= hasta);
    }
}
