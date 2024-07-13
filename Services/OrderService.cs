using Grpc.Core;

namespace EcommerceServiceOperation.Services;

public class OrderService(ILogger<OrderService> logger)  : OrderGRPC.OrderGRPCBase
{
    public override Task<OrderResponse> Create(OrderRequest request, ServerCallContext context)
    {
        var response = Task.FromResult(new OrderResponse
        {
            Id = int.MaxValue,
            Item = request.Item,
            DateTime = DateTime.Now.ToString("h:mm:ss tt zz")
        });
        
        logger.LogInformation($"{response}");
        
        return response;
    }
}