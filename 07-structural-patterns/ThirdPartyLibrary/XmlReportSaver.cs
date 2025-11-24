using System.Xml;

namespace ThirdPartyLibrary;

public static class XmlReportSaver
{
    public static void SaveReport(Report report, string fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentNullException(nameof(fileName));
        }

        var xml = new XmlDocument();

        var reportNode = xml.CreateElement("report");

        var titleNode = xml.CreateElement("title");
        titleNode.InnerText = report.Title;
        reportNode.AppendChild(titleNode);

        var dateNode = xml.CreateElement("date");
        dateNode.InnerText = report.Date.ToString("yyyy-MM-dd");
        reportNode.AppendChild(dateNode);

        foreach (var row in report.Rows)
        {
            var rowNode = xml.CreateElement("row");
            var valueNode = xml.CreateElement("value");
            valueNode.InnerText = row;
            rowNode.AppendChild(valueNode);
            reportNode.AppendChild(rowNode);
        }

        xml.AppendChild(reportNode);

        xml.Save(fileName);
    }
}