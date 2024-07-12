using EcommerceServiceOperation.Data;
using EcommerceServiceOperation.Infrastructure.Repository;

namespace EcommerceServiceOperation.Infrastructure.Services;

public interface IUnitOfWork : IDisposable 
{
    IEcDataContext Context { get; }
    IRepository<T> Repository<T>() where T : class;
    Task<int> CommitAsync(CancellationToken cancellationToken);
    Task Rollback();
}