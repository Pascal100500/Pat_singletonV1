using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Пример использования паттерна посетитель для работы с геометрическими фигурами
// Интерфейс посетителя
interface IVisitor
{
    void VisitCircle(Circle circle);
    void VisitSquare(Square square);
}

// Интерфейс элементов
interface IShape
{
    void Accept(IVisitor visitor);  // Метод для "принятия" посетителя
}

// Конкретный элемент - круг
class Circle : IShape
{
    public double Radius { get; set; } = 5.0;

    public void Accept(IVisitor visitor)
    {
        visitor.VisitCircle(this);
    }
}

// Конкретный элемент - квадрат
class Square : IShape
{
    public double Side { get; set; } = 4.0;

    public void Accept(IVisitor visitor)
    {
        visitor.VisitSquare(this);
    }
}

// Конкретный посетитель - отрисовка фигур
class DrawVisitor : IVisitor
{
    public void VisitCircle(Circle circle)
    {
        Console.WriteLine($"Рисуем круг с радиусом {circle.Radius}");
    }

    public void VisitSquare(Square square)
    {
        Console.WriteLine($"Рисуем квадрат со стороной {square.Side}");
    }
}

// Конкретный посетитель - вычисление площади
class AreaVisitor : IVisitor
{
    public void VisitCircle(Circle circle)
    {
        double area = Math.PI * circle.Radius * circle.Radius;
        Console.WriteLine($"Площадь круга: {area:F2}"); // Форматор F для вывода десятичного числа с 2 цифрами после запятой
    }

    public void VisitSquare(Square square)
    {
        double area = square.Side * square.Side;
        Console.WriteLine($"Площадь квадрата: {area:F2}"); // Форматор F для вывода десятичного числа с 2 цифрами после запятой
    }
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        List<IShape> shapes = new List<IShape>
        {
            new Circle(),
            new Square()
        };

        Console.WriteLine("== Отрисовка фигур ==");
        var drawVisitor = new DrawVisitor();
        foreach (var shape in shapes)
        {
            shape.Accept(drawVisitor);
        }

        Console.WriteLine("\n== Вычисление площади ==");
        var areaVisitor = new AreaVisitor();
        foreach (var shape in shapes)
        {
            shape.Accept(areaVisitor);
        }
    }
}
