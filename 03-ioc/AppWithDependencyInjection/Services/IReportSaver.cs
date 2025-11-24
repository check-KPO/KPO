using AppWithDependencyInjection.Models;

namespace AppWithDependencyInjection.Services;

public interface IReportSaver
{
    void SaveReport(Report report);
}
