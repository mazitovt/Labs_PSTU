using System;

namespace ExecutablesLibrary
{
    public class Service : File, IControlable
    {
        public static new string Type = "Служба";

        public string Status { get; set; } = "Не запущена";

        public Service()
        {
            Init();
            Extension = ".exe";
        }
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
        public override void ShowStatus()
        {
            Console.WriteLine("Статус службы " + Name + Extension + ": " + Status);
        }
    }
}