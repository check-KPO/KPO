using AutoMarketApp.Entities.Models;
using AutoMarketApp.UseCases.Cars.ListCars;

namespace AutoMarketApp.Infrastructure.Data.Cars;

internal sealed class JsonListCarsRepository : IListCarsRepository
{
    private readonly JsonStorage _storage;

    public JsonListCarsRepository(JsonStorage storage)
    {
        _storage = storage;
    }

    public IReadOnlyList<Car> GetAll()
    {
        return _storage.GetCars().Select(dto => dto.ToEntity(_storage)).ToList();
    }
}