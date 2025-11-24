using AutoMarketApp.Entities.Models;
using Riok.Mapperly.Abstractions;

namespace AutoMarketApp.UseCases.Cars.ListCars;

[Mapper]
internal static partial class CarMapper
{
    internal static partial ListCarsResponseItem ToDto(this Car car);
    [MapperIgnoreSource(nameof(Reservation.IsActive))]
    private static partial ReservationDto? ToDto(this Reservation? reservation);
    private static partial SaleDto? ToDto(this Sale? sale);
}


