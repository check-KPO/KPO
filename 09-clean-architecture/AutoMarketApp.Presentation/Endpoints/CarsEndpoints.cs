using AutoMarketApp.UseCases.Cars.AddCar;
using AutoMarketApp.UseCases.Cars.ListCars;
using AutoMarketApp.UseCases.Cars.ReserveCar;
using AutoMarketApp.UseCases.Cars.SellCar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace AutoMarketApp.Presentation.Endpoints;

public static class CarsEndpoints
{
    public static WebApplication MapCarsEndpoints(this WebApplication app)
    {
        app.MapGroup("/cars")
            .WithTags("Cars")
            .MapGetCars()
            .MapAddCar()
            .MapReserveCar()
            .MapSellCar();
        
        return app;
    }

    private static RouteGroupBuilder MapGetCars(this RouteGroupBuilder group)
    {
        group.MapGet("", (IListCarsRequestHandler handler) =>
        {
            var response = handler.Handle();
            return Results.Ok(response);
        })
        .WithName("GetCars")
        .WithSummary("Get all cars")
        .WithDescription("Get all cars from the database")
        .WithOpenApi();

        return group;
    }

    private static RouteGroupBuilder MapAddCar(this RouteGroupBuilder group)
    {
        group.MapPost("", (AddCarRequest request, IAddCarRequestHandler handler) =>
        {
            var response = handler.Handle(request);
            return Results.Ok(response);
        })
        .WithName("AddCar")
        .WithSummary("Add a new car")
        .WithDescription("Add a new car to the database")
        .WithOpenApi();

        return group;
    }

    private static RouteGroupBuilder MapReserveCar(this RouteGroupBuilder group)
    {
        group.MapPost("reserve", (ReserveCarRequest request, IReserveCarRequestHandler handler) =>
        {
            var response = handler.Handle(request);
            return Results.Ok(response);
        })
        .WithName("ReserveCar")
        .WithSummary("Reserve a car")
        .WithDescription("Reserve a car for a customer")
        .WithOpenApi();

        return group;
    }

    private static RouteGroupBuilder MapSellCar(this RouteGroupBuilder group)
    {
        group.MapPost("sell", (SellCarRequest request, ISellCarRequestHandler handler) =>
        {
            var response = handler.Handle(request);
            return Results.Ok(response);
        })
        .WithName("SellCar")
        .WithSummary("Sell a car")
        .WithDescription("Sell a car to a customer")
        .WithOpenApi();

        return group;
    }
}