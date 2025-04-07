using GrcpProject.Grpc;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcProject.GrpcServices
{
    public class GreetingService : Greeter.GreeterBase
    {
        private readonly ILogger<GreetingService> _logger;

        public GreetingService(ILogger<GreetingService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest  request, ServerCallContext context)
        {
            _logger.LogInformation("Saying hello to {Name}", request.Name);
            return Task.FromResult(new HelloReply { Message = $"Hello, {request.Name}" });
        }
    }
}
