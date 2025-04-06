using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Пример использования паттерна итератор для коллекции книг

// Класс книги
class Book
{
    public string Title { get; set; }

    public Book(string title)
    {
        Title = title;
    }
}

// Коллекция книг, реализующая IEnumerable
class Library : IEnumerable<Book>
{
    private List<Book> _books = new List<Book>();

    public void AddBook(Book book) => _books.Add(book);

    // Возвращаем итератор
    public IEnumerator<Book> GetEnumerator()
    {
        foreach (var book in _books)
        {
            yield return book; // ленивый возврат
        }
    }

    // Необходимый метод для IEnumerable
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        var library = new Library();
        library.AddBook(new Book("Властелин колец"));
        library.AddBook(new Book("1984"));
        library.AddBook(new Book("Преступление и наказание"));

        Console.WriteLine("Книги в библиотеке:");

        // Используем foreach — итератор просматривает книги
        foreach (var book in library)
        {
            Console.WriteLine($"- {book.Title}");
        }
    }
}
