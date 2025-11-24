namespace AutoMarketApp.UseCases.Cars.ListCars;

public sealed record ReservationDto(
    DateTimeOffset ReservationDate,
    Guid CustomerId,
    DateTimeOffset ExpirationDate
);


