using EcommerceServiceOperation.Infrastructure.Interface;

namespace EcommerceServiceOperation.Infrastructure.Entities;

public class Category : BaseEntity<string>, ICloneable, ICode
{
    public required string Name { get; init; }
    
    public required string? Code { get; set; }
    
    public required bool Status { get; init; }

    public object Clone() => this;

    public Product? Product { get; init; }
}