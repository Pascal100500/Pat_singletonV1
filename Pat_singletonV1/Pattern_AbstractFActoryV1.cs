//Pattern Abstract Factory
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Абстрактные элементы интерфейса
public interface IButton
{
    void Paint();
}

public interface ITextField
{
    void Render();
}

//Интерфейс для виндовс
public class WindowsButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Рисуем кнопку в стиле Windows");
    }
}

public class WindowsTextField : ITextField
{
    public void Render()
    {
        Console.WriteLine("Рисуем текстовое поле в стиле Windows");
    }
}

//Интерфейс для macOS
public class MacButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Рисуем кнопку в стиле macOS");
    }
}

public class MacTextField : ITextField
{
    public void Render()
    {
        Console.WriteLine("Рисуем текстовое поле в стиле macOS");
    }
}

//Абстрактная фабрика GIU
public interface IGUIFactory
{
    IButton CreateButton();
    ITextField CreateTextField();
}

//Конкретные фабрики
public class WindowsFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new WindowsButton();
    }

    public ITextField CreateTextField()
    {
        return new WindowsTextField();
    }
}

public class MacFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new MacButton();
    }

    public ITextField CreateTextField()
    {
        return new MacTextField();
    }
}

//Реализация в основной программе
class Program
{
    static void Main(string[] args)
    {
        IGUIFactory factory;

        Console.WriteLine("Введите вашу ОС (windows / mac):");
        string os = Console.ReadLine().ToLower();

        if (os == "windows")
        {
            factory = new WindowsFactory();
        }
        else if (os == "mac")
        {
            factory = new MacFactory();
        }
        else
        {
            Console.WriteLine("Неизвестная ОС. По умолчанию — Windows.");
            factory = new WindowsFactory();
        }

        IButton button = factory.CreateButton();
        ITextField textField = factory.CreateTextField();

        button.Paint();
        textField.Render();

        Console.ReadLine();
    }
}