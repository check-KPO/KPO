namespace AutoMarketApp.Infrastructure.Dtos;

internal sealed record CustomerDto(
    Guid Id,
    string Name,
    string Email,
    string Phone
);
