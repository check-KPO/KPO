using AppForTesting.Models;

namespace AppForTesting.Services;

public interface IReportSender
{
    void SendReport(Report report);
}
