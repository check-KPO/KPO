namespace AutoMarketApp.Entities.Models;

/// <summary>
/// Value Object representing an email address
/// </summary>
public sealed record Email
{
    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty", nameof(email));

        if (!email.Contains('@'))
            throw new ArgumentException("Email must contain @ symbol", nameof(email));

        Value = email;
    }

    public string Value { get; }

    public override string ToString()
    {
        return Value;
    }
}


