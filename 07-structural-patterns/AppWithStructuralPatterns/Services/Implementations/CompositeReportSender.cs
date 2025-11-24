using AppWithStructuralPatterns.Models;
using AppWithStructuralPatterns.Services;

namespace AppWithStructuralPatterns.Services.Implementations;

internal sealed class CompositeReportSender(params IReadOnlyCollection<IReportSender> senders) : IReportSender
{
    public void SendReport(Report report)
    {
        foreach (var sender in senders)
        {
            sender.SendReport(report);
        }
    }
}