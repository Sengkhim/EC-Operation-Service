using System.Reflection;
using EcommerceServiceOperation.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EcommerceServiceOperation.Data;
using Microsoft.EntityFrameworkCore;
public class EcDatabase (DbContextOptions<EcDatabase> options, IConfiguration configuration) 
    : DbContext(options), IEcDataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("K_Sport_DB")); 
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        bool Expression(EntityEntry<BaseEntity<string>> e) => e.State
            is EntityState.Added 
            or EntityState.Modified
            or EntityState.Deleted;

        var entries = ChangeTracker.Entries<BaseEntity<string>>().Where(Expression).ToList();
        
        foreach (var entityEntry in entries)
        {
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entityEntry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                    break;
                case EntityState.Modified:
                    entityEntry.Entity.UpdateAt = DateTimeOffset.UtcNow;
                    break;
                case EntityState.Deleted:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}