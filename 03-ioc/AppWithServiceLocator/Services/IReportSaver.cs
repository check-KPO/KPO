using AppWithServiceLocator.Models;

namespace AppWithServiceLocator.Services;

public interface IReportSaver
{
    void SaveReport(Report report);
}
