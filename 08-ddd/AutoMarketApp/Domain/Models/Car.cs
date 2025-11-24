namespace AutoMarketApp.Domain.Models;

/// <summary>
/// Entity representing a car in the AutoMarket
/// </summary>
public sealed class Car
{
    public string Vin { get; }
    public Reservation? Reservation { get; private set; }
    public Sale? Sale { get; private set; }

    public Car(string vin)
    {
        if (string.IsNullOrWhiteSpace(vin))
            throw new ArgumentException("VIN cannot be empty", nameof(vin));

        Vin = vin;
    }

    public void Reserve(Reservation reservation)
    {
        if (Sale is not null)
            throw new InvalidOperationException("Cannot reserve a sold car");

        if (Reservation is not null && Reservation.IsActive)
            throw new InvalidOperationException("Car is already reserved");

        Reservation = reservation;
    }

    public void Sell(Sale sale)
    {
        if (Sale is not null)
            throw new InvalidOperationException("Car is already sold");

        if (Reservation is not null && Reservation.IsActive && Reservation.Customer.Id != sale.Customer.Id)
            throw new InvalidOperationException("Cannot sell car to different customer when reserved");

        Sale = sale;
    }
}

