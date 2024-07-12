namespace EcommerceServiceOperation.Infrastructure.Request;

public record ProductRequest
{
    public required string Name { get; init; }
    public required string CategoryId { get; init; }
    public string? Code { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }
}