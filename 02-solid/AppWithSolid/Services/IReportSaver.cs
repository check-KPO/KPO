using AppWithSolid.Models;

namespace AppWithSolid.Services;

public interface IReportSaver
{
    void SaveReport(Report report);
}