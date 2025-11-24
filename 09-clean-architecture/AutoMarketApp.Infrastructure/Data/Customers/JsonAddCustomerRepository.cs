using AutoMarketApp.Entities.Models;
using AutoMarketApp.UseCases.Customers.AddCustomer;

namespace AutoMarketApp.Infrastructure.Data.Customers;

internal sealed class JsonAddCustomerRepository : IAddCustomersRepository
{
    private readonly JsonStorage _storage;

    public JsonAddCustomerRepository(JsonStorage storage)
    {
        _storage = storage;
    }

    public void Add(Customer customer)
    {
        _storage.SaveCustomer(customer);
    }
}