using AutoMarketApp.Infrastructure.Data.Dtos;

namespace AutoMarketApp.Infrastructure.Data;

using Entities.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
internal static partial class DataMapper
{
    /* Customers */
    public static partial Customer ToEntity(this CustomerDto dto);
    public static partial CustomerDto ToDto(this Customer entity);

    /* Cars */
    public static partial CarDto ToDto(this Car entity);
    [MapperIgnoreSource(nameof(ReservationDto.CustomerId))]
    public static partial Reservation ToEntity(this ReservationDto dto, CustomerDto customer);
    [MapperIgnoreSource(nameof(Reservation.IsActive))]
    public static partial ReservationDto ToDto(this Reservation entity);
    [MapperIgnoreSource(nameof(SaleDto.CustomerId))]
    public static partial Sale ToEntity(this SaleDto dto, CustomerDto customer);
    public static partial SaleDto ToDto(this Sale entity);

    /* Utils */
    private static partial MobilePhone ToPhone(this string phone);
    private static partial Email ToEmail(this string email);
}