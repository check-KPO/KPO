using AppWithServiceLocator.Models;

namespace AppWithServiceLocator.Services.Implementations;

internal sealed class TextReportSaver(string fileName) : IReportSaver
{
    public void SaveReport(Report report)
    {
        File.WriteAllText(fileName, report.ToString());
    }
}
