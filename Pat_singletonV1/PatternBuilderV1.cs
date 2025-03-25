using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pizza
{
    private List<string> ingredients = new List<string>();

    public void AddIngredient(string ingredient)
    {
        ingredients.Add(ingredient);
    }

    public void Show()
    {
        Console.WriteLine("Состав пиццы:");
        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($" - {ingredient}");
        }
    }
}

//Интерфейс Builder'а
public interface IPizzaBuilder
{
    void SetDough(string dough);
    void SetSauce(string sauce);
    void AddTopping(string topping);
    Pizza GetPizza();
}

//Конкретный строитель
public class PizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void SetDough(string dough)
    {
        _pizza.AddIngredient($"Тесто: {dough}");
    }

    public void SetSauce(string sauce)
    {
        _pizza.AddIngredient($"Соус: {sauce}");
    }

    public void AddTopping(string topping)
    {
        _pizza.AddIngredient($"Начинка: {topping}");
    }

    public Pizza GetPizza()
    {
        return _pizza;
    }
}
//Класс директор, знающий как делать каждую пиццу
public class PizzaDirector
{
    private IPizzaBuilder _builder;

    public PizzaDirector(IPizzaBuilder builder)
    {
        _builder = builder;
    }

    public void MakeMargarita()
    {
        _builder.SetDough("тонкое");
        _builder.SetSauce("томатный");
        _builder.AddTopping("сыр");
        _builder.AddTopping("базилик");
    }

    public void MakeHawaiian()
    {
        _builder.SetDough("пышное");
        _builder.SetSauce("сливочный");
        _builder.AddTopping("ветчина");
        _builder.AddTopping("ананасы");
    }
}

//Реализация в основной программе
class Program
{
    static void Main(string[] args)
    {
        var builder = new PizzaBuilder();
        var director = new PizzaDirector(builder);

        Console.WriteLine("Выберите тип пиццы (1 - Маргарита, 2 - Гавайская, 3 - Своё):");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            director.MakeMargarita();
        }
        else if (choice == "2")
        {
            director.MakeHawaiian();
        }
        else
        {
            Console.Write("Введите тип теста: ");
            builder.SetDough(Console.ReadLine());

            Console.Write("Введите соус: ");
            builder.SetSauce(Console.ReadLine());

            Console.WriteLine("Добавляйте начинки (пустая строка — конец):");
            while (true)
            {
                string topping = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(topping)) break;
                builder.AddTopping(topping);
            }
        }

        Pizza pizza = builder.GetPizza();
        pizza.Show();

        Console.ReadLine();
    }
}