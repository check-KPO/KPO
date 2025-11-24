using AppForTesting.Models;
using Xunit;

namespace AppForTesting.Tests;

public class ReportTests
{
    [Fact]
    public void Ctor_Call_PropertiesHaveExpectedValues()
    {
        // Arrange
        var expectedTitle = "Отчет";
        var expectedDate = DateOnly.FromDateTime(DateTime.Now);
        var expectedTime = TimeOnly.FromDateTime(DateTime.Now);
        var expectedCarsSold = 100;
        var expectedMotorcyclesSold = 50;

        // Act
        var report = new Report(
            title: expectedTitle,
            date: expectedDate,
            time: expectedTime,
            carsSold: expectedCarsSold,
            motorcyclesSold: expectedMotorcyclesSold
        );

        // Assert
        Assert.Equal(expectedTitle, report.Title);
        Assert.Equal(expectedDate, report.Date);
        Assert.Equal(expectedTime, report.Time);
        Assert.Equal(expectedCarsSold, report.CarsSold);
        Assert.Equal(expectedMotorcyclesSold, report.MotorcyclesSold);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    public void Ctor_CallWithValidCarsSold_ShouldNotThrow(int carsSold)
    {
        // Act & Assert
        var _ = new Report(
            title: "Отчет",
            date: DateOnly.FromDateTime(DateTime.Now),
            time: TimeOnly.FromDateTime(DateTime.Now),
            carsSold: carsSold,
            motorcyclesSold: 50
        );
    }

    [Theory]
    [MemberData(nameof(TestData.InvalidCarsSoldData), MemberType = typeof(TestData))]
    public void Ctor_CallWithInvalidCarsSold_ShouldThrow(int carsSold)
    {
        // Act & Assert
        var _ = Assert.Throws<ArgumentException>(() => new Report(
            title: "Отчет",
            date: DateOnly.FromDateTime(DateTime.Now),
            time: TimeOnly.FromDateTime(DateTime.Now),
            carsSold: carsSold,
            motorcyclesSold: 50
        ));
    }

    [Theory]
    [MemberData(nameof(TestData.GetValuesInRange), 0, 2, MemberType = typeof(TestData))]
    public void Ctor_CallWithValidMotorcyclesSold_ShouldNotThrow(int motorcyclesSold)
    {
        // Act & Assert
        var _ = new Report(
            title: "Отчет",
            date: DateOnly.FromDateTime(DateTime.Now),
            time: TimeOnly.FromDateTime(DateTime.Now),
            carsSold: 100,
            motorcyclesSold: motorcyclesSold
        );
    }
}

file static class TestData
{
    public static TheoryData<int> InvalidCarsSoldData => new() {
        {-1},
        {-10}
    };

    public static TheoryData<int> GetValuesInRange(int min, int max)
    {
        var data = new TheoryData<int>();
        
        for (var i = min; i <= max; i++)
        {
            data.Add(i);
        }

        return data;
    }
}