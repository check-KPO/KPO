namespace AutoMarketApp.Domain.Models;

/// <summary>
/// Value Object representing a sale of a car
/// </summary>
public sealed record Sale
{
    public DateTimeOffset SaleDate { get; }
    public Customer Customer { get; }

    public Sale(DateTimeOffset saleDate, Customer customer)
    {
        SaleDate = saleDate;
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
    }
}

