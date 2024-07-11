using Grpc.Core;

namespace EcommerceServiceOperation.Services;

public class OrderServiceImpl(ILogger<OrderServiceImpl> logger) : OrderService.OrderServiceBase
{
    public override Task<OrderResponse> Order(OrderRequest request, ServerCallContext context)
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