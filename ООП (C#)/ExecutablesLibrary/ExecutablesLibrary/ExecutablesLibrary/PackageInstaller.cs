using System;

namespace ExecutablesLibrary
{
    public class PackageInstaller : File, IExecutable
    {

        public static new string Type = "Установщик пакета";

        public string Status { get; set; }

        public PackageInstaller()
        {
            Init();
            Extension = ".msi";
            Status = "Пакет не установлен";
        }
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
        public override void ShowStatus()
        {
            Console.WriteLine("Статус установочного пакета " + Name + Extension + ": " + Status);
        }
    }
}