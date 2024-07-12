using System.Linq.Expressions;

namespace EcommerceServiceOperation.Infrastructure.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> Entities { get; }
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IQueryable<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize);
    Task<TEntity> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task DeleteByIdAsync(Guid id);
    Task<IQueryable<TEntity>?> FindAsync(Expression<Func<TEntity, bool>> expression);
}