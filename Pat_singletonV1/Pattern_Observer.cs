using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Интерфейс наблюдателя
public interface ICustomer
{
    void Update(string message);
}

// Интерфейс производителя пиццы, отсылающий уведомления о пиццах
public interface IPizzaNotifier
{
    void Subscribe(ICustomer customer);
    void Unsubscribe(ICustomer customer);
    void Notify(string message);
}

// Конкретный производитель пиццы (пиццерия)
public class PizzaNotifier : IPizzaNotifier
{
    private List<ICustomer> _customers = new List<ICustomer>();

    public void Subscribe(ICustomer customer)
    {
        _customers.Add(customer);
        Console.WriteLine("Клиент подписан на уведомления.");
    }

    public void Unsubscribe(ICustomer customer)
    {
        _customers.Remove(customer);
        Console.WriteLine("Клиент отписался от уведомлений.");
    }

    public void Notify(string message)
    {
        foreach (var customer in _customers)
        {
            customer.Update(message);
        }
    }

    // Дополнительный метод, имитирующий процесс заказа
    public void MakePizza()
    {
        Console.WriteLine("Пицца готовится...");
        Notify("Пицца приготовлена!");

        Console.WriteLine("Пицца передана в доставку...");
        Notify("Пицца отправлена!");

        Console.WriteLine("Пицца доставлена.");
        Notify("Пицца доставлена!");
    }
}

// Конкретный наблюдатель (клиент)
public class Customer : ICustomer
{
    private string _name;

    public Customer(string name)
    {
        _name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"Клиент {_name} получил уведомление: {message}");
    }
}

// Реализация в основной программе
class Program
{
    static void Main(string[] args)
    {
        PizzaNotifier notifier = new PizzaNotifier();

        Customer alice = new Customer("Алиса"); // Клиент 1
        Customer bob = new Customer("Боб");  // Клиент 2

        notifier.Subscribe(alice);
        notifier.Subscribe(bob);

        notifier.MakePizza();

        notifier.Unsubscribe(bob);

        Console.WriteLine("\nНовый заказ:");
        notifier.MakePizza();
    }
}
