namespace AutoMarketApp.UseCases.Cars.ReserveCar;

public sealed record ReservationDto(
    DateTimeOffset ReservationDate,
    Guid CustomerId,
    DateTimeOffset ExpirationDate
);

