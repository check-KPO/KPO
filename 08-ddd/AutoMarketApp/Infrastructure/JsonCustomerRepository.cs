using System.Text.Json;
using AutoMarketApp.Domain.Models;
using AutoMarketApp.Domain.Repositories;
using AutoMarketApp.Infrastructure.Dtos;
using AutoMarketApp.Infrastructure.Mappers;

namespace AutoMarketApp.Infrastructure;

internal sealed class JsonCustomerRepository : ICustomerRepository
{
    private readonly string _filePath;
    private readonly List<CustomerDto> _customers;

    public JsonCustomerRepository(string filePath = "customers.json")
    {
        _filePath = filePath;
        _customers = LoadFromFile();
    }

    public IReadOnlyList<Customer> List()
    {
        return _customers.Select(CustomerMapper.ToDomain).ToList();
    }

    public Customer? GetById(Guid id)
    {
        var dto = _customers.FirstOrDefault(c => c.Id == id);
        if (dto == null)
            return null;

        return dto.ToDomain();
    }

    public void Save(Customer customer)
    {
        var dto = _customers.FirstOrDefault(c => c.Id == customer.Id);
        var customerDto = customer.ToDto();

        if (dto == null)
        {
            _customers.Add(customerDto);
        }
        else
        {
            var index = _customers.IndexOf(dto);
            _customers[index] = customerDto;
        }

        SaveToFile();
    }

    private List<CustomerDto> LoadFromFile()
    {
        if (!File.Exists(_filePath))
            return new List<CustomerDto>();

        try
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<CustomerDto>>(json) ?? new List<CustomerDto>();
        }
        catch
        {
            return new List<CustomerDto>();
        }
    }

    private void SaveToFile()
    {
        var json = JsonSerializer.Serialize(_customers, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}

