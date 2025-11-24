using AutoMarketApp.Entities.Models;

namespace AutoMarketApp.UseCases.Cars.SellCar;

internal sealed class SellCarRequestHandler : ISellCarRequestHandler
{
    private readonly ISellCarRepository _repository;
    private readonly TimeProvider _timeProvider;

    public SellCarRequestHandler(ISellCarRepository repository, TimeProvider timeProvider)
    {
        _repository = repository;
        _timeProvider = timeProvider;
    }

    public SellCarResponse Handle(SellCarRequest request)
    {
        var customer = _repository.GetCustomerById(request.CustomerId);
        if (customer is null)
            throw new InvalidOperationException($"Customer with ID {request.CustomerId} not found");

        var car = _repository.GetByVin(request.Vin);
        if (car is null)
            throw new InvalidOperationException($"Car with VIN {request.Vin} not found");

        if (car.Sale is not null)
            throw new InvalidOperationException($"Car with VIN {request.Vin} is already sold");

        if (car.Reservation is not null)
            throw new InvalidOperationException($"Car with VIN {request.Vin} is already reserved");

        var sale = new Sale(_timeProvider.GetUtcNow(), customer);
        var soldCar = new Car(car.Vin, reservation: null, sale);
        
        _repository.Save(soldCar);

        return soldCar.ToDto();
    }
}