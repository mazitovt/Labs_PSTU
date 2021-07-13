using System;
using ExecutablesLibrary;
using System.Linq;
using System.Collections.Generic;

namespace LR13
{
    class LR13class
    {

        private static Dictionary<string, MyNewCollection<File>> _collections = new Dictionary<string, MyNewCollection<File>>();
        private static Dictionary<string, Journal> _journals = new Dictionary<string, Journal>();

        static void Main(string[] args) => Menu();
        //{

            //var col = new MyNewCollection<File>("кол1", FileCreator.CreateFilesArray(10));

            //foreach(var file in col)
            //    Console.WriteLine(file);

            //Console.WriteLine();

            //var res = from file in col
            //          where file.Size < 250000
            //          select file;

            //foreach (var file in res)
            //    Console.WriteLine(file);

            //Menu();
        //}

        //{
        //    MyNewCollection<File> Collection1 = new MyNewCollection<File>("Коллекция_1", FileCreator.CreateFilesArray());
        //    MyNewCollection<File> Collection2 = new MyNewCollection<File>("Коллекция_2", FileCreator.CreateFilesArray());

        //    //Collection1 = FillCollectionWithFiles(Collection1, 10);
        //    //Collection2 = FillCollectionWithFiles(Collection2, 10);

        //    Journal Journal1 = new Journal() { Name = "Журнал_1" };
        //    Journal Journal2 = new Journal() { Name = "Журнал_2" };

        //    Collection1.CollectionCountChanged += Journal1.CollectionCountChanged;
        //    Collection2.CollectionReferenceChanged += Journal1.CollectionReferenceChanged;

        //    Collection1.CollectionReferenceChanged += Journal2.CollectionReferenceChanged;
        //    Collection2.CollectionReferenceChanged += Journal2.CollectionReferenceChanged;        

        //    DemoAddElements(Collection1);
        //    DemoAddElements(Collection2);

        //    //PrintCollection(col);

        //    //foreach (var _ in Enumerable.Range(1, 10))
        //    //{
        //    //    if (col.Remove(4))
        //    //        Console.WriteLine("Удалил с 4");
        //    //    else
        //    //        Console.WriteLine("не удалил");
        //    //}

        //    try
        //    {
        //        Collection1[3] = new PackageInstaller("TEST", 999, 2342, new Publisher("TestPP", 324));

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    try
        //    {
        //        Collection2[6] = new PackageInstaller("TEST", 999, 2342, new Publisher("TestPP", 324));

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    PrintCollection(Collection1);
        //    PrintCollection(Collection2);

        //    Collection1.Remove(7);
        //    Collection2.Remove(3);

        //    PrintCollection(Collection1);
        //    PrintCollection(Collection2);

        //    try
        //    {
        //        Collection2[0] = new PackageInstaller("TEST", 999, 2342, new Publisher("TestPP", 324));

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    PrintJournal(Journal1);
        //    PrintJournal(Journal2);

        //}
       
