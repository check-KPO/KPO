namespace AutoMarketApp.UseCases.Customers.AddCustomer;

public sealed record AddCustomerRequest(
    string Name,
    string Email,
    string Phone
);


