using AppWithDependencyInjection.Models;

namespace AppWithDependencyInjection.Services.Implementations;

internal sealed class EmailReportSender(string email) : IReportSender
{
    public void SendReport(Report report)
    {
        Console.WriteLine($"Отправка отчета на email: {email}");
    }
}
