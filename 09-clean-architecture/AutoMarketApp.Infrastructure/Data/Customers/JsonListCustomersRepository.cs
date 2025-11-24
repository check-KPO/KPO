using AutoMarketApp.Entities.Models;
using AutoMarketApp.UseCases.Customers.ListCustomers;

namespace AutoMarketApp.Infrastructure.Data.Customers;

internal sealed class JsonListCustomersRepository : IListCustomersRepository
{
    private readonly JsonStorage _storage;

    public JsonListCustomersRepository(JsonStorage storage)
    {
        _storage = storage;
    }

    public IReadOnlyList<Customer> GetAll()
    {
        return _storage.GetCustomers().Select(DataMapper.ToEntity).ToList();
    }
}