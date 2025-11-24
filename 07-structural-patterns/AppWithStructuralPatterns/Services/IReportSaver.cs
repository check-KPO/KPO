using AppWithStructuralPatterns.Models;

namespace AppWithStructuralPatterns.Services;

public interface IReportSaver
{
    void SaveReport(Report report);
}
