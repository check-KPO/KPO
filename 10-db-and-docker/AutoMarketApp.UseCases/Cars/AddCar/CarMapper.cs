namespace AutoMarketApp.UseCases.Cars.AddCar;

using Entities.Models;

internal static class CarMapper
{
    public static Car ToEntity(this AddCarRequest request) =>
        new Car(request.Vin, reservation: null, sale: null);

    public static AddCarResponse ToDto(this Car car) =>
        new AddCarResponse(car.Vin);
}

