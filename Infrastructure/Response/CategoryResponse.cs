namespace EcommerceServiceOperation.Infrastructure.Response;

public record CeCategoryResponse
{
    public required  string Id { get; set; }
    
    public required string Name { get; init; }
    
    public required string Code { get; set; }
    
    public required bool Status { get; init; }
}