using AutoMarketApp.Entities.Models;

namespace AutoMarketApp.UseCases.Customers.ListCustomers;

public interface IListCustomersRepository
{
    IReadOnlyList<Customer> GetAll();
}


