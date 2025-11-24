namespace AutoMarketApp.UseCases.Customers.AddCustomer;

public interface IAddCustomersRequestHandler
{
    AddCustomerResponse Handle(AddCustomerRequest request);
}


