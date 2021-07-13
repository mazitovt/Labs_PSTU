using ExecutablesLibrary;
using System;

namespace LR12_1
{
    class LR12_1class
    {
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

        static void LinkedListMenu()
        {
            LinkedList list = new LinkedList();

            void RemoveFile()
            {
                if (list.Count != 0)
                {
                    var id = ConsoleInput("Введите id файла для удаления (от 100 до 10000): ", 100, 10000);
                    if (list.Remove(id))
                        Console.WriteLine("\nФайл успешно удален.");
                    else
                        Console.WriteLine("\nТакой файл не найден.");
                    return;
                }

                Console.WriteLine("\nСписок пуст");
            }

            void AddFileAt()
            {
                int pos = ConsoleInput($"Введите позицию для вставки (от 0 до {list.Count}): ", 0, list.Count);
                var file = FileCreator.CreateFile();
                list.AddAt(file, pos);
            }

            void AddFileAfter()
            {
                if (list.Count != 0)
                {
                    int id = ConsoleInput($"Введите id файла, после которого нужно вставить файл (от 100 до 10000): ", 100, 10000);

                    var file = FileCreator.CreateFile();

                    if (list.AddAfter(file, id))
                        Console.WriteLine("\nВставка успешно произошла.");
                    else
                        Console.WriteLine("\nФайл с таким id не найден.");
                    return;
                }

                Console.WriteLine("\nСписок пуст");
            }

            LinkedList FillLinkedList()
            {
                int size = ConsoleInput($"Введите размер списка (от 1 до 100): ", 1, 100);
                return new LinkedList(size);
            }

            void Print()
            {
                if (list.Count != 0)
                {
                    Console.WriteLine("\nЭлементы списка.");
                    list.Print();
                    return;
                }
                Console.WriteLine("\nСписок пуст");
            }

            int choice;
            bool exit = false, flag;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine(
@"Меню
0. Вернуться в главное меню.
1. Заполнить случаными значениями.
2. Добавить элемент в позицию.
3. Добавить элемент после элемента с заданным Id.
4. Удалить элемент из списка.
5. Распечатать список.
");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(0 <= choice && choice <= 5) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(0 <= choice && choice <= 5) || !flag);

                switch (choice)
                {
                    case 0: exit = true; break;
                    case 1: list = FillLinkedList(); break;
                    case 2: AddFileAt(); break;
                    case 3: AddFileAfter(); break;
                    case 4: RemoveFile(); break;
                    case 5: Print(); break;
                }
            }
        }

        static void DoubleLinkedListMenu()
        {
            DoubleLinkedList list = new DoubleLinkedList();

            void RemoveFile()
            {
                var id = ConsoleInput("Введите id файла для удаления (от 100 до 10000): ", 100, 10000);
                if (list.Remove(id))
                    Console.WriteLine("\nФайл успешно удален.");
                else
                    Console.WriteLine("\nТакой файл не найден.");
            }

            void AddFile()
            {
                var file = FileCreator.CreateFile();
                list.Add(file);
            }

            void RemoveWithLessThanAvgSize()
            {
                if (list.Count != 0)
                {
                    var size = list.AverageSize();
                    Console.WriteLine(size);
                    var count = list.RemoveWithLessThanAvgSize(size);
                    if (count != 0)
                        Console.WriteLine($"\nБыло удалено файлов: {count}.");
                    else
                        Console.WriteLine("\nНи один файл не был удален.");

                    return;
                }

                Console.WriteLine("\nСписок пуст.");
               
            }

            void Print()
            {
                if (list.Count != 0)
                {
                    Console.WriteLine("\nЭлементы списка.");
                    list.Print();
                    return;
                }
                Console.WriteLine("\nСписок пуст");
            }

            void PrintInDeatail()
            {
                if (list.Count != 0)
                {
                    Console.WriteLine("\nЭлементы списка.");
                    list.PrintWithNextAndPrev();
                    return;
                }
                Console.WriteLine("\nСписок пуст");
            }

            DoubleLinkedList FillLinkedList()
            {
                int size = ConsoleInput($"Введите размер списка (от 1 до 100): ", 1, 100);
                return new DoubleLinkedList(size);
            }

            int choice;
            bool exit = false, flag;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine(
@"Меню
0. Вернуться в главное меню.
1. Заполнить случаными значениями.
2. Добавить элемент в конец.
3. Удалить элемент из списка.
4. Удалить все файлы с размером меньше среднего.
5. Распечатать список.
6. Распечатать с предыдущими и следующими.
");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(0 <= choice && choice <= 6) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(0 <= choice && choice <= 6) || !flag);

                switch (choice)
                {
                    case 0: exit = true; break;
                    case 1: list = FillLinkedList(); break;
                    case 2: AddFile(); break;
                    case 3: RemoveFile(); break;
                    case 4: RemoveWithLessThanAvgSize(); break;
                    case 5: Print(); break;
                    case 6: PrintInDeatail(); break;
                }
            }
        }

