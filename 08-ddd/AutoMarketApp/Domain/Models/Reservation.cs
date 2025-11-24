namespace AutoMarketApp.Domain.Models;

/// <summary>
/// Value Object representing a reservation of a car
/// </summary>
public sealed record Reservation
{
    public DateTimeOffset ReservationDate { get; }
    public Customer Customer { get; }
    public DateTimeOffset ExpirationDate { get; }

    public bool IsActive => DateTimeOffset.UtcNow <= ExpirationDate;

    public Reservation(DateTimeOffset reservationDate, Customer customer, DateTimeOffset expirationDate)
    {
        if (expirationDate <= reservationDate)
            throw new ArgumentException("Expiration date must be after reservation date", nameof(expirationDate));

        ReservationDate = reservationDate;
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        ExpirationDate = expirationDate;
    }
}

