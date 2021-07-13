//2.1.Задание 1.
//Создать коллекцию, в которую добавить объекты созданной иерархии классов.
//Используя меню, реализовать в программе добавление и удаление объектов коллекции.
//Разработать и реализовать три запроса (количество элементов определенного вида, печать элементов определенного вида и т.п.).
//Выполнить перебор элементов коллекции с помощью метода foreach. 
//Выполнить клонирование коллекции.
//Выполнить сортировку коллекции (если коллекция не отсортирована) и поиск заданного элемента в коллекции.
//При работе с коллекцией использовать объекты из иерархии классов, разработанной в работе №10. 


using System;
using System.Collections;
using System.Linq;
using ExecutablesLibrary;


namespace LR11_1
{
    class LR11_1
    {
        static void Main(string[] args) => Menu();

        static void Menu()
        {
            var sList = new SortedList();

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
4. Общее количество элементов.
5. Вывести все файлы заданного типа.
6. Общий размер всех файлов заданного типа.
7. Вывести все элементы. 
8. Выполнить клонирование коллекции.
9. Поиск элемента в коллекции.
");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(0 <= choice && choice <= 9) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(0 <= choice && choice <= 9) || !flag);

                if (sList.Count == 0 && choice == 1 || sList.Count != 0){
                    switch (choice)
                    {
                        case 1: sList = CreateSortedList(); break;
                        case 2: sList = AddFile(sList); break;
                        case 3: sList = RemoveFile(sList); break;
                        case 4: CountElements(sList); break;
                        case 5: ShowFiles(sList); break;
                        case 6: SizeOfFiles(sList); break;
                        case 7: ShowAll(sList); break;
                        case 8: DemonstrateClone(sList); break;
                        case 9: FindElement(sList); break;

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

        static SortedList CreateSortedList()
        {
            var size = ConsoleInput("Введите размер коллекции (от 1 до 100): ", 1, 100);

            SortedList sList = new SortedList();

            int postfix = 0;

            foreach (var _ in Enumerable.Range(0, size)) 
            {
                File file = FileCreator.CreateRandomFile(ref postfix);
                sList[file.Name] = file;
            }

            Console.WriteLine("Коллекция создана.");

            return sList;
        }

        static SortedList AddFile(SortedList sList)
        {
            Console.WriteLine(
@"1 - Установщик пакетов.
2 - Служба.
3 - Диспетчер задач.");

            int index = ConsoleInput("Введит число от 1 до 3: ", 1, 3);

            var file = FileCreator.CreateFile(index);

            try
            {
                sList.Add(file.Name, file);
                Console.WriteLine("\nФайл добавлен.");
            } catch 
            {
                Console.WriteLine("\nОШИБКА: Ключ с таким значением уже существует.");
            }

            return sList;
        }

        static SortedList RemoveFile(SortedList sList)
        {
            foreach (var i in Enumerable.Range(0, sList.Count))
                Console.WriteLine($"{i}: {sList.GetKey(i)}");

            int index = ConsoleInput("Введите номер элемента для удаления: ", 0, sList.Count - 1);

            try
            {
                sList.RemoveAt(index);
                Console.WriteLine("\nФайл удален.");
            }
            catch
            {
                Console.WriteLine("\nОШИБКА: Ключ с таким значением не существует.");
            }
            return sList;
        }

        static void ShowAll(SortedList sList)
        {
            Console.WriteLine("Элементы коллекции.");
            Console.WriteLine();
            Console.WriteLine($"{"-KEY-", -30} | -VALUE-");
            Console.WriteLine(new string('-', 150));

            foreach (DictionaryEntry pair in sList)
            {
                Console.WriteLine($"{pair.Key, -30} | {pair.Value}");
            }
            Console.WriteLine();
        }

        static int IntInput(string msg, int beg, int end)
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

        private static void FindElement(SortedList sList)
        {
            int id = ConsoleInput("Введите id (от 100 до 999): ", 100, 999);

            if (FindElementById(out var file, id, sList))
            {
                Console.WriteLine($"Найден файл с id = {id}");
                Console.WriteLine(file); ;
            }
            else
            {
                Console.WriteLine("Файл с таким id не найден.");
            }
        }

        private static bool FindElementById(out File file, int id, SortedList sList)
        {
            foreach(DictionaryEntry pair in sList)
            {
                if (((File)pair.Value).Id == id)
                {
                    file = (File)pair.Value;
                    return true;
                }
            }

            file = null;

            return false;          
        }

        public static void DemonstrateClone(SortedList sList)
        {
            var newList = new SortedList();
            CloneList(ref newList, sList);

            Console.WriteLine("Коллекция клонирована. Содержание двух коллекций одинаково.");

            ShowAll(sList);
            ShowAll(newList);

            Console.WriteLine("Вносим изменения: у первого элемента коллекции изменим Id на 1000 и имя издателя на PNIPU.");
            ((File)sList.GetByIndex(0)).Id = 1000;
            ((File)sList.GetByIndex(0)).Publisher.Name = "PNIPU";

            Console.WriteLine("Списки после изменения.");
            ShowAll(sList);
            ShowAll(newList);
        }
        
        private static void CloneList(ref SortedList newList, SortedList sList)
        {
            foreach (DictionaryEntry pair in sList)
            {
                newList[pair.Key] = ((File)pair.Value).Clone();
            }
        }

        private static void SizeOfFiles(SortedList sList)
        {
            int size = 0;

            Console.WriteLine(
@"Показать размер всех файлов типа:
1 - Установщики пакетов.
2 - Службы.
3 - Диспетчеры задач.");

            int key = ConsoleInput("Введит число от 1 до 3: ", 1, 3);

            var type = FileCreator.FileTypes[key];

            foreach (DictionaryEntry pair in sList)
            {
                if (type.IsInstanceOfType(pair.Value))
                {
                    size += ((File)pair.Value).Size;
                }
            }

            Console.WriteLine($"Общий размер файлов типа '{ type.GetField("Type").GetValue(null) }': {size} Mb");
        }

        private static void ShowFiles(SortedList sList)
        {
            Console.WriteLine(
@"Показать все файлы типа:
1 - Установщики пакетов.
2 - Службы.
3 - Диспетчеры задач.");

            int index = ConsoleInput("Введит число от 1 до 3: ", 1, 3);

            foreach (DictionaryEntry pair in sList)
            {
                if (FileCreator.FileTypes[index].IsInstanceOfType(pair.Value))
                {
                    Console.WriteLine(pair.Value);
                }
            }
        }

        private static void CountElements(SortedList sList)
        {
            Console.WriteLine($"В коллекции {sList.Count} {(sList.Count % 10 > 0 && sList.Count % 10 < 5 ? sList.Count % 10 == 1 ? "элемент" : "элемента" : "элементов")}");
        }
    }
}
