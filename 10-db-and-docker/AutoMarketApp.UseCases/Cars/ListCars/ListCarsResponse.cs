namespace AutoMarketApp.UseCases.Cars.ListCars;

public sealed record ListCarsResponse(
    IReadOnlyList<ListCarsResponseItem> Cars
);


