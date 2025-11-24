namespace AutoMarketApp.Infrastructure.Dtos;

internal sealed record CarDto(
    string Vin,
    ReservationDto? Reservation = null,
    SaleDto? Sale = null
);

internal sealed record ReservationDto(
    DateTimeOffset ReservationDate,
    Guid CustomerId,
    DateTimeOffset ExpirationDate
);

internal sealed record SaleDto(
    DateTimeOffset SaleDate,
    Guid CustomerId
);
