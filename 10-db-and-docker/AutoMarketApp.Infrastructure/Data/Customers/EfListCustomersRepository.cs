using AutoMarketApp.Entities.Models;
using AutoMarketApp.Infrastructure.Data;
using AutoMarketApp.UseCases.Customers.ListCustomers;

namespace AutoMarketApp.Infrastructure.Data.Customers;

internal sealed class EfListCustomersRepository(AutoMarketAppDbContext dbContext) : IListCustomersRepository
{
    public IReadOnlyList<Customer> GetAll()
    {
        return [.. dbContext.Customers.Select(DataMapper.ToEntity)];
    }
}