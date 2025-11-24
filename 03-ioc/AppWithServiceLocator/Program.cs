using AppWithServiceLocator;
using AppWithServiceLocator.Models;
using AppWithServiceLocator.Services;
using AppWithServiceLocator.Services.Implementations;

ServiceLocator.AddService<IReportSaver>(new TextReportSaver("report.txt"));
ServiceLocator.AddService<IReportSender>(new EmailReportSender("example@example.com"));

var reportService = new ReportService();
var report = new Report(
    Title: "Отчет",
    Date: DateOnly.FromDateTime(DateTime.Now),
    Time: TimeOnly.FromDateTime(DateTime.Now),
    CarsSold: 100,
    MotorcyclesSold: 50
);
reportService.ProcessReport(report);