using AutoMarketApp.Entities.Models;

namespace AutoMarketApp.UseCases.Customers.AddCustomer;

internal static class CustomerMapper
{
    public static Customer ToEntity(this AddCustomerRequest request) =>
        new Customer(
            Guid.NewGuid(),
            request.Name,
            new Email(request.Email),
            new MobilePhone(request.Phone));

    public static AddCustomerResponse ToDto(this Customer customer) =>
        new AddCustomerResponse(customer.Id);
}


