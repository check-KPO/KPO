using AppWithStructuralPatterns.Services;
using AppWithStructuralPatterns.Models;

namespace AppWithStructuralPatterns.Services.Implementations;

internal sealed class TelegramReportSender(string chatId) : IReportSender
{
    public void SendReport(Report report)
    {
        Console.WriteLine($"Отправка отчета в Telegram: {chatId}");
    }
}