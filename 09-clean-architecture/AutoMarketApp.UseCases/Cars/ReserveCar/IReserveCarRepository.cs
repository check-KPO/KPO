using AutoMarketApp.Entities.Models;

namespace AutoMarketApp.UseCases.Cars.ReserveCar;

public interface IReserveCarRepository
{
    Car? GetByVin(string vin);
    Customer? GetCustomerById(Guid id);
    void Save(Car car);
}