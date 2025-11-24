namespace AutoMarketApp.UseCases.Cars.ListCars;

internal sealed class ListCarsRequestHandler : IListCarsRequestHandler
{
    private readonly IListCarsRepository _repository;

    public ListCarsRequestHandler(IListCarsRepository repository)
    {
        _repository = repository;
    }

    public ListCarsResponse Handle()
    {
        var cars = _repository.GetAll();

        return new ListCarsResponse(cars.Select(CarMapper.ToDto).ToList());
    }
}


