using ButlyaAdminAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ButlyaAdminAPI.Models.Database.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseDataObject
    {
        private readonly ApplicationContext _db = new ApplicationContext();

        public BaseRepository(ApplicationContext context)
        {
            _db = context;
        }

        public async Task<List<TEntity>> GetList()
        {
            return await _db.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> Get(int id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public async Task Create(TEntity item)
        {
            await _db.Set<TEntity>().AddAsync(item);
        }

        public async Task<bool> Update(TEntity item)
        {
            var obj = await _db.Set<TEntity>().FindAsync(item);
            
            if (obj == null) 
                return false;
            
            _db.Entry(obj).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(TEntity item)
        {
            var obj = await _db.Set<TEntity>().FindAsync(item);
            
            if (obj == null) 
                return false;
            
            _db.Set<TEntity>().Remove(obj);
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
}
