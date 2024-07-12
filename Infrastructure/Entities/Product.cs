using EcommerceServiceOperation.Infrastructure.Interface;

namespace EcommerceServiceOperation.Infrastructure.Entities;

public class Product : BaseEntity<string>, ICode
{
    public required string Name { get; init; }
    public required string CategoryId { get; init; }
    public required string? Code { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public required bool Status { get; set; }

    public Category? Category { get; set; }
}