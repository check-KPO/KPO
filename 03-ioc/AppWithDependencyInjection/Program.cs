using Microsoft.Extensions.DependencyInjection;
using AppWithDependencyInjection.Models;
using AppWithDependencyInjection.Services;
using AppWithDependencyInjection.Services.Implementations;

var services = new ServiceCollection();

services.AddSingleton<IReportSaver>(_ => new TextReportSaver("report.txt"));
services.AddSingleton<IReportSender>(_ => new EmailReportSender("example@example.com"));
services.AddSingleton<ReportService>();

var provider = services.BuildServiceProvider();

var reportService = provider.GetRequiredService<ReportService>();

var report = new Report(
    Title: "Отчет",
    Date: DateOnly.FromDateTime(DateTime.Now),
    Time: TimeOnly.FromDateTime(DateTime.Now),
    CarsSold: 100,
    MotorcyclesSold: 50
);

reportService.ProcessReport(report);