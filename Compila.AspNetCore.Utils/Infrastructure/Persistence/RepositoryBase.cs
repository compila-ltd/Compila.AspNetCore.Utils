using System.Linq.Expressions;

using Compila.Net.Utils.Entity;

using Microsoft.EntityFrameworkCore;

namespace Compila.AspNetCore.Utils.Infrastructure.Persistence
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity
    {
        protected readonly DbContext _dbContext;

        protected RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> FindAll(bool trackChanges = false) =>
            !trackChanges ?
            _dbContext.Set<T>()
            .AsNoTracking() :
            _dbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false) =>
            !trackChanges ?
            _dbContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            _dbContext.Set<T>()
            .Where(expression);

        public void Create(T entity) => _dbContext.Set<T>().Add(entity);
        public void Update(T entity) => _dbContext.Set<T>().Update(entity);
        public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);
    }
}
