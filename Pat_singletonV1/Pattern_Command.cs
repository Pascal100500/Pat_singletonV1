using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Receiver — повар
class Chef
{
    public void MakePizza(string type)
    {
        Console.WriteLine($" Повар готовит пиццу: {type}");
    }
}

// Command — интерфейс команды
interface IOrderCommand
{
    void Execute();
}

// Конкретные заказы
class MakeCheesePizzaCommand : IOrderCommand
{
    private Chef _chef;

    public MakeCheesePizzaCommand(Chef chef)
    {
        _chef = chef;
    }

    public void Execute()
    {
        _chef.MakePizza("сырная");
    }
}

class MakePepperoniPizzaCommand : IOrderCommand
{
    private Chef _chef;

    public MakePepperoniPizzaCommand(Chef chef)
    {
        _chef = chef;
    }

    public void Execute()
    {
        _chef.MakePizza("пепперони");
    }
}

// Invoker — официант, отправляющий команды
class Waiter
{
    private List<IOrderCommand> _orders = new List<IOrderCommand>();

    public void TakeOrder(IOrderCommand order)
    {
        Console.WriteLine("Официант принял заказ");
        _orders.Add(order);
    }

    public void PlaceOrders()
    {
        Console.WriteLine("Отправка заказов на кухню:");
        foreach (var order in _orders)
        {
            order.Execute();
        }
        _orders.Clear();
    }
}

// Реализация в основной программе
class Program
{
    static void Main(string[] args)
    {
        Chef chef = new Chef();

        // Команды
        IOrderCommand cheesePizza = new MakeCheesePizzaCommand(chef);
        IOrderCommand pepperoniPizza = new MakePepperoniPizzaCommand(chef);

        // Официант
        Waiter waiter = new Waiter();
        waiter.TakeOrder(cheesePizza);
        waiter.TakeOrder(pepperoniPizza);

        // Заказ отправляется на кухню
        waiter.PlaceOrders();
    }
}
