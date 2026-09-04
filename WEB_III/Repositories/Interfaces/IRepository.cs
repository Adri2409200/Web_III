namespace WEB_III.Repositories.Interfaces
{
    /// <summary>
    /// Contrato genérico CRUD para todos los repositorios del sistema.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad.</typeparam>
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> ObtenerTodos();
        T? ObtenerPorId(int id);
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
    }
}
