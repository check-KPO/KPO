namespace AutoMarketApp.Entities.Models;

/// <summary>
/// Entity representing a car in the AutoMarket
/// </summary>
public sealed class Car
{
    public Car(string vin, Reservation? reservation, Sale? sale)
    {
        if (string.IsNullOrWhiteSpace(vin))
            throw new ArgumentException("VIN cannot be empty", nameof(vin));

        Vin = vin;
        Reservation = reservation;
        Sale = sale;

        ValidateSaleAndReservation();
    }

    public string Vin { get; }
    public Reservation? Reservation { get; }
    public Sale? Sale { get; }

    private void ValidateSaleAndReservation()
    {
        if (Sale is not null && Reservation is not null)
            throw new InvalidOperationException("Car cannot be sold and reserved at the same time");
    }
}