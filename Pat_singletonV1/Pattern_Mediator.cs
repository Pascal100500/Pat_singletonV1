using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Пример использования паттерна посредник в реализации чата, где пользователи общаются через посредника
// Интерфейс посредника
public interface IChatMediator
{
    void SendMessage(string message, User user);
    void RegisterUser(User user);
}

//Конкретный посредник
public class ChatRoom : IChatMediator
{
    private List<User> users = new List<User>();

    public void RegisterUser(User user)
    {
        users.Add(user);
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in users)
        {
            if (user != sender)
            {
                user.Receive(message);
            }
        }
    }
}

// Базовый класс участника
public class User
{
    protected IChatMediator mediator;
    public string Name { get; }

    public User(string name, IChatMediator mediator)
    {
        this.Name = name;
        this.mediator = mediator;
        mediator.RegisterUser(this);
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} отправляет сообщение: {message}"); //Сложение строк с использованием {} (не конкатенация)
        mediator.SendMessage(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{Name} получил сообщение: {message}");
    }
}

// Реализация в основной программе
class Program
{
    static void Main(string[] args)
    {
        IChatMediator chatRoom = new ChatRoom();

        User maria = new User("Maria", chatRoom);
        User bob = new User("Bob", chatRoom);
        User charlie = new User("Charlie", chatRoom);

        maria.Send("Привет, ребята!");
        bob.Send("Привет, Alice!");
    }
}
