using AutoMarketApp.Entities.Models;

namespace AutoMarketApp.UseCases.Cars.AddCar;

public interface IAddCarRepository
{
    void Add(Car car);
}


