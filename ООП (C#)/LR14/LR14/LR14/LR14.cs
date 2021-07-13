using System;
using System.Collections.Generic;
using ExecutablesLibrary;
using System.Linq;
using LR13;
using ListExtensionMethods;


namespace LR14
{
    class ClassLR14
    {
        //public static readonly Dictionary<int, Type> FileTypes = new Dictionary<int, Type>
        //{
        //    [1] = typeof(PackageInstaller),
        //    [2] = typeof(Service),
        //    [3] = typeof(TaskManager)
        //};
        //
        //public static Publisher[] Publishers = {
        //    new Publisher("Microsoft", 1001),
        //    new Publisher("Apple", 1002),
        //    new Publisher("IBM", 1003),
        //    new Publisher("Oracle", 1004),
        //    new Publisher("GNU", 1005),
        //    new Publisher("Google", 1006),
        //    new Publisher("Mozilla Foundation", 1007),
        //    new Publisher("Intel", 1008),
        //    new Publisher("AMD", 1009)
        //};
        //
        //public static List<Dictionary<string, File>> MyCollection = new List<Dictionary<string, File>>();

        public static List<MyNewCollection<File>> listOfCollections = new();

        static void Main(string[] args) => Menu();

        static void Menu()
        {
            FillMyNewCollection();

            int choice;
            bool exit = false, flag;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine(
@"Меню
0. Выход
1. Запрос 1. Найти все файлы заданного издателя отсортированные по Id.
2. Запрос 2. Посчитать количество файлов, меньше заданного размера.
3. Запрос 3. Вывести издателей, которые есть в обоих коллекциях.
4. Запрос 4. Средний размер файлов заданного типа.
5. Запрос 5. Вывести информацию о всех издателях и его файлах.
6. Распечатать коллекции.
");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(0 <= choice && choice <= 6) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(0 <= choice && choice <= 6) || !flag);

                switch (choice)
                {
                    case 1: Query1(); break;
                    case 2: Query2(); break;
                    case 3: Query3(); break;
                    case 4: Query4(); break;
                    case 5: Query5(); break;
                    case 6: PrintMyNewCollection(); break;

                    case 0: exit = true; break;
                }
            }
            Console.WriteLine("\nЗавершение работы программы");
        }

        static void FillMyNewCollection()
        {
            Console.WriteLine("\nЗаполнение коллекций.");

            var size = ConsoleInput("Введите размер коллекции (от 1 до 100): ", 1, 100);
            var numberOfCollections = ConsoleInput("Введите количество коллекций (от 1 до 10): ", 1, 10);
            var postfix = 0;

            listOfCollections = Enumerable.Range(1, numberOfCollections).Select(num => new MyNewCollection<File>("Коллекция_" + num, CreateMyNewCollection(size, ref postfix))).ToList();
        }

        static IEnumerable<File> CreateMyNewCollection(int size, ref int postfix)
        {
            var index = postfix;
            postfix += size;

            return Enumerable.Range(1, size).Select(_ => FileCreator.CreateRandomFile(ref index));
        }

        static void PrintCollections()
        {
            Console.WriteLine();
            int count = 0;
            foreach (var collection in listOfCollections)
            {
                Console.WriteLine($"[{count++}]: {collection.Name}, количество элементов: {collection.Count}");
            }
        }

        static void PrintMyNewCollection()
        {
            foreach (var collection in listOfCollections)
            {
                int count = 0;

                Console.WriteLine($"\nСодержание коллекции '{collection.Name}':");
                Console.WriteLine(new string('-', 150));

                foreach (var file in collection)
                {
                    Console.WriteLine($"{$"[{count++}]",5}: {file}");
                }
                Console.WriteLine(new string('-', 150));

            }
        }
             
        static void Query1()
        {
            Console.WriteLine("Все издатели файлов:");

            foreach(var pair in FileCreator.Publishers.Select((v, i) => (v, i)))
                Console.WriteLine($"{pair.i}: {pair.v}");

            int index = ConsoleInput($"Введите число (от 0 до {FileCreator.Publishers.Count() - 1}): ", 0, FileCreator.Publishers.Count() - 1);

            var publisher = FileCreator.Publishers[index];

            var filesFromLINQ = listOfCollections.PublisherFilesLINQ(publisher);
            var filesFromExtMethods = listOfCollections.PublisherFilesExtensionMethod(publisher);

            foreach (var result in new [] {filesFromLINQ, filesFromExtMethods})
            {
                if (!result.Any())
                {
                    Console.WriteLine($"\nУ издателя {publisher.Name} нет файлов.");
                    return;
                }

                Console.WriteLine($"\nВсе файлы издателя {publisher.Name} из всех коллекций отсортированные по Id:");

                foreach (var file in result)
                    Console.WriteLine(file);
            }

        }
        
        //static IEnumerable<File> MyNewPublisherFiles(Publisher p)
        //{
        //    return from file in listOfCollections.SelectMany(collection => collection)
        //           where file.Publisher.Id == p.Id
        //           orderby file.Id
        //           select file;
        //}
        
        //static IEnumerable<File> PublisherFiles(Publisher p)
        //{
        //    return from file in MyCollection.SelectMany(dict => dict.Values) 
        //           where file.Publisher.Id == p.Id 
        //           orderby file.Id 
        //           select file;
        //}


        static void Query2() 
        {
            var size = ConsoleInput($"Введите число (от 0 до 500000): ", 0, 500000);
            //var count = CountFilesLessSize(size);

            var countLINQ = listOfCollections.CountLessThanSizeLINQ(size);
            var countExtMethod = listOfCollections.CountLessThanSizeExtensionMethod(size);

            Console.WriteLine("С помощью LINQ.");
            Console.WriteLine($"В коллекции {countLINQ} {(countLINQ % 10 > 0 && countLINQ % 10 < 5 ? countLINQ % 10 == 1 ? "элемент" : "элемента" : "элементов")} меньше {size} MB.");
            
            Console.WriteLine("С помощью методов расширения.");
            Console.WriteLine($"В коллекции {countExtMethod} {(countExtMethod % 10 > 0 && countExtMethod % 10 < 5 ? countExtMethod % 10 == 1 ? "элемент" : "элемента" : "элементов")} меньше {size} MB.");
        }
        
        //static int MyNewCountFilesLessSize(int size)
        //{
        //    return listOfCollections.SelectMany(collection => collection).Where(file => file.Size < size).Count();
        //}
        
        //static int CountFilesLessSize(int size)
        //{
        //    return MyCollection.SelectMany(dict => dict.Values).Where(file => file.Size < size).Count();
        //}


        static void Query3()
        {
            Console.WriteLine("Выберите первую коллекцию.");
            PrintCollections();

            int index1 = ConsoleInput($"Введите число (от 0 до {listOfCollections.Count - 1}): ", 0, listOfCollections.Count - 1);

            Console.WriteLine("Выберите вторую коллекцию.");
            PrintCollections();

            int index2 = ConsoleInput($"Введите число (от 0 до {listOfCollections.Count - 1}): ", 0, listOfCollections.Count - 1);

            //var publishers = IntersectPublishers(index1, index2);

            var publishersLINQ = listOfCollections.IntersectPublishersLINQ(index1, index2);
            var publishersExtMethod = listOfCollections.IntersectPublishersExtensionMethod(index1, index2);

            foreach (var publishers in new[] { publishersLINQ, publishersExtMethod })
            {
                if (!publishers.Any())
                {
                    Console.WriteLine($"\nНет издателей, которые есть в обоих коллекциях.");
                    return;
                }

                Console.WriteLine($"Издатели, которые есть в обоих коллекциях: { string.Join(", ", publishers) }");
            }
        }
        
        //static IEnumerable<string> MyNewIntersectPublishers(int index1, int index2)
        //{
        //    return listOfCollections[index1]
        //        .Select(file => file.Publisher)
        //        .Intersect(listOfCollections[index2].Select(file => file.Publisher), new PublisherComp())
        //        .Select(pub => pub.Name);
        //}
        
        //static IEnumerable<string> IntersectPublishers(int index1, int index2)
        //{
        //    return MyCollection[index1].Values
        //        .Select(file => file.Publisher)
        //        .Intersect(MyCollection[index2].Values.Select(file => file.Publisher), new PublisherComp())
        //        .Select(pub => pub.Name);
        //}


        static void Query4()
        {
            Console.WriteLine("Выберите тип файла:");
            foreach(var pair in FileCreator.FileTypes)
                Console.WriteLine($" {pair.Key} - {pair.Value.GetField("Type").GetValue(null)}");

            int key = ConsoleInput($"Введите число (от 0 до {FileCreator.FileTypes.Count}): ", 1, FileCreator.FileTypes.Count);

            var type = FileCreator.FileTypes[key];

            //var avgSize = AvgFileSizeByType(type);

            var avgSizeLINQ = listOfCollections.AvgFileSizeByTypeLINQ(type);
            var avgSizeExtMethod = listOfCollections.AvgFileSizeByTypeExtensionMethod(type);

            foreach (var avgSize in new[] { avgSizeLINQ, avgSizeExtMethod })
            {
                if (avgSize == 0)
                {
                    Console.WriteLine("\nНет файлов такого типа.");
                    return;
                }

                Console.WriteLine($"Средний размер файлов типа '{type.GetField("Type").GetValue(null)}' по всем коллекциям: {Math.Round(avgSize)} Mb");
            }
        }
       
        //static double MyNewAvgFileSizeByType(Type type)
        //{
        //    try
        //    {
        //        return listOfCollections
        //            .SelectMany(collection => collection)
        //            .Where(file => type.IsInstanceOfType(file))
        //            //.OfType<>()
        //            .Select(file => file.Size).Average();
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}
        
        //static double AvgFileSizeByType(Type type)
        //{
        //    try
        //    {
        //        return MyCollection
        //            .SelectMany(dict => dict.Values)
        //            .Where(file => type.IsInstanceOfType(file))
        //            //.OfType<>()
        //            .Select(file => file.Size).Average();
        //    } catch
        //    {
        //        return 0;
        //    }
        //}


        static void Query5()
        {
            var padding = new string('-', 30);

            Console.WriteLine();
            Console.WriteLine(padding + " С помощью методов расширения " + padding);

            foreach (var group in listOfCollections.FilesByPublishersExtensionMethod())
            {
                Console.WriteLine();
                Console.WriteLine($"Издатель: {group.Key}, количество файлов: {group.Count()}");

                foreach (var file in group)
                    Console.WriteLine(file);
            }

            Console.WriteLine();
            Console.WriteLine(padding + " С помощью LINQ " + padding);

            foreach (var group in listOfCollections.FilesByPublishersLINQ())
            {
                Console.WriteLine();
                Console.WriteLine($"Издатель: {FileCreator.Publishers.Where(pub => pub.Id == group.Key).FirstOrDefault()}, количество файлов: {group.Count()}");

                foreach (var file in group)
                    Console.WriteLine(file);
            }
        }
        
        //static IOrderedEnumerable<IGrouping<int, File>> MyNewPublishersFilesGroups()
        //{
        //    return from collection in listOfCollections
        //           from file in collection
        //           group file by file.Publisher.Id into g
        //           orderby g.Key
        //           select g;
        //}
        
        //static IOrderedEnumerable<IGrouping<int, File>> PublishersFilesGroups()
        //{
        //    return from dict in MyCollection
        //           from file in dict.Values
        //           group file by file.Publisher.Id into g
        //           orderby g.Key
        //           select g;
        //}
           

        static int ConsoleInput(string msg, int beg, int end)
        {
            bool flag;
            int elem = 0;

            do
            {
                flag = false;
                Console.WriteLine();
                Console.Write(msg);
                try
                {
                    elem = Convert.ToInt32(Console.ReadLine());
                    if (elem < beg || elem > end) throw new IndexOutOfRangeException();
                }
                catch
                {
                    flag = true;
                    Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                }
            } while (flag);

            return elem;
        }
    }
}