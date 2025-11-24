using AppForTesting.Models;

namespace AppForTesting.Services;

public interface IReportSaver
{
    void SaveReport(Report report);
}
