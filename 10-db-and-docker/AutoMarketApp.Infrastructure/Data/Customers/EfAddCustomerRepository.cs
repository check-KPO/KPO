using AutoMarketApp.Entities.Models;
using AutoMarketApp.Infrastructure.Data;
using AutoMarketApp.UseCases.Customers.AddCustomer;

namespace AutoMarketApp.Infrastructure.Data.Customers;

internal sealed class EfAddCustomerRepository(AutoMarketAppDbContext dbContext) : IAddCustomersRepository
{
    public void Add(Customer customer)
    {
        dbContext.Customers.Add(customer.ToDto());
        dbContext.SaveChanges();
    }
}