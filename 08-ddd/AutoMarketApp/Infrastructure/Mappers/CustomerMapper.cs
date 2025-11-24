using AutoMarketApp.Domain.Models;
using AutoMarketApp.Infrastructure.Dtos;
using Riok.Mapperly.Abstractions;

namespace AutoMarketApp.Infrastructure.Mappers;

[Mapper]
internal static partial class CustomerMapper
{
    internal static partial Customer ToDomain(this CustomerDto dto);

    internal static partial CustomerDto ToDto(this Customer customer);
}
