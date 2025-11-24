using AutoMarketApp.Infrastructure.Data;
using AutoMarketApp.Infrastructure.Data.Cars;
using AutoMarketApp.Infrastructure.Data.Customers;
using AutoMarketApp.UseCases.Cars.AddCar;
using AutoMarketApp.UseCases.Cars.ListCars;
using AutoMarketApp.UseCases.Cars.ReserveCar;
using AutoMarketApp.UseCases.Cars.SellCar;
using AutoMarketApp.UseCases.Customers.AddCustomer;
using AutoMarketApp.UseCases.Customers.ListCustomers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoMarketApp.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AutoMarketAppDbContext>((serviceProvider, options) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IListCustomersRepository, EfListCustomersRepository>();
        services.AddScoped<IAddCustomersRepository, EfAddCustomerRepository>();
        services.AddScoped<IListCarsRepository, EfListCarsRepository>();
        services.AddScoped<IAddCarRepository, EfAddCarRepository>();
        services.AddScoped<IReserveCarRepository, EfCarOperationRepository>();
        services.AddScoped<ISellCarRepository, EfCarOperationRepository>();

        services.AddHostedService<MigrationRunner>();

        return services;
    }
}