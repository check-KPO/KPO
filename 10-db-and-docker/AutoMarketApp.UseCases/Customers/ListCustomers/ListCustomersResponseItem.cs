namespace AutoMarketApp.UseCases.Customers.ListCustomers;

public sealed record ListCustomersResponseItem(
    Guid Id,
    string Name,
    string Email,
    string Phone
);


