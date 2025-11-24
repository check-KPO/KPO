using AutoMarketApp.Entities.Models;

namespace AutoMarketApp.UseCases.Cars.ReserveCar;

internal sealed class ReserveCarRequestHandler : IReserveCarRequestHandler
{
    private readonly IReserveCarRepository _repository;
    private readonly TimeProvider _timeProvider;

    public ReserveCarRequestHandler(IReserveCarRepository repository, TimeProvider timeProvider)
    {
        _repository = repository;
        _timeProvider = timeProvider;
    }

    public ReserveCarResponse Handle(ReserveCarRequest request)
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

        var reservation = request.ToEntity(_timeProvider, customer);
        var soldCar = new Car(car.Vin, reservation, sale: null);

        _repository.Save(soldCar);

        return soldCar.ToDto();
    }
}