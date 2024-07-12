using EcommerceServiceOperation.Infrastructure.Services;
using Grpc.Core;

namespace EcommerceServiceOperation.Services;

public class CategoryServiceImpl(ICategoryService service, ILogger<CategoryServiceImpl> logger)
    : CategoryService.CategoryServiceBase
{
    public override async Task<CategoryResponse> Create(CategoryRequest request, ServerCallContext context)
    {
        await service.CreateAsync(request);

        logger.LogInformation($"Request from {context.Host} is sucessful");
        
        return await Task.FromResult(new CategoryResponse
        {
            Id = Guid.NewGuid().ToString(),
            Code = "CT-102",
            Status = true
        });
    }
}