using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Пример использования паттерна шаблонный метод для создания напитков
// Абстрактный класс с шаблонным методом
abstract class CaffeineBeverage
{
    // Шаблонный метод (final)
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
    }

    // Общие шаги
    private void BoilWater()
    {
        Console.WriteLine("Кипятим воду");
    }

    private void PourInCup()
    {
        Console.WriteLine("Наливаем в чашку");
    }

    // Абстрактные методы — определяются в подклассах
    protected abstract void Brew();
    protected abstract void AddCondiments();
}

// Кофе
class Coffee : CaffeineBeverage
{
    protected override void Brew()
    {
        Console.WriteLine("Завариваем кофе");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавляем сахар и молоко");
    }
}

// Чай
class Tea : CaffeineBeverage
{
    protected override void Brew()
    {
        Console.WriteLine("Завариваем чай");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Добавляем лимон");
    }
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        Console.WriteLine("Готовим чай:");
        CaffeineBeverage tea = new Tea();
        tea.PrepareRecipe();

        Console.WriteLine("\nГотовим кофе:");
        CaffeineBeverage coffee = new Coffee();
        coffee.PrepareRecipe();
    }
}
