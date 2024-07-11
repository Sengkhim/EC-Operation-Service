using Grpc.Core;

namespace EcommerceServiceOperation.Services;

public class PaymentServiceImpl(ILogger<PaymentServiceImpl> logger) : PaymentService.PaymentServiceBase
{
    public override Task<PaymentResponse> Payment(PaymentRequest request, ServerCallContext context)
    {
        var response = Task.FromResult(new PaymentResponse
        {
            Id = Guid.NewGuid().ToString(),
            Account = request.Account,
            ReferenceNo = "NTX-0238238234",
            Balance = request.Balance,
            DateTime = DateTime.Now.ToString("h:mm:ss tt zz")
        });
        
        logger.LogInformation($"{response}");
        
        return response;
    }
}