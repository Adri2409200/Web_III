using WEB_III.Models;

namespace WEB_III.Services.Interfaces
{
    /// <summary>
    /// Contrato de lógica de negocio para Mascotas.
    /// </summary>
    public interface IMascotaService
    {
        IEnumerable<Mascota> ObtenerTodos();
        Mascota? ObtenerPorId(int id);
        void Crear(Mascota mascota);
        void Actualizar(Mascota mascota);
        void Eliminar(int id);
        IEnumerable<Mascota> ObtenerPorPropietario(int propietarioId);
        IEnumerable<Mascota> ObtenerActivas();
    }
}
