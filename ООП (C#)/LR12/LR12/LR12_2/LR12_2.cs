using System;
using System.Collections;
using System.Linq;
using ExecutablesLibrary;


// Возможно реализовать ICollection

namespace LR12_2
{
    class LR12_2class{

        static void Main(string[] args) => Menu();

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

        static object ConsoleInput2(Type type, string msg, int beg = 0, int end = 0)
        {
            bool flag;
            int elem = 0;

            if (type == typeof(int))
            {
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
            }

            if (type == typeof(string))
            {
                Console.WriteLine();
                Console.Write(msg);
                return Console.ReadLine();
            }

            return elem;
        }

        static void Menu()
        {
            var collection = new MyCollection<File>();

            int choice;
            bool exit = false, flag;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine(
@"Меню
0. Выход
1. Создать коллекцию.
2. Количество элементов в коллекции.
3. Добавить элемент.
4. Добавить несколько элементов.
5. Удалить элемент (по индексу).
6. Поиск элемента в коллекции (первое вхождение).
7. Вывести все элементы. 
8  Выполнить поверхностное копирование.
9. Выполнить глубокое копирование.
10. Очистить коллекцию.
");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(0 <= choice && choice <= 11) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(0 <= choice && choice <= 11) || !flag);

                if ((collection.Count == 0 && !(choice >= 5 && choice <= 9)) || collection.Count != 0)
                {
                    switch (choice)
                    {
                        case 1: collection = CreateCollection(); break;
                        case 2: CountElements(collection); break;
                        case 3: AddFile(collection); break;
                        case 4: AddManyFiles(collection); break;
                        case 5: RemoveFile(collection); break;
                        case 6: FindFile(collection); break;
                        case 7: Print(collection); break;
                        case 8: DemoShallowCopy(collection); break;
                        case 9: DemoDeepCopy(collection); break;
                        case 10: Delete(collection); break;
                        case 11: collection.PrintWithNextAndPrev(); break;

                        case 0: exit = true; break;
                    }
                }
                else
                {
                    Console.WriteLine("Коллекция пуста!");
                }
            }
            Console.WriteLine("\nЗавершение работы программы");
        }


        private static MyCollection<File> CreateCollection()
        {
            MyCollection<File> newCol = new MyCollection<File>();

            foreach (var file in FileCreator.CreateFilesArray())
                newCol.Add(file);

            return newCol;
        }

        private static void CountElements(MyCollection<File> col) => Console.WriteLine($"\nКоличество элементов в коллекции: {col.Count}");

        private static void AddFile(MyCollection<File> col)
        {
            var file = FileCreator.CreateFile();

            col.Add(file);
        }

        private static void AddManyFiles(MyCollection<File> col) => col.AddMany(FileCreator.CreateFilesArray());

        private static void RemoveFile(MyCollection<File> collection)
        {
            int count = -1;

            foreach (var file in collection)
                Console.WriteLine($"{$"[{++count}]",6}: {file}");

            int index = ConsoleInput($"Введите индекс элемента (от 0 до {count}):", 0, count);

            try
            {
                if (collection.Remove(index))
                {
                    Console.WriteLine("\nФайл удален.");
                    return;
                }

                Console.WriteLine("\nВыход за пределы индекса коллекции.");
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        private static void FindFile(MyCollection<File> col)
        {
            if (FindFile(col,out File file))
            {
                Console.WriteLine($"\nФайл найден: {file}");
                return;
            }

            Console.WriteLine("\nФайл не найден.");
        }       
        private static bool FindFile(MyCollection<File> col, out File file)
        {
            static Predicate<File> FindId()
            {
                int id = ConsoleInput("Введите Id файла от 100 до 9999: ", 100, 9999);

                return file => file.Id == id;
            }

            static Predicate<File> FindSize()
            {
                int size = ConsoleInput("Введите размер файла от 0 до 500000: ", 0, 500000);

                return file => file.Size == size;
            }

            static Predicate<File> FindName()
            {
                string name = (string)ConsoleInput2(typeof(string), "Введите имя файла: ");

                return file => file.Name == name;
            }

            Console.WriteLine("\nВыберите поле, по которому производить поиск:\n 1 - ИД\n 2 - Размер\n 3 - Имя");

            var predicate = ConsoleInput("Введите число от 1 до 3: ", 1, 3) switch
            {
                1 => FindId(),
                2 => FindSize(),
                3 => FindName(),
                //_ => throw new NotImplementedException()
            };

            if (col.Find(predicate, out file))
                return true;
            return false;
        }

        private static void DemoShallowCopy(MyCollection<File> collection)
        {
            MyCollection<File> newcol = collection.Shallowclone();

            Console.WriteLine("\nИсходная коллекция.");
            Print(collection);
            Console.WriteLine("\nСкопированная коллекция.");
            Print(newcol);

            Console.WriteLine("\nВ исходной коллекции увеличим размер каждого файла в 2 раза и изменим имя издателя.");
            foreach (var file in collection)
            {
                file.Size *= 2;
                file.Publisher.Name += "_123";
            }

            Console.WriteLine("\nИсходная коллекция.");
            Print(collection);
            Console.WriteLine("\nСкопированная коллекция.");
            Print(newcol);
        }

        private static void DemoDeepCopy(MyCollection<File> collection)
        {
            var newcol = collection.Clone();

            Console.WriteLine("\nИсходная коллекция.");
            Print(collection);
            Console.WriteLine("\nСкопированная коллекция.");
            Print(newcol);

            Console.WriteLine("\nВ исходной коллекции увеличим размер каждого файла в 2 раза и изменим имя издателя.");
            foreach (var file in collection)
            {
                file.Size *= 2;
                file.Publisher.Name += "_123";
            }

            Console.WriteLine("\nИсходная коллекция.");
            Print(collection);
            Console.WriteLine("\nСкопированная коллекция.");
            Print(newcol);
        }

        private static void Print(MyCollection<File> collection)
        {
            Console.WriteLine("\nЭлементы коллекции:");

            foreach (var file in collection)
                Console.WriteLine(file);

            IEnumerable temp = collection;

            foreach (var t in temp)
                Console.WriteLine(t);

        }

        private static void Delete(MyCollection<File> collection)
        {
            collection.DeleteCollection();

            Console.WriteLine("\nКоллекция очищена.");
        }
        
        
        private static void Test()
        {
            MyCollection<File> collection = new MyCollection<File>();

            foreach (var i in Enumerable.Range(1, 5))
                collection.Add(new PackageInstaller("Adobe Acrobat 2020", 9000 + i, 200 + i, new Publisher("Adobe", 1000 + i)));

            Print(collection);
            Console.WriteLine();
            foreach (var file in collection)
            Console.WriteLine(file);

            //if (collection.Remove(new PackageInstaller("Adobe Acrobat 2020", 9000 + 2, 2200 + 2, new Publisher("Adobe", 1000 + 2))))
            //    Console.WriteLine("Удалил объект");

            //Print(collection);

            //if (collection.Remove(new PackageInstaller("Adobe Acrobat 2020", 9000 + 5, 2200 + 5, new Publisher("Adobe", 1000 + 5))))
            //    Console.WriteLine("Удалил объект");

            //if (collection.Remove(new PackageInstaller("Adobe Acrobat 2020", 9000 + 5, 2200 + 5, new Publisher("Adobe", 1000 + 5))))
            //    Console.WriteLine("Удалил объект");
            //else
            //    Console.WriteLine("Не удалил объект");

            //Print(collection);


            //if (collection.Remove(new PackageInstaller("Adobe Acrobat 2020", 9000 + 1, 2200 + 1, new Publisher("Adobe", 1000 + 1))))
            //    Console.WriteLine("Удалил объект");
            //else
            //    Console.WriteLine("Не удалил объект");

            //Print(collection);


            //collection.Add(new PackageInstaller("Adobe Acrobat 2020", 9000 + 10, 2200 + 10, new Publisher("Adobe", 1000 + 10)));

            //Print(collection);

            //if (collection.RemoveMany(new File[] {
            //    new PackageInstaller("Adobe Acrobat 2020", 9000 + 1, 2200 + 1, new Publisher("Adobe", 1000 + 1)),
            //    new PackageInstaller("Adobe Acrobat 2020", 9000 + 4, 2200 + 4, new Publisher("Adobe", 1000 + 4)),
            //    new PackageInstaller("Adobe Acrobat 2020", 9000 + 5, 2200 + 5, new Publisher("Adobe", 1000 + 5)),
            //    new PackageInstaller("Adobe Acrobat 2020", 9000 + 10, 2200 + 10, new Publisher("Adobe", 1000 + 10))
            //}))
            //    Console.WriteLine("Удалил все объекты.");
            //else
            //    Console.WriteLine("Удалил не все объекты.");

            //Print(collection);


            //DemoFindFile(collection);

            //DemoDeepCopy(collection);

            //DemoShallopCopy(collection);
            //Console.WriteLine($"Общее количество элементов в коллекции: {collection.Count}");

            //if (collection.RemoveMany(new File[] {
            //    new PackageInstaller("Adobe Acrobat 2020", 9000 + 1, 200 + 1, new Publisher("Adobe", 1000 + 1)),
            //    new PackageInstaller("Adobe Acrobat 2020", 9000 + 4, 200 + 4, new Publisher("Adobe", 1000 + 4)),
            //    new PackageInstaller("Adobe Acrobat 2020", 9000 + 5, 200 + 5, new Publisher("Adobe", 1000 + 5)),
            //    new PackageInstaller("Adobe Acrobat 2020", 9000 + 10, 200 + 10, new Publisher("Adobe", 1000 + 10))
            //}))
            //    Console.WriteLine("Удалил все объекты.");
            //else
            //    Console.WriteLine("Удалил не все объекты.");
            //Console.WriteLine($"Общее количество элементов в коллекции: {collection.Count}");

            ////collection.Delete();
            //Print(collection);
        }

        private static void DemoFindFile(MyCollection<File> collection)
        {
            if (FindFile(collection, out File file))
                Console.WriteLine($"Файл с такими параметрами найден: \n {file}");
            else
                Console.WriteLine("Файл с такими параметрами не найден.");
        }
    }
}