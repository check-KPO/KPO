using AppWithStructuralPatterns.Services;
using AppWithStructuralPatterns.Models;
using ThirdPartyLibrary;

using Report = AppWithStructuralPatterns.Models.Report;
using ForeignReport = ThirdPartyLibrary.Report;

internal sealed class XmlReportSaverAdapter(string fileName) : IReportSaver
{
    public void SaveReport(Report report)
    {
        var rows = new[] {
            $"Количество проданных автомобилей: {report.CarsSold}",
            $"Количество проданных мотоциклов: {report.MotorcyclesSold}",
        };

        var foreignReport = new ForeignReport(
            Title: report.Title,
            Date: report.Date.ToDateTime(report.Time),
            Rows: rows
        );

        XmlReportSaver.SaveReport(foreignReport, fileName);
    }
}