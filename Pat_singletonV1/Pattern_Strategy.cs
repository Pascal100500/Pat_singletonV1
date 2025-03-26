using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Интерфейс паттерн стратегия
public interface IDeliveryStrategy
{
    void Deliver(string address);
}

// Конкретные стратегии (способ доставки)
public class CarDelivery : IDeliveryStrategy
{
    public void Deliver(string address)
    {
        Console.WriteLine($"Доставка пиццы на машине по адресу: {address}");
    }
}

public class BikeDelivery : IDeliveryStrategy
{
    public void Deliver(string address)
    {
        Console.WriteLine($"Доставка пиццы на велосипеде по адресу: {address}");
    }
}

public class WalkingDelivery : IDeliveryStrategy
{
    public void Deliver(string address)
    {
        Console.WriteLine($"Доставка пиццы пешком по адресу: {address}");
    }
}

// Контекст — служба доставки пиццы
public class PizzaDelivery
{
    private IDeliveryStrategy _strategy;

    public PizzaDelivery(IDeliveryStrategy strategy)
    {
        _strategy = strategy;
    }

    // Возможность смены стратегии
    public void SetStrategy(IDeliveryStrategy strategy)
    {
        _strategy = strategy;
    }

    public void DeliverOrder(string address)
    {
        _strategy.Deliver(address);
    }
}

// Реализация в основной программе
class Program
{
    static void Main(string[] args)
    {
        PizzaDelivery delivery = new PizzaDelivery(new CarDelivery());
        delivery.DeliverOrder("ул. Программная, 1");

        // Меняем стратегию на велосипед
        delivery.SetStrategy(new BikeDelivery());
        delivery.DeliverOrder("ул. Шаблонная, 42");

        // А теперь пешком
        delivery.SetStrategy(new WalkingDelivery());
        delivery.DeliverOrder("ул. ООП, д. 7");
    }
}
