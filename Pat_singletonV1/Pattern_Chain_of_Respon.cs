using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Пример использования паттерна цепочка обязанностей реализующий работу службы поддержки

// Абстрактный обработчик
abstract class SupportHandler
{
    protected SupportHandler _next;

    public void SetNext(SupportHandler next)
    {
        _next = next;
    }

    public abstract void HandleRequest(string request);
}

// Конкретные обработчики

class Level1Support : SupportHandler
{
    public override void HandleRequest(string request)
    {
        if (request.Contains("пароль") || request.Contains("логин"))
        {
            Console.WriteLine("Level 1: Ответили на простой вопрос.");
        }
        else if (_next != null)
        {
            Console.WriteLine("Level 1: Передаём запрос выше...");
            _next.HandleRequest(request);
        }
    }
}

class Level2Support : SupportHandler
{
    public override void HandleRequest(string request)
    {
        if (request.Contains("ошибка") || request.Contains("не работает"))
        {
            Console.WriteLine("Level 2: Решили техническую проблему.");
        }
        else if (_next != null)
        {
            Console.WriteLine("Level 2: Передаём запрос руководству...");
            _next.HandleRequest(request);
        }
    }
}

class Manager : SupportHandler
{
    public override void HandleRequest(string request)
    {
        Console.WriteLine("Manager: Принял сложный запрос. Решим всё!");
    }
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        // Создаём обработчиков (техподдержка различного уровня)
        var level1 = new Level1Support();
        var level2 = new Level2Support();
        var manager = new Manager();

        // Настраиваем цепочку
        level1.SetNext(level2);
        level2.SetNext(manager);

        // Примеры запросов
        Console.WriteLine("Запрос: Я забыл пароль.");
        level1.HandleRequest("Я забыл пароль.");

        Console.WriteLine("\nЗапрос: У меня ошибка при запуске.");
        level1.HandleRequest("У меня ошибка при запуске.");

        Console.WriteLine("\nЗапрос: Хочу вернуть деньги!");
        level1.HandleRequest("Хочу вернуть деньги!");
    }
}
