using Grpc.Core;
using GrpcProject;

namespace GrpcProject.Services
{
    public class GreetingService : Greeter.GreeterBase
    {
        public override Task<GreetingReply> SayHello(GreetingRequest request, ServerCallContext context)
        {
            var reply = new GreetingReply
            {
                Message = $"Hello, {request.Name}! Welcome to gRPC in C#."
            };

            return Task.FromResult(reply);
        }
    }
}
