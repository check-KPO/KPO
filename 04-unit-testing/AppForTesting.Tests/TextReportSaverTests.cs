using AppForTesting.Services.Implementations;
using AppForTesting.Models;

namespace AppForTesting.Tests;

public class TextReportSaverTests
{
    [Fact]
    public void SaveReport_Call_ShouldSaveReport()
    {
        // Arrange
        var textReportSaver = new TextReportSaver("report.txt");

        var report = new Report(
            title: "Отчет",
            date: DateOnly.FromDateTime(DateTime.Now),
            time: TimeOnly.FromDateTime(DateTime.Now),
            carsSold: 100,
            motorcyclesSold: 50
        );

        // Act
        textReportSaver.SaveReport(report);

        // Assert
        Assert.True(File.Exists("report.txt"));
    }
}
