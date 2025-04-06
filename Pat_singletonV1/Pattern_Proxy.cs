using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Пример использования паттерна прокси для загрузки изображений
//"Заместитель" используется как "заглушка" в случае если изображение долго загружается и только в случае необходимости загружается реальное изображение

// Интерфейс изображения
interface IImage
{
    void Display();
}

// Реальный класс изображения
class RealImage : IImage
{
    private string _fileName;

    public RealImage(string fileName)
    {
        _fileName = fileName;
        LoadFromDisk();
    }

    private void LoadFromDisk()
    {
        Console.WriteLine($"Загрузка изображения: {_fileName}");
    }

    public void Display()
    {
        Console.WriteLine($"Показ изображения: {_fileName}");
    }
}

// Заместитель
class ProxyImage : IImage
{
    private RealImage _realImage;
    private string _fileName;

    public ProxyImage(string fileName)
    {
        _fileName = fileName;
    }

    public void Display()
    {
        // Загружаем изображение только при первом показе
        if (_realImage == null)
        {
            _realImage = new RealImage(_fileName);
        }

        _realImage.Display();
    }
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        IImage image = new ProxyImage("пицца.jpg");

        // Изображение загружается только при первом вызове
        Console.WriteLine("Первый вызов:");
        image.Display();

        Console.WriteLine("\nВторой вызов:");
        image.Display();  // Повторно не загружается
    }
}