using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patern_SingleTonV1.cs;

class Program
{
    static void Main()
{
    Logger logger1 = Logger.Instance;
    logger1.Log("Первое сообщение");

    Logger logger2 = Logger.Instance;
    logger2.Log("Второе сообщение");

    Console.WriteLine(ReferenceEquals(logger1, logger2)); 
}
}
