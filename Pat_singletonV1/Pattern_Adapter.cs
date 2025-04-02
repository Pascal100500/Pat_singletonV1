using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Реализация пттерна Адаптер на примере зарядных устройств для телефона
// Существующий класс (старый зарядник)
class OldCharger
{
    public void ChargeOldDevice()
    {
        Console.WriteLine("Зарядка устройства через старый разъем.");
    }
}

// Новый интерфейс для современных зарядных устройств
interface IModernCharger
{
    void Charge();
}

// Адаптер, который позволяет старому заряднику работать с новым интерфейсом
class ChargerAdapter : IModernCharger
{
    private OldCharger _oldCharger;

    public ChargerAdapter(OldCharger oldCharger)
    {
        _oldCharger = oldCharger;
    }

    public void Charge()
    {
        Console.WriteLine("Используем адаптер...");
        _oldCharger.ChargeOldDevice();
    }
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        OldCharger oldCharger = new OldCharger();
        IModernCharger adapter = new ChargerAdapter(oldCharger);

        Console.WriteLine("Подключаем новое устройство к старому заряднику через адаптер:");
        adapter.Charge();
    }
}