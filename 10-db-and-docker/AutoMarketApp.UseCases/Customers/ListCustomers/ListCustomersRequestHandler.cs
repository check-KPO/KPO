namespace AutoMarketApp.UseCases.Customers.ListCustomers;

internal sealed class ListCustomersRequestHandler : IListCustomersRequestHandler
{
    private readonly IListCustomersRepository _repository;

    public ListCustomersRequestHandler(IListCustomersRepository repository)
    {
        _repository = repository;
    }

    public ListCustomersResponse Handle()
    {
        var customers = _repository.GetAll();

        return new ListCustomersResponse(customers.Select(CustomerMapper.ToDto).ToList());
    }
}


