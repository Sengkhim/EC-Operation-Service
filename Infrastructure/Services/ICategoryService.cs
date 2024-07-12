
namespace EcommerceServiceOperation.Infrastructure.Services;

public interface ICategoryService
{
    Task CreateAsync(CategoryRequest request);

    Task<IEnumerable<CategoryResponse>> GetAllAsync();
}