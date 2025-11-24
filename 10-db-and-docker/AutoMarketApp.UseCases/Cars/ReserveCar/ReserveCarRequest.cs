namespace AutoMarketApp.UseCases.Cars.ReserveCar;

public sealed record ReserveCarRequest(
    string Vin,
    Guid CustomerId,
    DateTimeOffset ExpirationDate
);

