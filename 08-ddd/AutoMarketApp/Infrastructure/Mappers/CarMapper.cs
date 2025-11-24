using AutoMarketApp.Domain.Models;
using AutoMarketApp.Domain.Repositories;
using AutoMarketApp.Infrastructure.Dtos;
using Riok.Mapperly.Abstractions;

namespace AutoMarketApp.Infrastructure.Mappers;

[Mapper]
internal static partial class CarMapper
{
    internal static Car ToDomain(this CarDto dto, ICustomerRepository customerRepository)
    {
        var car = new Car(dto.Vin);

        if (dto.Reservation != null)
        {
            var customer = customerRepository.GetById(dto.Reservation.CustomerId)
                ?? throw new InvalidOperationException("Customer not found");
            car.Reserve(dto.Reservation.ToDomain(customer));
        }

        if (dto.Sale != null)
        {
            var customer = customerRepository.GetById(dto.Sale.CustomerId)
                ?? throw new InvalidOperationException("Customer not found");
            car.Sell(dto.Sale.ToDomain(customer));
        }

        return car;
    }

    public static CarDto ToDto(this Car car)
    {
        var dto = new CarDto(Vin: car.Vin);

        if (car.Reservation != null)
        {
            dto = dto with
            {
                Reservation = car.Reservation.ToDto()
            };
        }

        if (car.Sale != null)
        {
            dto = dto with
            {
                Sale = car.Sale.ToDto()
            };
        }

        return dto;
    }

    private static partial SaleDto ToDto(this Sale sale);
    [MapperIgnoreSource(nameof(Reservation.IsActive))]
    private static partial ReservationDto ToDto(this Reservation reservation);
    [MapperIgnoreSource(nameof(SaleDto.CustomerId))]
    private static partial Sale ToDomain(this SaleDto dto, Customer customer);
    [MapperIgnoreSource(nameof(ReservationDto.CustomerId))]
    private static partial Reservation ToDomain(this ReservationDto dto, Customer customer);
}
