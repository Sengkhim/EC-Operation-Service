using EcommerceServiceOperation.Infrastructure.Entities;
using EcommerceServiceOperation.Infrastructure.Request;
using EcommerceServiceOperation.Infrastructure.Response;
using EcommerceServiceOperation.Infrastructure.Services;

namespace EcommerceServiceOperation.Infrastructure.Implement;

public class ProductServiceImpl(IUnitOfWork unitOfWork) : IProductService
{
    public async Task CreateAsync(ProductRequest request)
    {
        try
        {
            await unitOfWork.Repository<Product>().AddAsync(new Product
            {
                Id = Guid.NewGuid().ToString(),
                CategoryId = request.CategoryId,
                Code = Guid.NewGuid().ToString().Take(5).ToString(),
                Name = request.Name,
                Status = true,
                Description = request.Description,
                Price = request.Price
            });

            await unitOfWork.Context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<IEnumerable<ProductResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}