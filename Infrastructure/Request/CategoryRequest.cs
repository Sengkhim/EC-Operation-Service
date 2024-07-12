namespace EcommerceServiceOperation.Infrastructure.Request;

public record CategoryRequest
{
    public required string Name { get; init; }
    
    public required string Code { get; set; }
    
    public required bool Status { get; init; }
}