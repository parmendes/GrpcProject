using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add gRPC services to the container
builder.Services.AddGrpc();

var app = builder.Build();

// Enable static files
app.UseStaticFiles();

// Map the gRPC service
app.MapGrpcService<GrpcProject.Services.GreetingService>();

// Fallback HTTP endpoint
app.MapGet("/", () => "This is a gRPC server. Use a gRPC client to communicate.");

app.Run();