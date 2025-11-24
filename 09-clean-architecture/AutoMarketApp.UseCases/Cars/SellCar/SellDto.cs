namespace AutoMarketApp.UseCases.Cars.SellCar;

public sealed record SellDto(
    DateTimeOffset SaleDate,
    Guid CustomerId
);