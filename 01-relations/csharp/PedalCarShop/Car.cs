namespace PedalCarShop;

/// <summary>
/// Автомобиль
/// </summary>
public class Car
{
    /// <summary>
    /// Двигатель автомобиля
    /// </summary>
    private readonly Engine _engine; // двигатель нельзя ни вынуть, ни поменять

    /// <summary>
    /// Номер автомобиля
    /// </summary>
    public int Number
    {
        get; // Номер не получится поменять после выпуска автомобиля
    }

    public Car(int number, int pedalSize)
    {
        Number = number;
        
        _engine = new Engine(pedalSize);
    }

    // Чтобы получать информацию об автомобиле, при этом не нарушая композицию - переопределим метод ToString
    public override string ToString() => $"Номер: {Number}. Двигатель: {_engine.Type}";
}