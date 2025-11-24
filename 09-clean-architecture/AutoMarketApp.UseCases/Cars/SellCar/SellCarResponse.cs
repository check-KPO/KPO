namespace AutoMarketApp.UseCases.Cars.SellCar;

public sealed record SellCarResponse(
    string Vin,
    SellDto Sale
);