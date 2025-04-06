using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Пример использования паттерна состояние - музыкальный плеер
// Интерфейс состояния
interface IPlayerState
{
    void PressPlay(MusicPlayer player);
}

// Конкретное состояние: Воспроизведение
class PlayingState : IPlayerState
{
    public void PressPlay(MusicPlayer player)
    {
        Console.WriteLine("Останавливаем воспроизведение...");
        player.SetState(new PausedState());
    }
}

// Конкретное состояние: Пауза
class PausedState : IPlayerState
{
    public void PressPlay(MusicPlayer player)
    {
        Console.WriteLine("Возобновляем воспроизведение...");
        player.SetState(new PlayingState());
    }
}

// Контекст — музыкальный плеер
class MusicPlayer
{
    private IPlayerState _state;

    public MusicPlayer()
    {
        // Изначально в режиме паузы
        _state = new PausedState();
    }

    public void SetState(IPlayerState state)
    {
        _state = state;
    }

    public void PressPlay()
    {
        _state.PressPlay(this);
    }
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        var player = new MusicPlayer();

        player.PressPlay(); // Возобновление воспроизведения
        player.PressPlay(); // Остановка воспроизведения
        player.PressPlay(); // Возобновление воспроизведения
    }
}
