namespace AutoMarketApp.Domain.Models;

/// <summary>
/// Value Object representing a mobile phone number
/// </summary>
public sealed record MobilePhone
{
    public string Value { get; }

    public MobilePhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Phone number cannot be empty", nameof(phone));

        // Simple validation: phone should contain only digits, spaces, +, -, (), or be empty after cleaning
        var cleaned = phone
            .Replace(" ", "")
            .Replace("-", "")
            .Replace("(", "")
            .Replace(")", "")
            .Replace("+", "");
        
        if (cleaned.Length < 7)
            throw new ArgumentException("Phone number is too short", nameof(phone));

        if (!cleaned.All(char.IsDigit))
            throw new ArgumentException(
                "Phone number must contain only digits and common formatting characters",
                nameof(phone));

        Value = phone;
    }

    public override string ToString()
    {
        return Value;
    }
}

