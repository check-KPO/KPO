using System.Text;

namespace AppWithoutSolid;

public class ReportService
{
    public string GenerateReport()
    {
        var builder = new StringBuilder();

        builder
            .AppendLine("Отчет")
            .AppendLine($"Дата: {DateTime.Now.ToString("dd.MM.yyyy")}")
            .AppendLine($"Время: {DateTime.Now.ToString("HH:mm:ss")}")
            .AppendLine("--------------------------------")
            .AppendLine($"Продано автомобилей: {100} шт.")
            .AppendLine($"Продано мотоциклов: {50} шт.")
            .AppendLine("--------------------------------");
            
        return builder.ToString();
    }

    public void SaveReport(string report, string fileName)
    {
        File.WriteAllText(fileName, report);
    }
    
    public void SendReport(string report, string email)
    {
        Console.WriteLine($"Отправка отчета на email: {email}");
    }
}