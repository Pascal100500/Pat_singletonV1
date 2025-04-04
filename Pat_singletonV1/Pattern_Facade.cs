using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Реализация паттерна Фасад на примере кофемашины
// Подсистемы
class WaterSystem
{
    public void PumpWater()
    {
        Console.WriteLine("Насос подаёт воду...");
    }
}

class Heater
{
    public void HeatWater()
    {
        Console.WriteLine("Вода нагревается...");
    }
}

class CoffeeGrinder
{
    public void GrindBeans()
    {
        Console.WriteLine("Зёрна перемалываются...");
    }
}

class Brewer
{
    public void Brew()
    {
        Console.WriteLine("Кофе заваривается...");
    }
}

// Фасад
class CoffeeMachine
{
    private WaterSystem waterSystem = new WaterSystem();
    private Heater heater = new Heater();
    private CoffeeGrinder grinder = new CoffeeGrinder();
    private Brewer brewer = new Brewer();

    public void MakeCoffee()
    {
        grinder.GrindBeans();
        waterSystem.PumpWater();
        heater.HeatWater();
        brewer.Brew();
        Console.WriteLine("Кофе готов!");
    }
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        CoffeeMachine coffeeMachine = new CoffeeMachine();
        coffeeMachine.MakeCoffee();  // Клиенту не нужно знать детали
    }
}
