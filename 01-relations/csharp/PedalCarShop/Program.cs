using PedalCarShop;

var factory = new HseCarFactory();

// Первый день продаж
Console.WriteLine("====");
Console.WriteLine("День 1");

// Добавим автомобили
factory.AddCar(1);
factory.AddCar(2);
factory.AddCar(3);
factory.AddCar(4);

// Добавим покупателей
factory.AddCustomer(new("Вася"));
factory.AddCustomer(new("Вова"));
factory.AddCustomer(new("Света"));

// Выводим информацию
Console.WriteLine();
Console.WriteLine("== Автомобили до продажи ==");
Console.WriteLine();

factory.PrintCars();

Console.WriteLine();
Console.WriteLine("== Покупатели до продажи ==");
Console.WriteLine();

foreach (var customer in factory.Customers)
{
    Console.WriteLine(customer);
}

// Продаем автомобили
factory.SaleCar();

// Выводим информацию
Console.WriteLine();
Console.WriteLine("== Автомобили после продажи ==");
Console.WriteLine();

factory.PrintCars();

Console.WriteLine();
Console.WriteLine("== Покупатели после продажи ==");
Console.WriteLine();

foreach (var customer in factory.Customers)
{
    Console.WriteLine(customer);
}

/* ============================================= */

// Второй день продаж
Console.WriteLine("====");
Console.WriteLine("День 2");

// Добавим автомобили
factory.AddCar(2);
factory.AddCar(3);

// Добавим покупателей
factory.AddCustomer(new("Сережа"));
factory.AddCustomer(new("Саша"));
factory.AddCustomer(new("Миша"));

// Выводим информацию
Console.WriteLine();
Console.WriteLine("== Автомобили до продаж ==");
Console.WriteLine();

factory.PrintCars();

Console.WriteLine();
Console.WriteLine("== Покупатели до продажи ==");
Console.WriteLine();

foreach (var customer in factory.Customers)
{
    Console.WriteLine(customer);
}

// Продаем автомобили
factory.SaleCar();

// Выводим информацию
Console.WriteLine();
Console.WriteLine("== Автомобили после продажи ==");
Console.WriteLine();

factory.PrintCars();

Console.WriteLine();
Console.WriteLine("== Покупатели после продажи ==");
Console.WriteLine();

foreach (var customer in factory.Customers)
{
    Console.WriteLine(customer);
}