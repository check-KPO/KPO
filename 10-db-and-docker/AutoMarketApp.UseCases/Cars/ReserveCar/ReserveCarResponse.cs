namespace AutoMarketApp.UseCases.Cars.ReserveCar;

public sealed record ReserveCarResponse(
    string Vin,
    ReservationDto Reservation
);