        static void TreeMenu()
        {
            Tree tree = new Tree();

            void RemoveFile()
            {
                if (tree.Remove(ConsoleInput($"Введите id файла для удаления (от 100 до 10000): ", 100, 10000)))
                {
                    Console.WriteLine("\nЭлемент удален");
                    return;
                }

                Console.WriteLine("\nЭлемент не найден.");
            }

            void AddFile()
            {
                Console.WriteLine("\nВнимание! Если файл с таким же Id существует, он будет перезаписан.");
                tree.Add(FileCreator.CreateFile());
            }

            void ShowAverageSize() 
            {
                if (!tree.IsEmpty)
                {
                    Console.WriteLine($"\nСредний размер файлов в дереве: {tree.AverageFileSize()} Mb");
                    return;
                }

                Console.WriteLine("\nВ дереве нет элементов.");
            }

            Tree FillTree() => new Tree(ConsoleInput($"Введите размер дерева (от 1 до 100): ", 1, 100));

            void Print(int padding, bool IsDetailed)
            {
                if (!tree.IsEmpty)
                {
                    tree.Print(padding, IsDetailed);
                    return;
                }
                Console.WriteLine("\nВ дереве нет элементов.");
            }

            int choice;
            bool exit = false, flag;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine(
@"Меню
0. Вернуться в главное меню.
1. Заполнить случайными значениями.
2. Добавить элемент в дерево.
3. Удалить элемент из дерева.
4. Найти среднее значений размера файлов.
5. Распечатать дерево.
6. Распечатать подробно и без отступов.
");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(0 <= choice && choice <= 6) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(0 <= choice && choice <= 6) || !flag);

                switch (choice)
                {
                    case 0: exit = true; break;
                    case 1: tree = FillTree(); break;
                    case 2: AddFile(); break;
                    case 3: RemoveFile(); break;
                    case 4: ShowAverageSize(); break;
                    case 5: Print(5, false); break;
                    case 6: Print(0, true); break;
                }
            }
        }

        static void Menu()
        {
            int choice;
            bool exit = false, flag;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine(
@"Меню
0. Выход
1. Работа с однонаправленным списком.
2. Работа с двунаправленным списком.
3. Работа с деревом.
");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(0 <= choice && choice <= 3) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(0 <= choice && choice <= 3) || !flag);

                switch (choice)
                {
                    case 0: exit = true; break;
                    case 1: LinkedListMenu(); break;
                    case 2: DoubleLinkedListMenu(); break;
                    case 3: TreeMenu(); break;
                }
            }
            Console.WriteLine("\nЗавершение работы программы");
        }

        //static void TestLinkedlist()
        //{
        //    LinkedList Linkedlist = new LinkedList(5);

        //    Linkedlist.Print();

        //    Linkedlist.AddAt(new PackageInstaller("test", 9000, 2205, new Publisher("Adobe", 1009)), 1);
        //    Linkedlist.Print();

        //    if (Linkedlist.AddAfter(new PackageInstaller("test", 9000, 99, new Publisher("IBM", 99)), 2210))
        //        Console.WriteLine("\nВставка успешна.");
        //    else
        //        Console.WriteLine("\nВставка не произошла.");
        //    Linkedlist.Print();

        //    //if (Linkedlist.Remove(new PackageInstaller("test", 9000, 2205, new Publisher("Adobe", 1009))))
        //    //    Console.WriteLine("\nУдаление успешно.");
        //    //else
        //    //    Console.WriteLine("\nУдаление не произошло.");
        //    Linkedlist.Print();
        //}

        //static void TestDoubleLinkedList()
        //{
        //    DoubleLinkedList DoubleLinkedlist = new DoubleLinkedList(5);

        //    DoubleLinkedlist.Add(new PackageInstaller("test", 9000, 99, new Publisher("IBM", 99)));

        //    DoubleLinkedlist.Print();

        //    Console.WriteLine();
        //    Console.WriteLine($"Средний размер файлов: {DoubleLinkedlist.AverageSize()}.");
        //    Console.WriteLine("После удаление файлов.");

        //    DoubleLinkedlist.RemoveWithLessThanAvgSize(DoubleLinkedlist.AverageSize());
            
        //    DoubleLinkedlist.Print();
        //    Console.WriteLine();
        //}

        //static void TestTree()
        //{
        //    Tree tree = Tree.FormBalancedTree(FileCreator.CreateFilesArray(20));
        //    Console.WriteLine("\nЭлементы дерева:");
        //    tree.Print(5, false);           
        //    Console.WriteLine($"\nСредний размер файлов в дереве: {tree.AverageFileSize()} MB");
        //}
    }
}