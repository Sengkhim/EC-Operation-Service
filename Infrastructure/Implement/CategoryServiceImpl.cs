using EcommerceServiceOperation.Infrastructure.Entities;
using EcommerceServiceOperation.Infrastructure.Services;

namespace EcommerceServiceOperation.Infrastructure.Implement;

public class CategoryServiceImpl(IUnitOfWork unitOfWork) : ICategoryService
{
    private readonly Random _random = new ();
    
    public async Task CreateAsync(CategoryRequest request)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var code = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
        
        try
        {
            await unitOfWork.Repository<Category>().AddAsync(new Category
            {
                Id = Guid.NewGuid().ToString(),
                Code = code,
                Name = request.Name,
                Status = true
            });

            await unitOfWork.Context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<IEnumerable<CategoryResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}