namespace PedalCarShop;

/// <summary>
/// Фабрика автомобилей ВШЭ
/// </summary>
public class HseCarFactory
{
    /// <summary>
    /// Счетчик номеров автомобилей
    /// </summary>
    private int _numberCounter;

    /// <summary>
    /// Выпущенные автомобили
    /// </summary>
    private readonly List<Car> _cars = new(); // Выпускать автомобили может только ВШЭ - поэтому данное поле скрыто
    
    /// <summary>
    /// Покупатели
    /// </summary>
    private readonly List<Customer> _customers = new();

    /// <summary>
    /// Публичное свойство для доступа к коллекции покупателей
    /// </summary>
    public IReadOnlyCollection<Customer> Customers => _customers;

    /// <summary>
    /// Метод добавления покупателя
    /// </summary>
    public void AddCustomer(Customer customer)
    {
        _customers.Add(customer);
    }
    
    /// <summary>
    /// Метод выпуска автомобилей
    /// </summary>
    public void AddCar(int size)
    {
        var number = ++_numberCounter; // Определим номер автомобиля
        
        _cars.Add(new Car(number, size)); // Добавим автомобиль в список выпущенных автомобилей
    }
    
    /// <summary>
    /// Метод продажи автомобилей
    /// </summary>
    public void SaleCar()
    {
        foreach (var customer in Customers) // пройдемся по списку покупателей
        {
            if (customer.Car is not null)
            {
                continue; // если у покупателя уже есть автомобиль - пропустим его
            }

            var car = _cars.FirstOrDefault(); // найдем автомобиль для покупателя

            if (car is null)
            {
                break; // если автомобили закончились - завершаем процесс продажи
            }

            customer.Car = car; // если же все-таки нашли автомобиль - вручаем его
            
            _cars.RemoveAt(0); // и удаляем автомобиль из списка наличия
        }
        
        _cars.Clear(); // ликвидируем оставшиеся автомобили
    }

    /// <summary>
    /// Метод для печати наличия
    /// </summary>
    public void PrintCars()
    {
        foreach (var car in _cars)
        {
            Console.WriteLine(car);
        }
    }
}