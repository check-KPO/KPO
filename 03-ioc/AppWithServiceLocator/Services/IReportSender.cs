using AppWithServiceLocator.Models;

namespace AppWithServiceLocator.Services;

public interface IReportSender
{
    void SendReport(Report report);
}
