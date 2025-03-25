// Pattern Singleton Variant 1

//Patern_SingleTonV1.cs - для копирования названия
using System;

class Logger
{
    private static Logger _instance;
       private Logger()

    {
        // В будущем можно открыть файл для логов или настроить форматирование
    }

    //Метод "ленивого создания", экземпляр создается только тогда, когда он впервые понадобится
    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }
    }

    // Метод для вывода сообщения в консоль
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}