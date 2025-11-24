namespace AutoMarketApp.Infrastructure.Data.Dtos;

public sealed record CarDto(string Vin)
{
    public SaleDto? Sale { get; init; }
    public ReservationDto? Reservation { get; init; }
}