using AutoMarketApp.Infrastructure;
using AutoMarketApp.Presentation.Endpoints;
using AutoMarketApp.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton(TimeProvider.System);

// Register OpenAPI services
builder.Services.AddOpenApi("api");

// Register infrastructure services
builder.Services.AddInfrastructure();

// Register use cases services
builder.Services.AddUseCases();

var app = builder.Build();

// Add OpenAPI endpoints into pipeline
app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/api.json", "AutoMarketApp API");
});

// Add customers endpoints into pipeline
app.MapCustomersEndpoints();

// Add cars endpoints into pipeline
app.MapCarsEndpoints();

// Run the application
app.Run();