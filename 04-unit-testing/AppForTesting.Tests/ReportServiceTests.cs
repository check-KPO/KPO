using AppForTesting.Services;
using AppForTesting.Models;
using NSubstitute;

namespace AppForTesting.Tests;

public class ReportServiceTests
{
    [Fact]
    public void ProcessReport_Call_ShouldSaveReport()
    {
        // Arrange
        var reportSaver = Substitute.For<IReportSaver>();
        var reportSender = Substitute.For<IReportSender>();
        var reportService = new ReportService(reportSaver, reportSender);

        var report = new Report(
            title: "Отчет",
            date: DateOnly.FromDateTime(DateTime.Now),
            time: TimeOnly.FromDateTime(DateTime.Now),
            carsSold: 100,
            motorcyclesSold: 50
        );

        // Act
        reportService.ProcessReport(report);

        // Assert
        reportSaver.Received(1).SaveReport(report);
    }
}