namespace AutoMarketApp.UseCases.Cars.AddCar;

internal sealed class AddCarRequestHandler : IAddCarRequestHandler
{
    private readonly IAddCarRepository _repository;

    public AddCarRequestHandler(IAddCarRepository repository)
    {
        _repository = repository;
    }

    public AddCarResponse Handle(AddCarRequest request)
    {
        var car = request.ToEntity();

        _repository.Add(car);

        return car.ToDto();
    }
}


