using AutoMarketApp.Domain.Models;
using AutoMarketApp.Domain.Repositories;

namespace AutoMarketApp.Application.Services;

public sealed class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public IReadOnlyList<Customer> List()
    {
        return _customerRepository.List();
    }

    public Customer Add(string name, Email email, MobilePhone phone)
    {
        var customer = new Customer(Guid.NewGuid(), name, email, phone);
        _customerRepository.Save(customer);
        return customer;
    }
}
