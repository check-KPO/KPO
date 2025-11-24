namespace AutoMarketApp.Infrastructure.Data.Dtos;

public sealed record CustomerDto(
    Guid Id,
    string Name,
    string Email,
    string Phone
);