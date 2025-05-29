using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Interfaces;

namespace Warehouse.Data.Repositories
{
    public class Repository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<T> dbSet;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;

            dbSet = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                throw new Exception($"Error adding entity: {inner}", ex);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            var entry = dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await dbSet.FindAsync(id) != null;
        }
    }
}
