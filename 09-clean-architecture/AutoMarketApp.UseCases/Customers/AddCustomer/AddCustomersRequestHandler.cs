namespace AutoMarketApp.UseCases.Customers.AddCustomer;

internal sealed class AddCustomersRequestHandler : IAddCustomersRequestHandler
{
    private readonly IAddCustomersRepository _repository;

    public AddCustomersRequestHandler(IAddCustomersRepository repository)
    {
        _repository = repository;
    }

    public AddCustomerResponse Handle(AddCustomerRequest request)
    {
        var customer = request.ToEntity();

        _repository.Add(customer);

        return customer.ToDto();
    }
}


