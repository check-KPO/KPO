using AppWithSolid.Models;

namespace AppWithSolid.Services;

public interface IReportSender
{
    void SendReport(Report report);
}