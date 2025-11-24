using System.Text;

namespace PedalCarShop;

/// <summary>
/// Покупатель
/// </summary>
public class Customer
{
    public Customer(string name)
    {
        Name = name;
    }
    
    /// <summary>
    /// Имя покупателя
    /// </summary>
    public string Name
    {
        get; // имя не получится изменить
    }

    /// <summary>
    /// Автомобиль
    /// </summary>
    public Car? Car // покупатель существует независимо от автомобиля - поэтому поле допускает значения null
    {
        get; // можно как узнать, какой автомобиль у покупателя
        set; // так и изменить его
    }

    // Переопределим метод ToString для получения информации о покупателе
    public override string ToString()
    {
        if (Car is null)
        {
            return $"Имя: {Name}. Нет автомобиля";
        }

        return $"Имя: {Name}. Автомобиль:\n- {Car}";
    }
}