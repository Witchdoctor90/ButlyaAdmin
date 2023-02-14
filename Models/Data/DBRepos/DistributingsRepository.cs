using ButlyaAdmin.Interfaces;
using ButlyaAdmin.Models;
using Microsoft.EntityFrameworkCore;

namespace ButlyaAdmin.Models.Data.DBRepos;

public class DistributingsRepository : IRepository<Distributing>
{
    private readonly ApplicationContext _db = new ApplicationContext();

    public IEnumerable<Distributing> GetList()
    {
        return _db.Distributings.ToList();
    }

    public Distributing? Get(int id)
    {
        return _db.Distributings.Find(id);
    }

    public void Create(Distributing item)
    {
        _db.Distributings.Add(item);
    }

    public bool Update(Distributing item)
    {
        var dist = _db.Distributings.Find(item);
        if (dist == null) return false;
        _db.Entry(dist).State = EntityState.Modified;
        return true;
    }

    public bool Delete(Distributing item)
    {
        var dist = _db.Distributings.Find(item);
        if (dist == null) return false;
        _db.Distributings.Remove(dist);
        return true;
    }

    public async Task Save()
    {
        await _db.SaveChangesAsync();
    }
    
    private bool disposed = false;
    public void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }

        this.disposed = true;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}