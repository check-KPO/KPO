namespace AutoMarketApp.Infrastructure.Data.Dtos;

public sealed record SaleDto(
    DateTimeOffset SaleDate,
    Guid CustomerId
);