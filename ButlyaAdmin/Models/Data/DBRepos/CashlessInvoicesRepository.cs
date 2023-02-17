using ButlyaAdmin.Interfaces;
using ButlyaAdmin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Implementation;


namespace ButlyaAdmin.Models.Data.DBRepos;

public class CashlessInvoicesRepository : IRepository<CashlessInvoice>
{
    private readonly ApplicationContext _db = new ApplicationContext();
    
    public IEnumerable<CashlessInvoice> GetList()
    {
        return _db.CashlessInvoices.ToList();
    }

    public CashlessInvoice? Get(int id)
    {
        return _db.CashlessInvoices.Find(id);
    }

    public void Create(CashlessInvoice item)
    {
        _db.CashlessInvoices.Add(item);
    }

    public bool Update(CashlessInvoice item)
    {
        var obj = _db.CashlessInvoices.Find(item);
        if (obj == null) return false;
        _db.Entry(obj).State = EntityState.Modified;
        _db.SaveChanges();
        return true;
    }

    public bool Delete(CashlessInvoice item)
    {
        var obj = _db.CashlessInvoices.Find(item);
        if (obj == null) return false;
        _db.CashlessInvoices.Remove(obj);
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