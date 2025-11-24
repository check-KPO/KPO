using AutoMarketApp.UseCases.Customers.AddCustomer;
using AutoMarketApp.UseCases.Customers.ListCustomers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AutoMarketApp.Presentation.Endpoints;

public static class CustomersEndpoints
{
    public static WebApplication MapCustomersEndpoints(this WebApplication app)
    {
        app.MapGroup("/customers")
            .WithTags("Customers")
            .MapGetCustomers()
            .MapAddCustomer();
        
        return app;
    }

    private static RouteGroupBuilder MapGetCustomers(this RouteGroupBuilder group)
    {
        group.MapGet("", (IListCustomersRequestHandler handler) =>
        {
            var response = handler.Handle();
            return Results.Ok(response);
        })
        .WithName("GetCustomers")
        .WithSummary("Get all customers")
        .WithDescription("Get all customers from the database")
        .WithOpenApi();

        return group;
    }

    private static RouteGroupBuilder MapAddCustomer(this RouteGroupBuilder group)
    {
        group.MapPost("", (AddCustomerRequest request, IAddCustomersRequestHandler handler) =>
        {
            var response = handler.Handle(request);
            return Results.Ok(response);
        })
        .WithName("AddCustomer")
        .WithSummary("Add a new customer")
        .WithDescription("Add a new customer to the database")
        .WithOpenApi();

        return group;
    }
}

