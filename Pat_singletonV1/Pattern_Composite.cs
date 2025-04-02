using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Пример файловой системы
// Абстрактный базовый класс для файлов и папок
abstract class FileSystemItem
{
    protected string name;

    public FileSystemItem(string name)
    {
        this.name = name;
    }

    public abstract void Display(int depth = 0);
}

// Конкретный класс "Файл"
class File : FileSystemItem
{
    public File(string name) : base(name) { }

    public override void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + " Файл: " + name);
    }
}

// Конкретный класс "Папка", содержащий файлы и другие папки
class Folder : FileSystemItem
{
    private List<FileSystemItem> items = new List<FileSystemItem>();

    public Folder(string name) : base(name) { }

    public void Add(FileSystemItem item)
    {
        items.Add(item);
    }

    public void Remove(FileSystemItem item)
    {
        items.Remove(item);
    }

    public override void Display(int depth = 0)
    {
        Console.WriteLine(new string('-', depth) + " Папка: " + name);
        foreach (var item in items)
        {
            item.Display(depth + 2);
        }
    }
}

// Реализация в основной программе
class Program
{
    static void Main()
    {
        // Создаем файлы
        File file1 = new File("Документ.txt");
        File file2 = new File("Фото.jpg");
        File file3 = new File("Музыка.mp3");

        // Создаем папку и добавляем в нее файлы
        Folder folder1 = new Folder("Моя папка");
        folder1.Add(file1);
        folder1.Add(file2);

        // Создаем еще одну папку с файлами
        Folder folder2 = new Folder("Мои медиафайлы");
        folder2.Add(file3);

        // Вложенная структура (папка в папке)
        Folder rootFolder = new Folder("Корневая папка");
        rootFolder.Add(folder1);
        rootFolder.Add(folder2);

        // Вывод структуры файловой системы
        rootFolder.Display();
    }
}
