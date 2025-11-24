namespace AutoMarketApp.Infrastructure.Data.Dtos;

public sealed record ReservationDto(
    DateTimeOffset ReservationDate,
    Guid CustomerId,
    DateTimeOffset ExpirationDate
);