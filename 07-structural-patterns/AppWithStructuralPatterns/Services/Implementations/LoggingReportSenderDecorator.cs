using AppWithStructuralPatterns.Services;
using AppWithStructuralPatterns.Models;

namespace AppWithStructuralPatterns.Services.Implementations;

internal sealed class LoggingReportSenderDecorator<TSender>(TSender sender) : IReportSender
    where TSender : IReportSender
{
    public void SendReport(Report report)
    {
        Console.WriteLine($"{typeof(TSender).Name}: Начало отправки отчета: {report.Title}");
        sender.SendReport(report);
        Console.WriteLine($"{typeof(TSender).Name}: Конец отправки отчета: {report.Title}");
    }
}

public static class LoggingReportSenderDecoratorExtensions
{
    public static IReportSender AddLogging<TSender>(this TSender sender)
        where TSender : IReportSender
    {
        return new LoggingReportSenderDecorator<TSender>(sender);
    }
}