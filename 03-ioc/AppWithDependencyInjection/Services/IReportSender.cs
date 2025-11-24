using AppWithDependencyInjection.Models;

namespace AppWithDependencyInjection.Services;

public interface IReportSender
{
    void SendReport(Report report);
}
