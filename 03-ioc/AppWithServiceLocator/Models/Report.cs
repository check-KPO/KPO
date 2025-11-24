using System.Text;

namespace AppWithServiceLocator.Models;

public sealed record Report(
    string Title,
    DateOnly Date,
    TimeOnly Time,
    int CarsSold,
    int MotorcyclesSold
) {
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
