using AutoMarketApp.Entities.Models;
using AutoMarketApp.UseCases.Cars.ReserveCar;

namespace AutoMarketApp.Infrastructure.Data.Cars;

internal sealed class JsonReserveCarRepository : IReserveCarRepository
{
    private readonly JsonStorage _storage;

    public JsonReserveCarRepository(JsonStorage storage)
    {
        _storage = storage;
    }

    public Car? GetByVin(string vin)
    {
        return _storage.GetCars().FirstOrDefault(c => c.Vin == vin)?.ToEntity(_storage);
    }

    public Customer? GetCustomerById(Guid id)
    {
        return _storage.GetCustomers().FirstOrDefault(c => c.Id == id)?.ToEntity();
    }

    public void Save(Car car)
    {
        _storage.SaveCar(car);
    }
}