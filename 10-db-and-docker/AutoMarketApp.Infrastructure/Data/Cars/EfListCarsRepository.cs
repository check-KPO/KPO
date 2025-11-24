using AutoMarketApp.Entities.Models;
using AutoMarketApp.Infrastructure.Data;
using AutoMarketApp.UseCases.Cars.ListCars;

internal sealed class EfListCarsRepository(AutoMarketAppDbContext dbContext) : IListCarsRepository
{
    public IReadOnlyList<Car> GetAll()
    {
        // Extract all cars
        var cars = dbContext.Cars.ToList();
        
        // Extract all customers that we require
        var customerIds = cars
            .SelectMany(x => new[] {x.Reservation?.CustomerId, x.Sale?.CustomerId})
            .Where(x => x is not null)
            .Cast<Guid>()
            .Distinct()
            .ToList();

        var customers = dbContext.Customers
            .Where(x => customerIds.Contains(x.Id))
            .ToDictionary(x => x.Id);

        if (customers.Count != customerIds.Count)
        {
            throw new InvalidOperationException("Unknown customers in reservations or sales");
        }
        
        // Convert cars
        return cars
            .Select(x => new Car(
                x.Vin,
                x.Reservation?.ToEntity(customers[x.Reservation.CustomerId]),
                x.Sale?.ToEntity(customers[x.Sale.CustomerId])))
            .ToList();
    }
}