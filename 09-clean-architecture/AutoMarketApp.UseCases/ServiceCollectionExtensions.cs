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
        services.AddSingleton<IListCustomersRequestHandler, ListCustomersRequestHandler>();
        services.AddSingleton<IAddCustomersRequestHandler, AddCustomersRequestHandler>();
        services.AddSingleton<IListCarsRequestHandler, ListCarsRequestHandler>();
        services.AddSingleton<IAddCarRequestHandler, AddCarRequestHandler>();
        services.AddSingleton<IReserveCarRequestHandler, ReserveCarRequestHandler>();
        services.AddSingleton<ISellCarRequestHandler, SellCarRequestHandler>();

        return services;
    }
}