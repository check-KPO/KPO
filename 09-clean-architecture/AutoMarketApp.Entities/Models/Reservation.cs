namespace AutoMarketApp.Entities.Models;

/// <summary>
/// Value Object representing a reservation of a car
/// </summary>
public sealed record Reservation
{
    public Reservation(DateTimeOffset reservationDate, Customer customer, DateTimeOffset expirationDate)
    {
        if (expirationDate <= reservationDate)
            throw new ArgumentException("Expiration date must be after reservation date", nameof(expirationDate));

        ReservationDate = reservationDate;
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        ExpirationDate = expirationDate;
    }

    public DateTimeOffset ReservationDate { get; }
    public Customer Customer { get; }
    public DateTimeOffset ExpirationDate { get; }

    public bool IsActive => DateTimeOffset.UtcNow <= ExpirationDate;
}


