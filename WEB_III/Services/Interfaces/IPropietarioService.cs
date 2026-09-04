using WEB_III.Models;

namespace WEB_III.Services.Interfaces
{
    /// <summary>
    /// Contrato de lógica de negocio para Propietarios.
    /// </summary>
    public interface IPropietarioService
    {
        IEnumerable<Propietario> ObtenerTodos();
        Propietario? ObtenerPorId(int id);
        void Crear(Propietario propietario);
        void Actualizar(Propietario propietario);
        void Eliminar(int id);
        IEnumerable<Propietario> Buscar(string termino);
        IEnumerable<Propietario> ObtenerActivos();
    }
}
