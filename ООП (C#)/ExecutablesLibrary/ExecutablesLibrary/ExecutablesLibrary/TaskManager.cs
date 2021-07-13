using System;

namespace ExecutablesLibrary
{
    public class TaskManager : File, IWindowed
    {
        public static new string Type = "Диспетчер задач";
        public string Status { get; set; } = "Не запущен";
        public string Window { get; set; } = "Закрыто";

        public TaskManager()
        {
            Init();
            Extension = ".exe";
        }
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
        public override void ShowStatus()
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