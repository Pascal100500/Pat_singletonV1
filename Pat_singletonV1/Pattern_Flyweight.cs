using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Интерфейс легковесного объекта (буква)
interface ILetter
{
    void Display(string font);
}

// Конкретная реализация буквы
class Letter : ILetter
{
    private char _symbol; // Уникальный символ

    public Letter(char symbol)
    {
        _symbol = symbol;
    }

    public void Display(string font)
    {
        Console.WriteLine($"Символ: {_symbol}, Шрифт: {font}");
    }
}

// Фабрика легковесных объектов (хранит уже созданные буквы)
class LetterFactory
{
    private Dictionary<char, ILetter> _letters = new Dictionary<char, ILetter>();

    public ILetter GetLetter(char symbol)
    {
        if (!_letters.ContainsKey(symbol))
        {
            _letters[symbol] = new Letter(symbol);
        }
        return _letters[symbol];
    }
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        LetterFactory factory = new LetterFactory();

        string text = "HELLO";
        string font = "Arial";

        foreach (char c in text)
        {
            ILetter letter = factory.GetLetter(c);
            letter.Display(font);
        }
    }
}