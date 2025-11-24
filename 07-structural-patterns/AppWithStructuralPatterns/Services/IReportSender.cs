using AppWithStructuralPatterns.Models;

namespace AppWithStructuralPatterns.Services;

public interface IReportSender
{
    void SendReport(Report report);
}
