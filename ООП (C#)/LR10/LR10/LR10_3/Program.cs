//1.Составить иерархию классов в соответствии с вариантом. Во главе иерархии классов одолжен находиться интерфейс, 
//который определяет поведение объектов из иерархии классов (IExecutable). 
//2.Создать массив элементов типа IExecutable и поместить в него экземпляры различных классов иерархии. 
//Выполнить просмотр массива, показать работу методов интерфейса IExecutable.
//3.Реализовать сортировку элементов массива, используя стандартный интерфейс IComparable и метод Sort класса Array.
//4.Реализовать сортировку и поиск элемента в массиве, используя стандартный интерфейс ICompare  и метод Sort класса Array.
//5.Реализовать метод клонирования объектов из интерфейса IClonable. Показать разницу между клонированием и поверхностным копированием объектов.


using LR10;
using System;
using System.Collections;
using System.Collections.Immutable;
using System.Dynamic;
using System.IO;
using System.Reflection;

namespace LR10_3
{
    class Program
    {
        static void Main(string[] args)
        {

            Service adobeCloudService = new Service("Adobe Cloud", 1024, 207, new Publisher {Name = "Adobe", Id = 1007 });
            Service mysqlService = new Service("MySQL Server Service", 204800, 201, new Publisher { Name = "Oracle", Id = 1010 });
            TaskManager taskMngr1 = new TaskManager("Windows Task Manager(1)", 10000, 305, new Publisher { Name = "Microsoft", Id = 1000 });
            TaskManager taskMngr2 = new TaskManager("Linux Task Manager(2)", 105000, 306, new Publisher { Name = "GNU", Id = 1005 });
            PackageInstaller windowsFallUpd = new PackageInstaller("Windows 10 Fall Update 2004", 450000, 402, new Publisher { Name = "Microsoft", Id = 1000 });

            IExecutable[] arrayOfExe = new IExecutable[5];

            arrayOfExe[0] = adobeCloudService;
            arrayOfExe[1] = mysqlService;
            arrayOfExe[2] = taskMngr1;
            arrayOfExe[3] = taskMngr2;
            arrayOfExe[4] = windowsFallUpd;

            Console.WriteLine(" Вызов метода ShowStatus интерфейса IExecutable.\n");
            foreach (var file in arrayOfExe)
                file.ShowStatus();

            Console.WriteLine("\n Массив до сортировки.\n");
            foreach (File file in arrayOfExe)
                file.ShowInfo();

            Array.Sort(arrayOfExe);

            Console.WriteLine("\n Массив после сортировки по РАЗМЕРУ с помощью метода CompareTo.\n");
            foreach (File file in arrayOfExe)
                file.ShowInfo();

            Array.Sort(arrayOfExe, new SortById());

            Console.WriteLine("\n Массив после сортировки по НОМЕРУ с помощью класса SortById.\n");
            foreach (File file in arrayOfExe)
                file.ShowInfo();

            Array.Sort(arrayOfExe, new SortByName());

            Console.WriteLine("\n Массив после сортировки по ИМЕНИ с помощью класса SortByName.\n");
            foreach (File file in arrayOfExe)
                file.ShowInfo();

            Array.Sort(arrayOfExe, new SortBySize());

            Console.WriteLine("\n Массив после сортировки по РАЗМЕРУ с помощью класса SortBySize.\n");
            foreach (File file in arrayOfExe)
                file.ShowInfo();

            // КЛОНИРОВАНИЕ
            TaskManager shallowClone = (TaskManager)taskMngr2.ShallowClone();
            TaskManager fullClone = (TaskManager)taskMngr2.Clone();

            Console.WriteLine("\nКлонирование объекта.\n");

            taskMngr2.ShowInfo();
            fullClone.ShowInfo();
            shallowClone.ShowInfo();

            taskMngr2.Id = 155;
            taskMngr2.Size = 99;
            taskMngr2.Publisher.Name = "Adobe";
            taskMngr2.Publisher.Id = 1007;

            Console.WriteLine("\nОбъекты после внесения изменений в оригинал.");

            Console.WriteLine("\nОригинал");
            taskMngr2.ShowInfo();
            Console.WriteLine("\nПоверхностная копия");
            shallowClone.ShowInfo();
            Console.WriteLine("\nГлубокая копия");
            fullClone.ShowInfo();

        }
    }

    public class Publisher
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public class SortById : IComparer
    {
        int IComparer.Compare(object ob1, object ob2)
        {
            File file1 = (File)ob1;
            File file2 = (File)ob2;
            return file1.Id.CompareTo(file2.Id);
        }

    }
    
    public class SortByName : IComparer
    {
        int IComparer.Compare(object ob1, object ob2)
        {
            File file1 = (File)ob1;
            File file2 = (File)ob2;
            return String.Compare(file1.Name, file2.Name);
        }

    }
    
    public class SortBySize : IComparer
    {
        int IComparer.Compare(object ob1, object ob2)
        {
            File file1 = (File)ob1;
            File file2 = (File)ob2;
            return file1.Size.CompareTo(file2.Size);
        }

    }

    interface IExecutable
    {
        public string Status { get; set; }
        void Run();
        void ShowStatus();
    }

    interface IControlable: IExecutable
    {      
        void Pause();
        void Stop();
    }

    interface IWindowed: IControlable
    {
        void OpenWindow();
        void CloseWindow();
    }

    abstract public class File: IComparable, ICloneable
    {
        public string Extension { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Publisher Publisher { get; set; }
        public int Size { get; set; }

        public object ShallowClone()
        {
            return this.MemberwiseClone();
        }
        public object Clone()
        {

            Publisher p = new Publisher
            {
                Name = this.Publisher.Name,
                Id = this.Publisher.Id
            };

            Type type = this.GetType();
            ConstructorInfo[] ctor = type.GetConstructors();
            var temp = ctor[0].Invoke(new object[] { this.Name, this.Size, this.Id, p});

            return temp;

        }

        public int CompareTo(object obj)
        {
            File file = (File)obj;

            if (Size == file.Size) return 0;
            if (Size > file.Size) return 1;
            else return -1;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"| Name: {Name,-27} | Id: {Id,3} | Size: {Size,10} MB | Publisher : {Publisher.Id}, {Publisher.Name,-10}|");
        }
    }
   
    public class PackageInstaller: File, IExecutable
    {
        public string Status { get; set; }
        public PackageInstaller(string name, int size, int id, Publisher pub)
        {
            Extension = ".msi";
            Id = id;
            Name = name;
            Size = size;
            Status = "Пакет не установлен";
            Publisher = pub;
        }
        public void Run() 
        {
            Console.WriteLine("\nУстанавливаю обновления из " + Name + Extension);
            Status = "Пакет установлен";
        } 
        public void ShowStatus()
        {
            Console.WriteLine("Статус установочного пакета " + Name + Extension + ": " + Status);
        }
    }

    public class Service: File, IControlable
    {
        public string Status { get; set; } = "Не запущена";      
        public Service(string name, int size, int id, Publisher pub)
        {
            Extension = ".exe";
            Name = name;
            Size = size;
            Id = id;
            Publisher = pub;
        }
        public void Pause()
        {
            Console.WriteLine("\nПриостановливаю службу " + Name + Extension);
            Status = "Приостановлена";
        }
        public void Run()
        {
            Console.WriteLine("\nЗапускаю службу " + Name + Extension);
            Status = "Выполняется";
        }
        public void Stop()
        {
            Console.WriteLine("\nОстанавливаю службу " + Name + Extension);
            Status = "Остановлена";
        }
        public void ShowStatus()
        {
            Console.WriteLine("Статус службы " + Name + Extension + ": " + Status);
        }
    }

    public class TaskManager : File, IWindowed
    {
        public string Status { get; set; } = "Не запущен";
        public string Window { get; set; } = "Закрыто";
        public TaskManager(string name, int size, int id, Publisher pub)
        {
            Extension = ".exe";
            Id = id;
            Name = name;
            Size = size;
            Publisher = pub;
        }
        public void CloseWindow()
        {
            Console.WriteLine("Закрываю окно диспетчера задач " + Name);
            Window = "Закрыто";
        }
        public void OpenWindow()
        {
            Console.WriteLine("Открываю окно диспетчера задач " + Name);
            Window = "Открыто";
        }
        public void Pause()
        {
            Console.WriteLine("Приостанавливаю работу диспетчера задач " + Name);
            Status = "Приостановлен";
            Window = "Закрыто";
        }
        public void Run()
        {
            Console.WriteLine("Запускаю диспетчер задач " + Name);
            Status = "Работает";
            Window = "Открыто";
        }
        public void ShowStatus()
        {
            Console.WriteLine($"Статус диспетчера задач {Name}: " + Status);
        }
        public void Stop()
        {
            Console.WriteLine("Останаливаю работу диспетчера задач " + Name);
            Status = "Остановлен";
            Window = "Закрыто";
        }
    }

}

