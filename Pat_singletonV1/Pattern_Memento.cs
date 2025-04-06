using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Пример использования паттерна Хранитель в текстовом редакторе
// Хранитель — сохраняет состояние
class TextMemento
{
    public string Text { get; }

    public TextMemento(string text)
    {
        Text = text;
    }
}

// Создатель — текстовый редактор
class TextEditor
{
    private string _text;

    public void Type(string newText)
    {
        _text += newText;
    }

    public void Show()
    {
        Console.WriteLine($"Текущий текст: {_text}");
    }

    public TextMemento Save()
    {
        return new TextMemento(_text);
    }

    public void Restore(TextMemento memento)
    {
        _text = memento.Text;
    }
}

// Опекун — управляет сохранениями
class History
{
    private Stack<TextMemento> _history = new Stack<TextMemento>();

    public void Push(TextMemento memento)
    {
        _history.Push(memento);
    }

    public TextMemento Pop()
    {
        return _history.Pop();
    }
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        var editor = new TextEditor();
        var history = new History();

        editor.Type("Привет, ");
        editor.Show();

        history.Push(editor.Save()); // сохранение состояния

        editor.Type("мир!");
        editor.Show();

        // Откат
        editor.Restore(history.Pop());
        editor.Show();
    }
}
