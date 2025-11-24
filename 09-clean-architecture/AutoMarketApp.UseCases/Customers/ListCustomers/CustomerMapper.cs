using AutoMarketApp.Entities.Models;
using Riok.Mapperly.Abstractions;

namespace AutoMarketApp.UseCases.Customers.ListCustomers;

[Mapper]
internal static partial class CustomerMapper
{
    internal static partial ListCustomersResponseItem ToDto(this Customer customer);
}


