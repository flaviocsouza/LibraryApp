using LibraryBusiness.Interface.Repository;
using LibraryBusiness.Model;
using LibraryData.LibraryContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Repository
{
    public abstract class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseModel, new()
    {
        protected readonly LibraryDbContext _context;
        protected readonly DbSet<Entity> _dbSet;
        public BaseRepository(LibraryDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Entity>();
        }
        public virtual async Task<IEnumerable<Entity>> GetAll()
        {
            return await _dbSet.AsNoTracking().Where(e => e.IsActive).ToListAsync();
        }


        public virtual async Task<Entity?> GetById(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }
        public async Task<IEnumerable<Entity>> Find(Expression<Func<Entity, bool>> query) 
        {
            return await _dbSet.AsNoTracking().Where(e => e.IsActive).Where(query).ToListAsync();
        
        }

        public virtual async Task Insert(Entity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(Entity entity)
        {
            entity.UpdateDate = DateTime.Now;
           _dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(Guid id)
        {
            _dbSet.Remove(new Entity() { Id = id });
            await SaveChanges();
        }

        public void  Dispose()
        {
            _context?.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();            
        }
    }
}
