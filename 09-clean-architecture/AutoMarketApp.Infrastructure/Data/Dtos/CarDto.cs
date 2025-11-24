namespace AutoMarketApp.Infrastructure.Data.Dtos;

public sealed record CarDto(
    string Vin,
    ReservationDto? Reservation = null,
    SaleDto? Sale = null
);