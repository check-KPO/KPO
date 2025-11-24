namespace AutoMarketApp.Domain.Models;

/// <summary>
/// Entity representing a customer
/// </summary>
public sealed class Customer
{
    public Guid Id { get; }
    public string Name { get; }
    public Email Email { get; }
    public MobilePhone Phone { get; }

    public Customer(Guid id, string name, Email email, MobilePhone phone)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Customer ID cannot be empty", nameof(id));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Customer name cannot be empty", nameof(name));

        Id = id;
        Name = name;
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Phone = phone ?? throw new ArgumentNullException(nameof(phone));
    }
}

