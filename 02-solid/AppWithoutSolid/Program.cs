using AppWithoutSolid;

var reportService = new ReportService();
var report = reportService.GenerateReport();
reportService.SaveReport(report, "report.txt");
reportService.SendReport(report, "example@example.com");