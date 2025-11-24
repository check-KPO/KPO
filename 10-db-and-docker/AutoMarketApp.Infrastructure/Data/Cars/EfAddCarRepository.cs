using AutoMarketApp.Entities.Models;
using AutoMarketApp.UseCases.Cars.AddCar;

namespace AutoMarketApp.Infrastructure.Data.Cars;

internal sealed class EfAddCarRepository(AutoMarketAppDbContext dbContext) : IAddCarRepository
{
    public void Add(Car car)
    {
        dbContext.Add(car.ToDto());
        dbContext.SaveChanges();
    }
}