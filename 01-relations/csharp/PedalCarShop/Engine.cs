namespace PedalCarShop;

/// <summary>
/// Педельный двигатель
/// </summary>
public class Engine
{
    public Engine(int size)
    {
        Size = size;
    }

    /// <summary>
    /// Размер педалей
    /// </summary>
    public int Size
    {
        get; // размер нельзя изменить после создания двигателя
    }
    
    // Определим свойство для получения типа двигателя
    public string Type => "Педальный";
}