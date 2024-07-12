using System.Collections;
using EcommerceServiceOperation.Data;
using EcommerceServiceOperation.Infrastructure.Repository;
using EcommerceServiceOperation.Infrastructure.Services;

namespace EcommerceServiceOperation.Infrastructure.Implement;

public class UnitOfWork(EcDatabase? context) : IUnitOfWork
{
    private Hashtable? _repositories;
    private bool _disposed;

    public IEcDataContext Context => context!;
    
    public IRepository<T> Repository<T>() where T : class
    {
        _repositories ??= new Hashtable();

        var type = typeof(T).Name;

        if (_repositories.ContainsKey(type)) return (IRepository<T>)_repositories[type]!;
        
        var repositoryType = typeof(Repository<T>);

        var repositoryInstance = Activator.CreateInstance(repositoryType, context);

        _repositories.Add(type, repositoryInstance);

        return (IRepository<T>)_repositories[type]!;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken) 
        => await context!.SaveChangesAsync(cancellationToken);

    public Task Rollback()
    {
        context!.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        return Task.CompletedTask;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                //dispose managed resources
                context!.Dispose();
        //dispose unmanaged resources
        _disposed = true;
    }
}