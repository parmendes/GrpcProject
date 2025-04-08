// This file is part of the GrpcProject repository.
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcProject.Services
{
    public class GreetingService : Greeting.Greeter.GreeterBase
    {
        // This is a gRPC service that implements the Greeter service defined in the Protos folder.
        // It uses dependency injection to get an instance of ILogger for logging purposes.
        // The SayHello method takes a HelloRequest and returns a HelloReply with a greeting message.

        // Constructor injection for ILogger
        private readonly ILogger<GreetingService> _logger;

        public GreetingService(ILogger<GreetingService> logger)
        {
            _logger = logger;
        }

        public override Task<Greeting.HelloReply> SayHello(Greeting.HelloRequest  request, ServerCallContext context)
        {
            _logger.LogInformation("Saying hello to {Name}", request.Name);
            return Task.FromResult(new Greeting.HelloReply { Message = $"Hello, {request.Name}" });
        }
    }
}
