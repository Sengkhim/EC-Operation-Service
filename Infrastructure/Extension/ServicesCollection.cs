using System.Diagnostics;
using EcommerceServiceOperation.Data;
using EcommerceServiceOperation.Infrastructure.Implement;
using EcommerceServiceOperation.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace EcommerceServiceOperation.Infrastructure.Extension;

public static class ServicesCollection
{
    public static void AddDatabaseLayer(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<IEcDataContext, EcDatabase>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("K_Sport_DB"));
            opt.LogTo((logInfo) => Debug.Write(logInfo), LogLevel.Information);
        });
    }
    
    public static void AddInfrastructureLayer(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddCoreLayer(configuration);

        service.AddScoped<IUnitOfWork, UnitOfWork>();
        service.AddScoped<IProductService, ProductServiceImpl>();
        service.AddScoped<ICategoryService, CategoryServiceImpl>();
    }
    
    private static void AddCoreLayer(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddCors(options =>
        {
            configuration.GetValue<List<string>>("AllowOrigins");
            options.AddDefaultPolicy(policyBuilder => {
                policyBuilder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });    
    }
}