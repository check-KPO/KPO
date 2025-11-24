namespace AutoMarketApp.UseCases.Cars.SellCar;

public sealed record SellCarRequest(
    string Vin,
    Guid CustomerId
);

