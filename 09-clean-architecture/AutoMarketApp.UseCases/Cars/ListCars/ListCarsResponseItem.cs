namespace AutoMarketApp.UseCases.Cars.ListCars;

public sealed record ListCarsResponseItem(
    string Vin,
    ReservationDto? Reservation,
    SaleDto? Sale
);


