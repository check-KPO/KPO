namespace AutoMarketApp.UseCases.Cars.ListCars;

public sealed record SaleDto(
    DateTimeOffset SaleDate,
    Guid CustomerId
);


