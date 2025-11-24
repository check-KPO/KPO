using AutoMarketApp.Infrastructure.Data.Dtos;

namespace AutoMarketApp.Infrastructure.Data;

using Entities.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
internal static partial class DataMapper
{
    public static Car ToEntity(this CarDto dto, JsonStorage storage) =>
        new Car(
            dto.Vin,
            dto.Reservation?.ToEntity(storage),
            dto.Sale?.ToEntity(storage)
        );
    public static partial Customer ToEntity(this CustomerDto dto);
    public static partial CustomerDto ToDto(this Customer entity);
    public static partial CarDto ToDto(this Car entity);
    public static Reservation ToEntity(this ReservationDto dto, JsonStorage storage) =>
        new Reservation(
            dto.ReservationDate,
            storage.GetCustomers().FirstOrDefault(c => c.Id == dto.CustomerId)?.ToEntity()
            ?? throw new InvalidOperationException($"Customer with ID {dto.CustomerId} not found"),
            dto.ExpirationDate
        );
    [MapperIgnoreSource(nameof(Reservation.IsActive))]
    public static partial ReservationDto ToDto(this Reservation entity);
    public static Sale ToEntity(this SaleDto dto, JsonStorage storage) =>
        new Sale(
            dto.SaleDate,
            storage.GetCustomers().FirstOrDefault(c => c.Id == dto.CustomerId)?.ToEntity()
            ?? throw new InvalidOperationException($"Customer with ID {dto.CustomerId} not found")
        );
    public static partial SaleDto ToDto(this Sale entity);
    private static partial MobilePhone ToPhone(this string phone);
    private static partial Email ToEmail(this string email);
}