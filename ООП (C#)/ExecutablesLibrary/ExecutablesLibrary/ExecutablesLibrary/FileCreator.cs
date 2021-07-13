using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExecutablesLibrary
{
    public static class FileCreator
    {
        public static readonly Dictionary<int, Type> FileTypes = new Dictionary<int, Type>
        {
            [1] = typeof(PackageInstaller),
            [2] = typeof(Service),
            [3] = typeof(TaskManager)
        };

        public static readonly Publisher[] Publishers = new Publisher[]
        {
                new Publisher("Microsoft", 1001),
                new Publisher("Apple", 1002),
                new Publisher("IBM", 1003),
                new Publisher("Oracle", 1004),
                new Publisher("GNU", 1005),
                new Publisher("Google", 1006),
                new Publisher("Mozilla Foundation", 1007),
                new Publisher("Intel", 1008),
                new Publisher("AMD", 1009)
        };

        public static List<int> UniqueIds = new List<int>();

        public static File CreateFile(int index)
        {
            Type type = FileTypes[index];
            ConstructorInfo[] ctor = type.GetConstructors();
            return (File)ctor[0].Invoke(new object[0]);
        }

        public static File CreateFile()
        {
            Console.WriteLine("\nОбъект какого класса нужно создать:");
            Console.WriteLine("1 - Установщик пакетов.\n2 - Служба.\n3 - Диспетчер задач.");

            int index = Input.IntInput("Введит число от 1 до 3: ", 1, 3);

            return CreateFile(index);
        }
        
        public static File CreateRandomFile(ref int postfix)
        {
            Random rnd = new Random();
            Type type = FileTypes[rnd.Next(1, 4)];

            var id = rnd.Next(100, 10000);

            while (UniqueIds.Contains(id))
                id = rnd.Next(100, 10000);

            UniqueIds.Add(id);

            return (File)type.GetConstructors()[1].Invoke
                (
                    new object[4] 
                    {
                        type.GetField("Type").GetValue(null).ToString() + "_" + postfix++,
                        rnd.Next(1,50),
                        id,
                        (Publisher)Publishers.ElementAt(rnd.Next(0, Publishers.Count())).Clone()
                    }
                );
        }

        public static File[] CreateFilesArray(int size)
        {
            int postfix = 0;
            return (from _ in Enumerable.Range(0, size)
                    let file = CreateRandomFile(ref postfix)
                    orderby file.Id
                    select file).ToArray();
            //return Enumerable.Range(0, size).Select(_ => FileCreater.CreateRandomFile(ref postfix)).OrderBy(file => file.Id).ToArray();
        }

        public static File[] CreateFilesArray()
        {
            int size = Input.IntInput("Введите количество элементов (от 1 до 100): ", 1, 100);

            return CreateFilesArray(size);
        }

        public static void CleanUniqueIds()
        {
            UniqueIds.Clear();
        }
    }
}