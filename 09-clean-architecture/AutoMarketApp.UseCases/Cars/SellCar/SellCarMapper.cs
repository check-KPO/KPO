namespace AutoMarketApp.UseCases.Cars.SellCar;

using Entities.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
internal static partial class SellCarMapper
{
    public static SellCarResponse ToDto(this Car car) =>
        new SellCarResponse(car.Vin, car.Sale?.ToDto() ?? throw new InvalidOperationException("Car must have a sale"));

    private static partial SellDto ToDto(this Sale sale);
}