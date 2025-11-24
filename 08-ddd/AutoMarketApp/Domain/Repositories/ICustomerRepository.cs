using AutoMarketApp.Domain.Models;

namespace AutoMarketApp.Domain.Repositories;

public interface ICustomerRepository
{
    IReadOnlyList<Customer> List();
    Customer? GetById(Guid id);
    void Save(Customer customer);
}

