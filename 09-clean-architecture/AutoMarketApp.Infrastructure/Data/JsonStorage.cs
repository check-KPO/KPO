using System.Text.Json;
using AutoMarketApp.Entities.Models;
using AutoMarketApp.Infrastructure.Data.Dtos;

namespace AutoMarketApp.Infrastructure.Data;

internal sealed class JsonStorage
{
    private readonly string _filePath;
    private readonly List<CustomerDto> _customers = [];
    private readonly List<CarDto> _cars = [];

    public JsonStorage(string filePath = "data.json")
    {
        _filePath = filePath;
        LoadData();
    }

    public IReadOnlyList<CarDto> GetCars() => _cars;
    public IReadOnlyList<CustomerDto> GetCustomers() => _customers;

    public void SaveCustomer(Customer customer)
    {
        var dto = customer.ToDto();
        var existingIndex = _customers.FindIndex(c => c.Id == customer.Id);

        if (existingIndex < 0)
        {
            _customers.Add(dto);
        }
        else
        {
            _customers[existingIndex] = dto;
        }

        SaveData();
    }

    public void SaveCar(Car car)
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

        SaveData();
    }

    private void SaveData()
    {
        var data = new Data
        {
            Customers = _customers,
            Cars = _cars
        };
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    private void LoadData()
    {
        if (!File.Exists(_filePath))
        {
            _customers.Clear();
            _cars.Clear();
            return;
        }

        try
        {
            var json = File.ReadAllText(_filePath);
            var data = JsonSerializer.Deserialize<Data>(json) ?? new Data();
            _customers.Clear();
            _customers.AddRange(data.Customers);
            _cars.Clear();
            _cars.AddRange(data.Cars);
        }
        catch
        {
            _customers.Clear();
            _cars.Clear();
        }
    }

    private sealed class Data
    {
        public List<CustomerDto> Customers { get; init; } = [];
        public List<CarDto> Cars { get; init; } = [];
    }
}