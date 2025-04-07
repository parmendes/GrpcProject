var builder = WebApplication.CreateBuilder(args);

// Add gRPC services to the container
builder.Services
  .AddCodeFirstGrpc()  // Registers gRPC services
  .AddCodeFirstGrpcOpenApi(); // Enables OpenAPI support

builder.Services.AddGrpcSwagger(); // Register Swagger

var app = builder.Build();

// Map the gRPC service
app.MapGrpcService<GrpcProject.Services.GreetingService>();

// Displays Swagger UI for documentation
app.UseSwagger();
app.UseSwaggerUI();

// Fallback HTTP endpoint
app.MapGet("/", () => "This is a gRPC server. Use a gRPC client to communicate.");

app.Run();
