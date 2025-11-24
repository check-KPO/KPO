using System.Text;

namespace AppForTesting.Models;

public sealed record Report
{
    public Report(string title, DateOnly date, TimeOnly time, int carsSold, int motorcyclesSold)
    {
        Title = string.IsNullOrEmpty(title)
            ? throw new ArgumentException("Title cannot be null or empty")
            : title;
        Date = date;
        Time = time;
        CarsSold = carsSold < 0
            ? throw new ArgumentException("CarsSold cannot be less than 0")
            : carsSold;
        MotorcyclesSold = motorcyclesSold < 0
            ? throw new ArgumentException("MotorcyclesSold cannot be less than 0")
            : motorcyclesSold;
    }

    public string Title { get; }
    public DateOnly Date { get; }
    public TimeOnly Time { get; }
    public int CarsSold { get; }
    public int MotorcyclesSold { get; }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder
            .AppendLine(Title)
            .AppendLine($"Дата: {Date:dd.MM.yyyy}")
            .AppendLine($"Время: {Time:HH:mm:ss}")
            .AppendLine("--------------------------------")
            .AppendLine($"Продано автомобилей: {CarsSold} шт.")
            .AppendLine($"Продано мотоциклов: {MotorcyclesSold} шт.")
            .AppendLine("--------------------------------");

        return builder.ToString();
    }
}
