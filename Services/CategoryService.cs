using EcommerceServiceOperation.Data;
using EcommerceServiceOperation.Infrastructure.Entities;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace EcommerceServiceOperation.Services;

public class CategoryService(IEcDataContext ecDataContext, ILogger<CategoryService> logger)
    : CategoryGRPC.CategoryGRPCBase
{
  
    private readonly Random _random = new ();
    
    public override async Task<CategoryResponse> Create(CategoryRequest request, ServerCallContext context)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
        var code = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
        
        var identity = Guid.NewGuid().ToString();
        
        await ecDataContext.Set<Category>().AddAsync(new Category
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Status = true,
            Code = code
        });

        await ecDataContext.SaveChangesAsync();
        
        logger.LogInformation($"Request from {context.Host} is successful");
        
        return await Task.FromResult(new CategoryResponse
        {
            Id = identity,
            Code = code,
            Status = true
        });
    }

    public override async Task<CategoryResponses> GetAll(GetAllRequest request, ServerCallContext context)
    {
        var query = await ecDataContext.Set<Category>()
            .Select(e => new CategoryResponse
            {
                Id = e.Id,
                Code = e.Code,
                Name = e.Name,
                Status = e.Status
            }).ToListAsync();

        var response = new CategoryResponses();
        
        logger.LogInformation($"Request from {context.Host} is successful, {query}");
        
        response.Response.AddRange(query);
        
        return await Task.FromResult(response);
    }
}