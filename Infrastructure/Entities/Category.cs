using EcommerceServiceOperation.Infrastructure.Interface;

namespace EcommerceServiceOperation.Infrastructure.Entities;

public class Category : BaseEntity<string>, ICode
{
    public required string Name { get; init; }

    public string? Code { get; set; } = string.Empty;
    
    public required bool Status { get; init; }

    public Product? Product { get; init; }
}