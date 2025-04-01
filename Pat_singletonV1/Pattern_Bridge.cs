using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Интерфейс устройства
public interface IDevice
{
    void PowerOn();
    void PowerOff();
    void SetVolume(int volume);
}

// Конкретные устройства
public class TV : IDevice
{
    public void PowerOn() => Console.WriteLine("TV включен");
    public void PowerOff() => Console.WriteLine("TV выключен");
    public void SetVolume(int volume) => Console.WriteLine($"TV громкость установлена на {volume}");
}

public class Radio : IDevice
{
    public void PowerOn() => Console.WriteLine("Радио включено");
    public void PowerOff() => Console.WriteLine("Радио выключено");
    public void SetVolume(int volume) => Console.WriteLine($"Радио громкость установлена на {volume}");
}

// Абстракция пульта управления
public abstract class RemoteControl
{
    protected IDevice device;

    public RemoteControl(IDevice device)
    {
        this.device = device;
    }

    public void PowerOn() => device.PowerOn();
    public void PowerOff() => device.PowerOff();
    public void SetVolume(int volume) => device.SetVolume(volume);
}

// Расширенный функционал пульта
public class AdvancedRemote : RemoteControl
{
    public AdvancedRemote(IDevice device) : base(device) { }

    public void Mute()
    {
        Console.WriteLine("Устройство отключено");
        device.SetVolume(0);
    }
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        IDevice tv = new TV();
        RemoteControl tvRemote = new AdvancedRemote(tv);
        tvRemote.PowerOn();
        tvRemote.SetVolume(10);
        ((AdvancedRemote)tvRemote).Mute();
        tvRemote.PowerOff();

        Console.WriteLine();

        IDevice radio = new Radio();
        RemoteControl radioRemote = new AdvancedRemote(radio);
        radioRemote.PowerOn();
        radioRemote.SetVolume(5);
        ((AdvancedRemote)radioRemote).Mute();
        radioRemote.PowerOff();
    }
}
