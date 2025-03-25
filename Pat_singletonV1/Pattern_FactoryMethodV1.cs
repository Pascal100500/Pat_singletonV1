using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Vehicle
{
    public abstract void Drive();
}
public class Car : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Едем на машине ");
    }
}

public class Bike : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("едем на велосипеде ");
    }
}

public class Motorcycle : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Едем на мотоцикле ");
    }
}

//Создание абстрактной фабрики для создания транспортных средств
public abstract class VehicleFactory
{
    public abstract Vehicle CreateVehicle();
}

//Создание конкретных фабрик для каждого транспорта 
public class CarFactory : VehicleFactory
{
    public override Vehicle CreateVehicle()
    {
        return new Car();
    }
}

public class BikeFactory : VehicleFactory
{
    public override Vehicle CreateVehicle()
    {
        return new Bike();
    }
}

public class MotorcycleFactory : VehicleFactory
{
    public override Vehicle CreateVehicle()
    {
        return new Motorcycle();
    }
}

//Реализация основной программы
class Program
{
    static void Main(string[] args)
    {
        VehicleFactory factory;

        // Если пользователь выбрал "мотоцикл"
        factory = new MotorcycleFactory();

        Vehicle vehicle = factory.CreateVehicle();
        vehicle.Drive();
    }
}