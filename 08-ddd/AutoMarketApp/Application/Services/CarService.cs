using AutoMarketApp.Domain.Models;
using AutoMarketApp.Domain.Repositories;

namespace AutoMarketApp.Application.Services;

public sealed class CarService
{
    private readonly ICarRepository _carRepository;
    private readonly ICustomerRepository _customerRepository;

    public CarService(ICarRepository carRepository, ICustomerRepository customerRepository)
    {
        _carRepository = carRepository;
        _customerRepository = customerRepository;
    }

    public Car Add(string vin)
    {
        var existingCar = _carRepository.GetByVin(vin);
        if (existingCar != null)
            throw new InvalidOperationException($"Car with VIN {vin} already exists");

        var car = new Car(vin);
        _carRepository.Save(car);
        return car;
    }

    public IReadOnlyList<Car> List()
    {
        return _carRepository.List();
    }

    public void Reserve(string vin, Guid customerId, DateTimeOffset expirationDate)
    {
        var car = _carRepository.GetByVin(vin)
            ?? throw new InvalidOperationException($"Car with VIN {vin} not found");

        var customer = _customerRepository.GetById(customerId)
            ?? throw new InvalidOperationException($"Customer with ID {customerId} not found");

        var reservationDate = DateTimeOffset.UtcNow;
        var reservation = new Reservation(reservationDate, customer, expirationDate);

        car.Reserve(reservation);
        _carRepository.Save(car);
    }

    public void Sell(string vin, Guid customerId)
    {
        var car = _carRepository.GetByVin(vin)
            ?? throw new InvalidOperationException($"Car with VIN {vin} not found");

        var customer = _customerRepository.GetById(customerId)
            ?? throw new InvalidOperationException($"Customer with ID {customerId} not found");

        var saleDate = DateTimeOffset.UtcNow;
        var sale = new Sale(saleDate, customer);

        car.Sell(sale);
        _carRepository.Save(car);
    }
}
