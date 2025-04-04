using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Пример использования паттерна Интерпретатор для вычисления арифмитических выражений
//Интерфейс выражения
interface IExpression
{
    int Interpret();
}

//Конкретные выражения
class NumberExpression : IExpression
{
    private int number;

    public NumberExpression(int number)
    {
        this.number = number;
    }

    public int Interpret()
    {
        return number;
    }
}

//Сложение
class AddExpression : IExpression
{
    private IExpression left;
    private IExpression right;

    public AddExpression(IExpression left, IExpression right)
    {
        this.left = left;
        this.right = right;
    }

    public int Interpret()
    {
        return left.Interpret() + right.Interpret();
    }
}

//Вычитание
class SubtractExpression : IExpression
{
    private IExpression left;
    private IExpression right;

    public SubtractExpression(IExpression left, IExpression right)
    {
        this.left = left;
        this.right = right;
    }

    public int Interpret()
    {
        return left.Interpret() - right.Interpret();
    }
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        // Пример выражения: (5 + 3) - 2
        IExpression expr = new SubtractExpression(
            new AddExpression(
                new NumberExpression(5),
                new NumberExpression(3)
            ),
            new NumberExpression(2)
        );

        int result = expr.Interpret();
        Console.WriteLine("Результат: " + result);  // Вывод результата - 6
    }
}
