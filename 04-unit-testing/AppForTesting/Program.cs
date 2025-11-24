using AppForTesting.Models;
using AppForTesting.Services;
using AppForTesting.Services.Implementations;

var textReportSaver = new TextReportSaver("report.txt");
var emailReportSender = new EmailReportSender("example@example.com");

var reportService = new ReportService(textReportSaver, emailReportSender);

var report = new Report(
    title: "Отчет",
    date: DateOnly.FromDateTime(DateTime.Now),
    time: TimeOnly.FromDateTime(DateTime.Now),
    carsSold: 100,
    motorcyclesSold: 50
);

reportService.ProcessReport(report);