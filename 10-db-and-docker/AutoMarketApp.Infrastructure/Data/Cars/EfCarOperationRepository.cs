using AutoMarketApp.Entities.Models;
using AutoMarketApp.Infrastructure.Data.Dtos;
using AutoMarketApp.UseCases.Cars.ReserveCar;
using AutoMarketApp.UseCases.Cars.SellCar;
using Microsoft.EntityFrameworkCore;

namespace AutoMarketApp.Infrastructure.Data.Cars;

internal sealed class EfCarOperationRepository(AutoMarketAppDbContext dbContext) : IReserveCarRepository, ISellCarRepository
{
    public Car? GetByVin(string vin)
    {
        var car = dbContext.Cars
            .AsNoTracking()
            .SingleOrDefault(c => c.Vin == vin);

        if (car is null)
        {
            return null;
        }
        
        Reservation? reservation = null;

        if (car.Reservation is not null)
        {
            var customer = GetExistingCustomerById(car.Reservation.CustomerId);
            reservation = car.Reservation.ToEntity(customer);
        }
        
        Sale? sale = null;

        if (car.Sale is not null)
        {
            var customer = GetExistingCustomerById(car.Sale.CustomerId);
            sale = car.Sale.ToEntity(customer);
        }
        
        return new Car(car.Vin, reservation, sale);
    }

    public Customer? GetCustomerById(Guid id)
    {
        return dbContext.Customers.SingleOrDefault(x => x.Id == id)?.ToEntity();
    }

    public void Save(Car car)
    {
        dbContext.Update(car.ToDto());
        dbContext.SaveChanges();
    }

    private CustomerDto GetExistingCustomerById(Guid id)
    {
        return dbContext.Customers
            .AsNoTracking()
            .Single(x => x.Id == id);
    }
}