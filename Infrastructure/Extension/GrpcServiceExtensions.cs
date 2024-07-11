using System.Reflection;
using Grpc.Core;

namespace EcommerceServiceOperation.Infrastructure.Extension;

public static class GrpcServiceExtensions
{
    public static void AddGrpcServices(this IServiceCollection services)
    {
        services.AddGrpc();
        
        var serviceTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } && typeof(ServerServiceDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var serviceType in serviceTypes) services.AddScoped(serviceType);
    }
    
    public static void MapGrpcServices(this IEndpointRouteBuilder endpoints)
    {
        var grpcServiceTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false, BaseType: not null } && t.BaseType.Name.EndsWith("Base"))
            .ToList();

        foreach (var method in grpcServiceTypes.Select(serviceType => typeof(GrpcEndpointRouteBuilderExtensions)
                     .GetMethod(nameof(GrpcEndpointRouteBuilderExtensions.MapGrpcService), 1,
                         new[] { typeof(IEndpointRouteBuilder) })
                     ?.MakeGenericMethod(serviceType)))
            method?.Invoke(null, [endpoints]);
    }
}