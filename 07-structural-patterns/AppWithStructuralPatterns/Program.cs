using AppWithStructuralPatterns.Models;
using AppWithStructuralPatterns.Services;
using AppWithStructuralPatterns.Services.Implementations;

var xmlReportSaver = new XmlReportSaverAdapter("report.xml");
var emailReportSender =  new EmailReportSender("example@example.com").AddLogging();
var telegramReportSender = new TelegramReportSender("1234567890").AddLogging();
var compositeReportSender = new CompositeReportSender(emailReportSender, telegramReportSender);

var reportService = new ReportService(xmlReportSaver, compositeReportSender);

var report = new Report(
    Title: "Отчет",
    Date: DateOnly.FromDateTime(DateTime.Now),
    Time: TimeOnly.FromDateTime(DateTime.Now),
    CarsSold: 100,
    MotorcyclesSold: 50
);

reportService.ProcessReport(report);