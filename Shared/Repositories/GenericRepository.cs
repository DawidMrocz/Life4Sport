using Framework.Shared.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Framework.Shared.Repositories
{
    public abstract class GenericRepository<TDbContext, TEntity> : IGenericRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : BaseModel
    {
        protected readonly TDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public GenericRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetList()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<int> Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public virtual async Task Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
                _dbSet.Attach(entityToDelete);
            _dbSet.Remove(entityToDelete);
            await _dbContext.SaveChangesAsync();
        }


        public virtual async Task Update(TEntity entityToUpdate)
        {
            if (_dbContext.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dbContext.Attach(entityToUpdate);
                _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
