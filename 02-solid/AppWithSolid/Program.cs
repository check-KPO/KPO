using AppWithSolid.Models;
using AppWithSolid.Services;
using AppWithSolid.Services.Implementations;

var textReportSaver = new TextReportSaver("report.txt");
var emailReportSender = new EmailReportSender("example@example.com");

var reportService = new ReportService(textReportSaver, emailReportSender);

var report = new Report(
    Title: "Отчет",
    Date: DateTime.Now.ToString("dd.MM.yyyy"),
    Time: DateTime.Now.ToString("HH:mm:ss"),
    CarsSold: 100,
    MotorcyclesSold: 50
);

reportService.ProcessReport(report);