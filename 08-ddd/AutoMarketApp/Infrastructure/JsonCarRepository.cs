using System.Text.Json;
using AutoMarketApp.Domain.Models;
using AutoMarketApp.Domain.Repositories;
using AutoMarketApp.Infrastructure.Dtos;
using AutoMarketApp.Infrastructure.Mappers;

namespace AutoMarketApp.Infrastructure;

internal sealed class JsonCarRepository : ICarRepository
{
    private readonly string _filePath;
    private readonly List<CarDto> _cars;
    private readonly ICustomerRepository _customerRepository;

    public JsonCarRepository(ICustomerRepository customerRepository, string filePath = "cars.json")
    {
        _customerRepository = customerRepository;
        _filePath = filePath;
        _cars = LoadFromFile();
    }

    public IReadOnlyList<Car> List()
    {
        return _cars.Select(dto => dto.ToDomain(_customerRepository)).ToList();
    }

    public Car? GetByVin(string vin)
    {
        var dto = _cars.FirstOrDefault(c => c.Vin == vin);
        if (dto == null)
            return null;

        return dto.ToDomain(_customerRepository);
    }

    public void Save(Car car)
    {
        var dto = car.ToDto();
        var existingIndex = _cars.FindIndex(c => c.Vin == car.Vin);

        if (existingIndex < 0)
        {
            _cars.Add(dto);
        }
        else
        {
            _cars[existingIndex] = dto;
        }

        SaveToFile();
    }

    private List<CarDto> LoadFromFile()
    {
        if (!File.Exists(_filePath))
            return new List<CarDto>();

        try
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<CarDto>>(json) ?? new List<CarDto>();
        }
        catch
        {
            return new List<CarDto>();
        }
    }

    private void SaveToFile()
    {
        var json = JsonSerializer.Serialize(_cars, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}

