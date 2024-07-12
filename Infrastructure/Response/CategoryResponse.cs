namespace EcommerceServiceOperation.Infrastructure.Response;

public record CategoryResponse
{
    public required string Name { get; init; }
    
    public required string Code { get; set; }
    
    public required bool Status { get; init; }
}