namespace AutoMarketApp.UseCases.Cars.SellCar;

public interface ISellCarRequestHandler
{
    SellCarResponse Handle(SellCarRequest request);
}

