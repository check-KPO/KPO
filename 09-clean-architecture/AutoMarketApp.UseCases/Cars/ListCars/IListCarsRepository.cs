using AutoMarketApp.Entities.Models;

namespace AutoMarketApp.UseCases.Cars.ListCars;

public interface IListCarsRepository
{
    IReadOnlyList<Car> GetAll();
}


