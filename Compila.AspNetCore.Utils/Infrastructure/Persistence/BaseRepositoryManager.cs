using Compila.Net.Utils.Entity;

using Microsoft.EntityFrameworkCore;

namespace Compila.AspNetCore.Utils.Infrastructure.Persistence
{
    public abstract class BaseRepositoryManager : IBaseRepositoryManager
    {
        protected readonly DbContext _dbContext;

        protected BaseRepositoryManager(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        void UpdateTrackedEntities()
        {
            var entries = _dbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                if (entry.Entity is TrackingEntity entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    }
                    entity.UpdatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                }
            }
        }

        public virtual void SaveChanges()
        {
            UpdateTrackedEntities();

            _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            UpdateTrackedEntities();

            await _dbContext.SaveChangesAsync();
        }
    }
}
