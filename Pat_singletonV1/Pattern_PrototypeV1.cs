using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Абстрактный класс shape
public abstract class Shape
{
    public string Color { get; set; }

    public abstract Shape Clone();

    public abstract void Draw();
}

//Конкретные фигуры
public class Circle : Shape
{
    public int Radius { get; set; }

    public override Shape Clone()
    {
        return new Circle
        {
            Color = this.Color,
            Radius = this.Radius
        };
    }

    public override void Draw()
    {
        Console.WriteLine($"Круг: цвет = {Color}, радиус = {Radius}");
    }
}

public class Square : Shape
{
    public int SideLength { get; set; }

    public override Shape Clone()
    {
        return new Square
        {
            Color = this.Color,
            SideLength = this.SideLength
        };
    }

    public override void Draw()
    {
        Console.WriteLine($"Квадрат: цвет = {Color}, сторона = {SideLength}");
    }
}

//Реализация в основной программе
class Program
{
    static void Main(string[] args)
    {
        // Оригинал — круг
        Circle originalCircle = new Circle
        {
            Color = "Красный",
            Radius = 10
        };
        originalCircle.Draw();

        // Клонируем
        Circle clonedCircle = (Circle)originalCircle.Clone();
        clonedCircle.Color = "Синий";  // Меняем цвет у клона
        clonedCircle.Draw();

        // Оригинал — квадрат
        Square originalSquare = new Square
        {
            Color = "Зелёный",
            SideLength = 5
        };
        originalSquare.Draw();

        // Клонируем
        Square clonedSquare = (Square)originalSquare.Clone();
        clonedSquare.SideLength = 8;  // Меняем длину стороны у клона
        clonedSquare.Draw();

        Console.ReadLine();
    }
}