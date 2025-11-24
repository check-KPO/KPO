using AutoMarketApp.UseCases.Cars.AddCar;
using AutoMarketApp.UseCases.Cars.ListCars;
using AutoMarketApp.UseCases.Cars.ReserveCar;
using AutoMarketApp.UseCases.Cars.SellCar;
using AutoMarketApp.UseCases.Customers.AddCustomer;
using AutoMarketApp.UseCases.Customers.ListCustomers;
using Microsoft.Extensions.DependencyInjection;

namespace AutoMarketApp.UseCases;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IListCustomersRequestHandler, ListCustomersRequestHandler>();
        services.AddScoped<IAddCustomersRequestHandler, AddCustomersRequestHandler>();
        services.AddScoped<IListCarsRequestHandler, ListCarsRequestHandler>();
        services.AddScoped<IAddCarRequestHandler, AddCarRequestHandler>();
        services.AddScoped<IReserveCarRequestHandler, ReserveCarRequestHandler>();
        services.AddScoped<ISellCarRequestHandler, SellCarRequestHandler>();

        return services;
    }
}

