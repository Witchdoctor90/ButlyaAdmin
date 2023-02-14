namespace ButlyaAdmin.Interfaces;

public interface IRepository<T> : IDisposable 
    where T : class
{
    IEnumerable<T> GetList();
    T? Get(int id);
    void Create(T item);
    bool Update(T item);
    bool Delete(T item);
    Task Save();
}