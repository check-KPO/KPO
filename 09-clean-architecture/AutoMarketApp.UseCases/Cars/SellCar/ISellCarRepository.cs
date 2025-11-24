using AutoMarketApp.Entities.Models;

namespace AutoMarketApp.UseCases.Cars.SellCar;

public interface ISellCarRepository
{
    Car? GetByVin(string vin);
    Customer? GetCustomerById(Guid id);
    void Save(Car car);
}