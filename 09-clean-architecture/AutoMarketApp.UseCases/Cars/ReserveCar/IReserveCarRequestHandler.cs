namespace AutoMarketApp.UseCases.Cars.ReserveCar;

public interface IReserveCarRequestHandler
{
    ReserveCarResponse Handle(ReserveCarRequest request);
}