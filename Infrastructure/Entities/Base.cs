namespace EcommerceServiceOperation.Infrastructure.Entities;

public abstract class BaseEntity<T>
{
    public required T Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdateAt { get; set; }
}