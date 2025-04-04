using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Паттерн Декоратор на примере кофе с различными добавками
// Интерфейс напитка
public interface ICoffee
{
    string GetDescription();
    double GetCost();
}

//Конкретный класс для клфе
// Обычный черный кофе
public class SimpleCoffee : ICoffee
{
    public string GetDescription() => "Простой кофе";

    public double GetCost() => 2.0;  //установил цену кофе 2 доллара
}

// Абстрактный декоратор
public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public virtual string GetDescription()
    {
        return _coffee.GetDescription();
    }

    public virtual double GetCost()
    {
        return _coffee.GetCost();
    }
}

//Декораторы: молоко, шоколад (добавки)
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return base.GetDescription() + ", с молоком";
    }

    public override double GetCost()
    {
        return base.GetCost() + 0.5;
    }
}

public class ChocolateDecorator : CoffeeDecorator
{
    public ChocolateDecorator(ICoffee coffee) : base(coffee) { }

    public override string GetDescription()
    {
        return base.GetDescription() + ", с шоколадом";
    }

    public override double GetCost()
    {
        return base.GetCost() + 0.7;
    }
}

// Реализация в основной программе
class Program
{
    static void Main(string[] args)
    {
        ICoffee myCoffee = new SimpleCoffee();
        Console.WriteLine($"{myCoffee.GetDescription()} - {myCoffee.GetCost()}$");

        myCoffee = new MilkDecorator(myCoffee);
        myCoffee = new ChocolateDecorator(myCoffee);

        Console.WriteLine($"{myCoffee.GetDescription()} - {myCoffee.GetCost()}$");
    }
}


