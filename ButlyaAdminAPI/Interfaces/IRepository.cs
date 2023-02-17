namespace ButlyaAdminAPI.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        Task<List<T>> GetList();
        Task<T?> Get(int id);
        Task Create(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(T item);
        Task Save();
    }
}