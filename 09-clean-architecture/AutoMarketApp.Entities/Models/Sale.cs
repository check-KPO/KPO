namespace AutoMarketApp.Entities.Models;

/// <summary>
/// Value Object representing a sale of a car
/// </summary>
public sealed record Sale
{
    public Sale(DateTimeOffset saleDate, Customer customer)
    {
        SaleDate = saleDate;
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));
    }

    public DateTimeOffset SaleDate { get; }
    public Customer Customer { get; }
}


