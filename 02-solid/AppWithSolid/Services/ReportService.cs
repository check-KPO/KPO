using AppWithSolid.Models;

namespace AppWithSolid.Services;

public sealed class ReportService(IReportSaver reportSaver, IReportSender reportSender)
{
    public void ProcessReport(Report report)
    {
        reportSaver.SaveReport(report);
        reportSender.SendReport(report);
    }
}