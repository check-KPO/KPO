namespace AutoMarketApp.UseCases.Cars.ReserveCar;

using Entities.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
internal static partial class ReservationMapper
{
    public static Reservation ToEntity(this ReserveCarRequest request, TimeProvider timeProvider, Customer customer) =>
        new Reservation(timeProvider.GetUtcNow(), customer, request.ExpirationDate);

    [MapperIgnoreSource(nameof(Car.Sale))]
    public static partial ReserveCarResponse ToDto(this Car car);

    [MapperIgnoreSource(nameof(Reservation.IsActive))]
    private static partial ReservationDto ToDto(this Reservation reservation);
}

