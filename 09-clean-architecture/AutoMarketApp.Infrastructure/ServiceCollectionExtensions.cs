using AutoMarketApp.Infrastructure.Data;
using AutoMarketApp.Infrastructure.Data.Cars;
using AutoMarketApp.Infrastructure.Data.Customers;
using AutoMarketApp.UseCases.Cars.AddCar;
using AutoMarketApp.UseCases.Cars.ListCars;
using AutoMarketApp.UseCases.Cars.ReserveCar;
using AutoMarketApp.UseCases.Cars.SellCar;
using AutoMarketApp.UseCases.Customers.AddCustomer;
using AutoMarketApp.UseCases.Customers.ListCustomers;
using Microsoft.Extensions.DependencyInjection;

namespace AutoMarketApp.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<JsonStorage>();
        services.AddSingleton<IListCarsRepository, JsonListCarsRepository>();
        services.AddSingleton<IListCustomersRepository, JsonListCustomersRepository>();
        services.AddSingleton<IAddCustomersRepository, JsonAddCustomerRepository>();
        services.AddSingleton<IAddCarRepository, JsonAddCarRepository>();
        services.AddSingleton<IReserveCarRepository, JsonReserveCarRepository>();
        services.AddSingleton<ISellCarRepository, JsonSellCarRepository>();

        return services;
    }
}