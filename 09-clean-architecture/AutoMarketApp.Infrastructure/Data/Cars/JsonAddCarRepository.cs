using AutoMarketApp.Entities.Models;
using AutoMarketApp.UseCases.Cars.AddCar;

namespace AutoMarketApp.Infrastructure.Data.Cars;

internal sealed class JsonAddCarRepository : IAddCarRepository
{
    private readonly JsonStorage _storage;

    public JsonAddCarRepository(JsonStorage storage)
    {
        _storage = storage;
    }

    public void Add(Car car)
    {
        _storage.SaveCar(car);
    }
}