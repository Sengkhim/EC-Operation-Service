using EcommerceServiceOperation.Infrastructure.Request;
using EcommerceServiceOperation.Infrastructure.Response;

namespace EcommerceServiceOperation.Infrastructure.Services;

public interface IProductService
{
    Task CreateAsync(ProductRequest request);

    Task<IEnumerable<ProductResponse>> GetAllAsync();
}