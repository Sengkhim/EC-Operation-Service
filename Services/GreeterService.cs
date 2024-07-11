using Grpc.Core;

namespace EcommerceServiceOperation.Services;

public class GreeterService(ILogger<GreeterService> logger) : Greeter.GreeterBase
{
    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        logger.LogInformation($"{request}");
        
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}