using System.Linq.Expressions;
using EcommerceServiceOperation.Data;
using EcommerceServiceOperation.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace EcommerceServiceOperation.Infrastructure.Repository;

public class Repository<TEntity>(IEcDataContext context) : IRepository<TEntity>
    where TEntity : class
{ 
    public IQueryable<TEntity> Entities => context.Set<TEntity>();

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Added;
        await context.Set<TEntity>().AddAsync(entity);
        return entity;      
    }
     
    public Task DeleteAsync(TEntity entity)
    {
        context.Entry(entity).State = EntityState.Deleted;
        context.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }

    public Task DeleteByIdAsync(Guid id)
    {
        var data = context.Set<TEntity>().FindAsync(id);
        context.Set<TEntity>().Remove(data.Result!);
        return Task.CompletedTask;
    }

    public async Task<IQueryable<TEntity>?> FindAsync(Expression<Func<TEntity, bool>> expression)
    {
        var result = context.Set<TEntity>().AsQueryable().Where(expression);
        return await Task.FromResult(result);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await context.Set<TEntity>().ToListAsync();

    public async Task<TEntity?> GetByIdAsync(Guid id)
        => await context.Set<TEntity>().FindAsync(id);

    public async Task<IQueryable<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize)
    {
        var query  = context.Set<TEntity>().Skip((pageNumber - 1) * pageSize)
            .Take(pageSize).AsNoTracking().AsQueryable();
        return await Task.FromResult(query);
    }

    public Task UpdateAsync(TEntity entity)
    {
        context.Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }        
}