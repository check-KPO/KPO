namespace AutoMarketApp.UseCases.Customers.ListCustomers;

public sealed record ListCustomersResponse(
    IReadOnlyList<ListCustomersResponseItem> Customers
);


