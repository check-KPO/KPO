namespace AutoMarketApp.UseCases.Cars.AddCar;

public interface IAddCarRequestHandler
{
    AddCarResponse Handle(AddCarRequest request);
}