        static void Menu()
        {
            int choice;
            bool exit = false, flag;
            while (!exit)
            {
                Console.WriteLine(new string('-', 100));
                ShowCollections(_collections, "Коллекции:");
                Console.WriteLine();
                ShowJournals(_journals, "Журналы:");
                Console.WriteLine(new string('-', 100));
                Console.WriteLine();
                Console.WriteLine(
 @"Меню
0. Выход
1. Создать коллекцию.
2. Добавить элемент.
3. Добавить несколько элементов (генератор).
4. Удалить элемент по индексу.
5. Получить элемент по индексу.
6. Присвоить элемент по индексу.
7. Вывести элементы коллекции.
8. Создать журнал.
9. Подписать журнал на события.
10. Вывести содержание журнала.
");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(0 <= choice && choice <= 10) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(0 <= choice && choice <= 10) || !flag);

                switch (choice)
                {
                    case 1:
                        var c_pair = CreateCollection();
                        _collections.Add(c_pair.name, c_pair.collection); 
                        break;
                    case 2: AddFile(); break;
                    case 3: AddManyFiles(); break;
                    case 4: RemoveAtIndex(); break;
                    case 5: GetElementByIndex(); break;
                    case 6: SetElementByIndex(); break;
                    case 7: PrintCollection(ChooseCollection()); break;
                    case 8:
                        var j_pair = CreateJournal();
                        _journals.Add(j_pair.name, j_pair.journal);
                        break;
                    case 9: SubscribeJournal(); break;
                    case 10: PrintJournal(ChooseJournal()); break;

                    case 0: exit = true; break;
                }
            }
            Console.WriteLine("\nЗавершение работы программы");
        }


        //----------МЕТОДЫ ДЛЯ РАБОТЫ С КОЛЛЕКЦИЯМИ----------
        private static void ShowCollections(Dictionary<string, MyNewCollection<File>> collections, string msg)
        {
            Console.WriteLine(msg);
            int count = 0;
            foreach (var pair in collections)
            {
                Console.WriteLine($"[{count++}]: {pair.Key}, количество элементов: {pair.Value.Count}");
            }
        }
        
        private static void SetElementByIndex()
        {
            var file = FileCreator.CreateFile();

            var collection = ChooseCollection();

            PrintCollection(collection);

            Console.WriteLine("\nВ какую позицию сохранить новый файл.");

            int index = Input.IntInput($"Введите индекс (от -100 до {collection.Count + 100}): ", -100, collection.Count + 100);

            try
            {
                collection[index] = file;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void GetElementByIndex()
        {
            var collection = ChooseCollection();

            PrintCollection(collection);

            int index = Input.IntInput($"Введите индекс (от -100 до {collection.Count + 100}): ", -100, collection.Count + 100);

            try
            {
                Console.WriteLine(collection[index]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }          
        }

        private static void PrintCollection(MyNewCollection<File> collection)
        {
            int count = 0;

            Console.WriteLine($"\nСодержание коллекции '{collection.Name}':");

            foreach (var file in collection)
            {
                Console.WriteLine($"{$"[{count++}]", 7}: {file}");
            }
        }
      
        private static void RemoveAtIndex()
        {
            var collection = ChooseCollection();

            if (collection.Count == 0)
            {
                Console.WriteLine("\nОШИБКА! Коллекция пуста.");
                return;
            }

            PrintCollection(collection);
            
            int index = Input.IntInput($"Введите индекс для удаления (от 0 до {collection.Count - 1}): ", 0, collection.Count - 1);

            if (collection.Remove(index))
                Console.WriteLine("\nФайл удален.");
            else
                Console.WriteLine("\nФайл не удален.");
        }

        private static MyNewCollection<File> ChooseCollection()
        {
            ShowCollections(_collections, "\nКоллекции:");

            int index = Input.IntInput($"Введите номер колекции (от 0 до {_collections.Count - 1 }): ", 0, _collections.Count - 1 );

            return _collections.ElementAt(index).Value;
        }

        private static void AddManyFiles()
        {
            var files = FileCreator.CreateFilesArray();

            var collection = ChooseCollection();

            collection.AddMany(files);
        }

        private static void AddFile()
        {
            var file = FileCreator.CreateFile();

            Console.WriteLine("\nВ какую коллекцию добавить элемент.");

            var collection = ChooseCollection();

            collection.Add(file);
        }

        private static (string name, MyNewCollection<File> collection) CreateCollection()
        {
            Console.WriteLine("\nЗадайте имя коллекции: ");

            var name = Console.ReadLine();

            return (name, new MyNewCollection<File>(name, FileCreator.CreateFilesArray()));
        }


        //----------МЕТОДЫ ДЛЯ РАБОТЫ С ЖУРНАЛАМИ----------
        private static void ShowJournals(Dictionary<string, Journal> journals, string msg)
        {
            Console.WriteLine(msg);
            int count = 0;
            foreach (var pair in journals)
            {
                Console.WriteLine($"[{count++}]: {pair.Key}, количество записей: {pair.Value.Count}");
            }
        }
        
        private static void PrintJournal(Journal journal)
        {
            int count = 0;

            Console.WriteLine($"\nСодержание журнала '{journal.Name}':");

            foreach (var rec in journal)
                Console.WriteLine($"\nЗапись [{count++}]: {rec}");
        }

        private static Journal ChooseJournal()
        {
            ShowJournals(_journals, "\nЖурналы:");

            int index = Input.IntInput($"Введите номер колекции (от 0 до {_journals.Count - 1}): ", 0, _journals.Count - 1);

            return _journals.ElementAt(index).Value;
        }

        private static (string name, Journal journal) CreateJournal()
        {
            Console.WriteLine("\nЗадайте имя журнала: ");

            var name = Console.ReadLine();

            return (name, new Journal() { Name = name });
        }
        
        private static void SubscribeJournal()
        {
            Console.WriteLine("\nВыберите коллекцию, журнал и событие, на которое нужно подписаться.");

            //var collection = ChooseCollection();
            //var journal = ChooseJournal();

            (var collection, var journal) = (ChooseCollection(), ChooseJournal());

            Console.WriteLine("\n0. CollectionCountChanged\n1. CollectionReferenceChanged.\n");

            int choice = Input.IntInput("Выш выбор (от 0 до 1): ", 0, 1);

            switch (choice)
            {
                case 0: collection.CollectionCountChanged += journal.CollectionCountChanged; break;
                case 1: collection.CollectionReferenceChanged += journal.CollectionReferenceChanged; break;
            }

            Console.WriteLine($"\nЖурнал '{journal.Name}' подписан на событие '{ choice switch {0 => "CollectionCountChanged", 1 => "CollectionReferenceChanged" } }' коллекции '{collection.Name}'");
        }


        //----------МЕТОДЫ ДЛЯ ДЕМОНСТРАЦИИ РАБОТЫ----------
        static void ShowEntities(IDictionary<string, object> entity, string msg)
        {
            Console.WriteLine(msg);
            int count = 0;
            foreach (var pair in entity)
            {
                Console.WriteLine($"[{count++}]: {pair.Key}");
            }
        }
        private static void DemoAddElements(MyNewCollection<File> col) =>  col.Add(FileCreator.CreateFile());
        private static void DemoIndexer(MyNewCollection<File> col)
        {
            Console.WriteLine(col[0]);
            Console.WriteLine(col[1]);
            Console.WriteLine(col[2]);
            try
            {
                Console.WriteLine(col[-1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine(col[4]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //public static MyNewCollection<File> FillCollectionWithFiles(MyNewCollection<File> col,int capacity)
        //{
        //    Dictionary<int, Type> FileTypes = new Dictionary<int, Type>
        //    {
        //        [1] = typeof(PackageInstaller),
        //        [2] = typeof(Service),
        //        [3] = typeof(TaskManager)
        //    };

        //    Publisher[] Publishers = new Publisher[]
        //    {
        //        new Publisher("Microsoft", 1001),
        //        new Publisher("Apple", 1002),
        //        new Publisher("IBM", 1003),
        //        new Publisher("Oracle", 1004),
        //        new Publisher("GNU", 1005),
        //        new Publisher("Google", 1006),
        //        new Publisher("Mozilla Foundation", 1007),
        //        new Publisher("Intel", 1008),
        //        new Publisher("AMD", 1009)
        //    };

        //    Random rnd = new Random();
        //    int postfix = 1;

        //    foreach (var _ in Enumerable.Range(0, capacity))
        //    {
        //        Type type = FileTypes[rnd.Next(1, 4)];
        //        var file = (File)type.GetConstructors()[1].Invoke(new object[4] {
        //            type.GetField("Type").GetValue(null).ToString() + "_" + postfix.ToString(),
        //            rnd.Next(0,500000),
        //            rnd.Next(100,1000),
        //            Publishers.ElementAt(rnd.Next(0, Publishers.Count()))
        //        });
        //        postfix++;
        //        col.Add(file);
        //    }

        //    return col;
        //}
    }
}
