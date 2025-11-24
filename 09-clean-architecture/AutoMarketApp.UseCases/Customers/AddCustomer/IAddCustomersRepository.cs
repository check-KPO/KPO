using AutoMarketApp.Entities.Models;

namespace AutoMarketApp.UseCases.Customers.AddCustomer;

public interface IAddCustomersRepository
{
    void Add(Customer customer);
}


