using AppWithStructuralPatterns.Models;

namespace AppWithStructuralPatterns.Services.Implementations;

internal sealed class EmailReportSender(string email) : IReportSender
{
    public void SendReport(Report report)
    {
        Console.WriteLine($"Отправка отчета на email: {email}");
    }
}
