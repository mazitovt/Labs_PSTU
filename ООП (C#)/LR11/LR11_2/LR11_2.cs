//2.2.Задание 2.
//Создать обобщенную  коллекцию, в которую добавить объекты созданной иерархии классов.
//Используя меню, реализовать в программе добавление и удаление объектов коллекции.
//Разработать и реализовать три запроса (количество элементов определенного вида, печать элементов определенного вида и т.п.).
//Выполнить перебор элементов коллекции с помощью метода foreach. 
// Выполнить клонирование коллекции.
//Выполнить сортировку коллекции (если коллекция не отсортирована) и поиск заданного элемента в коллекции.

//При работе с коллекцией использовать объекты из иерархии классов, разработанной в работе №10. 


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExecutablesLibrary;
using System.Reflection;
using System.Linq;

namespace LR11_2
{
    class LR11_2
    {
        static void Main(string[] args) => Menu();
        
        static void Menu()
        {
            var sDict = new SortedDictionary<int, File>();

            int choice;
            bool exit = false, flag;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine(
@"Меню
0. Выход
1. Создать коллекцию.
2. Добавить элемент.
3. Удалить элемент.
4. Все издатели файлов.
5. Все файлы заданного издателя.
6. Все файлы меньше заданного размера.
7. Вывести все элементы. 
8. Выполнить клонирование коллекции.
9. Поиск элемента в коллекции по имени.
10. Перевернуть сортировку коллекции.
");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(0 <= choice && choice <= 10) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(0 <= choice && choice <= 10) || !flag);

                if (sDict.Count == 0 && choice == 1 || sDict.Count != 0)
                {
                    switch (choice)
                    {
                        case 1: sDict = CreateSortedDictionary(); break;
                        case 2: sDict = AddFile(sDict); break;
                        case 3: sDict = RemoveFile(sDict); break;
                        case 4: ShowPublishers(sDict); break;
                        case 5: PublishersFiles(sDict); break;
                        case 6: FilesLessSize(sDict); break;
                        case 7: ShowAll(sDict); break;
                        case 8: DemonstrateClone(sDict); break;
                        case 9: FindElement(sDict); break;
                        case 10: sDict = DemostrateSort(sDict); break;

                        case 0: exit = true; break;
                    }
                }
                else
                {
                    Console.WriteLine("Создайте коллекцию!");
                }

            }
            Console.WriteLine("\nЗавершение работы программы");
        }

        static SortedDictionary<int, File> CreateSortedDictionary()
        {
            var size = ConsoleInput("Введите размер коллекции (от 1 до 100): ", 1, 100);

            int postfix = 0;

            var dict = (from _ in Enumerable.Range(0, size)
                        select FileCreator.CreateRandomFile(ref postfix)).ToDictionary(file => file.Id);

            Console.WriteLine("Коллекция создана.");

            return new SortedDictionary<int, File>(dict);
        }

        static SortedDictionary<int, File> AddFile(SortedDictionary<int, File> sDict)
        {
            Console.WriteLine("\n1 - Установщик пакетов.\n2 - Служба.\n3 - Диспетчер задач.");

            int index = ConsoleInput("Введит число от 1 до 3: ", 1, 3);

            var file = FileCreator.CreateFile(index);

            try
            {
                sDict.Add(file.Id, file);
                Console.WriteLine("\nФайл добавлен.");
            } catch
            {
                Console.WriteLine("\nОШИБКА: Ключ с таким значением уже существует.");
            }

            return sDict;
        }

        static SortedDictionary<int, File> RemoveFile(SortedDictionary<int, File> sDict)
        {
            Console.WriteLine("Ключи в коллекции.");

            foreach (var pair in sDict.Keys.Select((v, i) => (v ,i)))
                Console.WriteLine($"{pair.i}: {pair.v}");

            int key = ConsoleInput("Введите ключ для удаления (от 100 до 999): ", 100, 999);

            try
            {
                sDict.Remove(key);
                Console.WriteLine("\nФайл удален.");
            } catch
            {
                Console.WriteLine("\nОШИБКА: Ключ с таким значением не существует.");
            }

            return sDict;
        }

        static void ShowAll(SortedDictionary<int, File> sDict)
        {
            Console.WriteLine("Элементы коллекции.");
            Console.WriteLine();
            Console.WriteLine($"   -KEY-    | -VALUE-");
            Console.WriteLine(new string('-', 120));

            foreach (KeyValuePair<int, File> pair in sDict)
            {
                Console.WriteLine($"    {pair.Key,-7} | {pair.Value}");
            }
            Console.WriteLine();
        }

        private static void FilesLessSize(SortedDictionary<int, File> sDict)
        {
            int size = ConsoleInput("Введите размер файла: ", 0, 10000000);

            foreach (var file in sDict.Values)
            {
                if (file.Size < size)
                    Console.WriteLine(file);
            }
        }
   
        public static List<Publisher> GetPublishers(SortedDictionary<int, File> sDict)
        {
            return sDict.Values.Select(file => file.Publisher).Distinct().ToList();
        }

        private static void PublishersFiles(SortedDictionary<int, File> sDict)
        {
            Console.WriteLine("Все издатели файлов:");

            var pubs = GetPublishers(sDict);

            foreach (var i in Enumerable.Range(0, pubs.Count))
            {
                Console.WriteLine($"{i}: {pubs[i].Name}, {pubs[i].Id}");
            }

            int index = ConsoleInput($"Введите число (от 0 до {pubs.Count - 1}): ", 0, pubs.Count - 1);

            foreach (var  file in sDict.Values)
            {
                if (file.Publisher.Equals(pubs[index]))
                    file.ShowInfo();
            }
        }

        private static void ShowPublishers(SortedDictionary<int, File> sDict)
        {
            Console.WriteLine("Все издатели файлов:");

            foreach (var p in GetPublishers(sDict))
                Console.WriteLine($"Имя: {p.Name}, Id: {p.Id}");
        }

        private static void FindElement(SortedDictionary<int, File> sDict)
        {
            bool FindElementByName(ref File file, string name, SortedDictionary<int, File> sDict)
            {
                foreach (KeyValuePair<int, File> pair in sDict)
                {
                    if (pair.Value.Name == name)
                    {
                        file = pair.Value;
                        return true;
                    }
                }
                return false;
            }

            Console.WriteLine("Введите название файла: ");
            string name = Console.ReadLine();
            File file = null;

            if (FindElementByName(ref file, name, sDict))
            {
                Console.WriteLine($"\nНайден файл с именем {name}");
                Console.WriteLine(file); ;
            }
            else
            {
                Console.WriteLine("\nФайл с таким именем не найден.");
            }
        }

        private static void CloneDict(ref SortedDictionary<int, File> newList, SortedDictionary<int, File> sDict)
        {
            foreach (KeyValuePair <int, File> pair in sDict)
            {
                newList[pair.Key] = (File)pair.Value.Clone();
            }
        }

        public static void DemonstrateClone(SortedDictionary<int, File> sDict)
        {
            
            var newDict = new SortedDictionary<int, File>();
            CloneDict(ref newDict, sDict);

            Console.WriteLine("Коллекция клонирована. Содержание двух коллекций одинаково.");

            ShowAll(sDict);
            ShowAll(newDict);

            Console.WriteLine("Вносим изменения: у первого элемента коллекции изменим размер и имя издателя.");
            sDict[sDict.Keys.First()].Size = 1000;
            sDict[sDict.Keys.First()].Publisher.Name = "PNIPU";

            Console.WriteLine("Словари после изменения.");
            ShowAll(sDict);
            ShowAll(newDict);
        }

        public static SortedDictionary<int, File> DemostrateSort(SortedDictionary<int, File> sDict) => ReverseKeysOrder(sDict);
   
        public static SortedDictionary<int, File> ReverseKeysOrder(SortedDictionary<int, File> sDict)
        {
            SortedDictionary<int, File> newDict = new SortedDictionary<int, File>(new SortByIdDesc());

            CloneDict(ref newDict, sDict);

            return newDict;
        }
        

        public static int IntInput(string msg, int beg, int end)
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
        public static int ConsoleInput(string msg, int beg, int end)
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


        private static void SizeOfInstallers(SortedDictionary<int, File> sDict)
        {
            int size = 0;

            foreach (KeyValuePair <int, File> pair in sDict)
            {
                if (typeof(PackageInstaller).IsInstanceOfType(pair.Value))
                {
                    size += ((File)pair.Value).Size;
                }
            }

            Console.WriteLine($"Общий размер всех установщиков пакетов: {size}");
        }
        private static void ShowServices(SortedDictionary<int, File> sDict)
        {
            foreach (KeyValuePair<int, File> pair in sDict)
            {
                if (typeof(Service).IsInstanceOfType(pair.Value))
                {
                    pair.Value.ShowInfo();
                }
            }
        }
        private static void CountElements(SortedDictionary<int, File> sDict)
        {
            Console.WriteLine($"В коллекции {sDict.Count} {(sDict.Count % 10 > 0 && sDict.Count % 10 < 5 ? sDict.Count % 10 == 1 ? "элемент" : "элемента" : "элементов")}");
        }
    }
}
