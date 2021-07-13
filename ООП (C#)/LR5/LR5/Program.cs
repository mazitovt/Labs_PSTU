// Лабораторная работа 5
//13    Одномерный  - Добавить К элементов в начало массива	
//      Двумерный   - Удалить строки, начиная со строки К1 и до строки К2 включительно	
//      Рваный      - Добавить строку с заданным номером

//1.    Сформировать динамический одномерный массив, заполнить его случайными числами и вывести на печать.
//2.	Выполнить указанное в варианте задание и вывести полученный массив на печать.
//3.	Сформировать динамический двумерный массив, заполнить его случайными числами и вывести на печать.
//4.	Выполнить указанное в варианте задание и вывести полученный массив на печать.
//5.	Сформировать динамический двумерный массив, заполнить его случайными числами и вывести на печать.
//6.	Выполнить указанное в варианте задание и вывести полученный массив на печать.
//7.	При реализации функций необходимо продемонстрировать использование параметров разных типов 
//        и различные способы организации функций (параметры по умолчанию, перегрузку функций, и .т.д.)

//Использование разных типов функций (перегрузка, параметры по умолчанию, функции с переменным числом параметров, рекурсивные функции и т.п.).
//Использование исключений.

using System;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace LR5
{
    class Program
    {

        //Метод - точка входа в программу
        static void Main(string[] args)
        {
            Menu();
        }

        // Принимает число с консоли и возвращает его
        static int ConsoleInput(int i, int j = -1)
        {
            bool flag;
            int elem = 0;
            string str = (j != -1) ? String.Format("\nВведите  целое число [{0},{1}]: ", i, j) : String.Format("\nВведите целое число [{0}]: ", i);
            do
            {
                flag = false;
                Console.WriteLine(str);
                try
                {
                    elem = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    flag = true;
                    Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                }
            } while (flag);
 
            //do
            //{
            //    if (j != -1) Console.Write("\nВведите число [{0},{1}]: ",i,j);
            //    else Console.Write("\nВведите число [{0}]: ",i);
            //    flag = int.TryParse(Console.ReadLine(), out elem);
            //    if (elem < 0 || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
            //} while (elem < 0 || !flag);

            return elem;
        }

        // Печатает одномерный массив
        static void PrintArray(ref int[] array)
        {
            Console.WriteLine("\nВывод элементов массива.\n");
            foreach (var x in array) Console.Write(" {0}  ", x);
            Console.WriteLine();
            for (int i = 1; i <= array.Length; i++) Console.Write("[{0}] ", i);
            Console.WriteLine();
        }

        // Печатает двумерный массив
        static void PrintArray(ref int[,] array)
        {
            Console.WriteLine("\nВывод элементов массива.\n");
            Console.Write("     ");
            for (int i = 0; i < array.GetLength(1); i++) Console.Write("{0,4}", String.Format("[{0}]", i+1));
            int index = 0;
            foreach (var elem in array)
            {

                if (index % array.GetLength(1) == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("{0,4}", String.Format("[{0}]", index / array.GetLength(1) + 1));
                }
                Console.Write("{0,4}", elem);
                index++;
            }

            Console.WriteLine();
        }

        // Печатает двумерный рваный массив
        static void PrintArray(ref int[][] array)
        {
            Console.WriteLine("\nВывод элементов массива.\n");
            Console.Write("     ");

            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i].Length) max = array[i].Length;
            }
            for (int i = 1; i <= max; i++) Console.Write("{0,4}", String.Format("[{0}]", i ));
            int index = 1;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {

                    if (j == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("{0,4}", String.Format("[{0}]", index ));
                    }
                    Console.Write("{0,4}", array[i][j]);
                }
                index++;
            }

            Console.WriteLine();
        }

        //Создает массив и возвращает его
        static dynamic CreateArray(int n)
        {
            bool flag;
            int l, m=0, choice;
            string buff;
            Random Rand = new Random();
            
            // создание одномерного массива
            if (n == 1)
            {
                do
                {
                    Console.Write("\nВведите длину массива (от 1 до 99): ");
                    buff = Console.ReadLine();
                    flag = int.TryParse(buff, out l);
                    if  (l <= 0 || l >= 100 || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (l <= 0 || l >= 100 || !flag);

                int[] array = new int[l];

                Console.WriteLine("\n1. Заполнение массива случайными числами от 1 до 9.\n2. Ввод элементов массива с клавиатуры.");
                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(choice == 1 || choice == 2) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(choice == 1 || choice == 2) || !flag);

                for (int i = 0; i < l; i++)
                {
                    array[i] = (choice == 1) ? Rand.Next(1, 10) : ConsoleInput(i+1);
                }

                Console.WriteLine("\nСоздан одномерный массив длиной {0}", l);
                return array;
            }

            // создание двумерного массива
            if (n == 2)
            {
                do
                {
                    Console.Write("\nВведите количество строк массива (от 1 до 9): ");
                    buff = Console.ReadLine();
                    flag = int.TryParse(buff, out l);
                    Console.Write("Введите количество столбцов массива (от 1 до 9): ");
                    buff = Console.ReadLine();
                    flag &= int.TryParse(buff, out m);
                    if  (l <= 0 || m <= 0 || l >= 10 || m >= 10 || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (l <= 0 || m <= 0 || l >= 10 || m >= 10 || !flag);

                Console.WriteLine("\n1. Заполнение массива случайными числами от 1 до 9.\n2. Ввод элементов массива с клавиатуры.");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(choice == 1 || choice == 2) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(choice == 1 || choice == 2) || !flag);

                int[,] array = new int[l, m];

                for (int i = 0; i < l; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        array[i, j] = (choice == 1) ? Rand.Next(1, 10) : ConsoleInput(i+1,j+1);
                    }
                }

                Console.WriteLine("\nСоздан двумерный массив размерностью {0} на {1}", l, m);

                return array;
            }

            // создание двумерного рваного массива
            if (n == 3)
            {
                {
                    do
                    {
                        Console.Write("\nВведите количество строк массива (от 1 до +INF): ");
                        flag = int.TryParse(Console.ReadLine(), out l);
                        if (l <= 0 || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                    } while (l <= 0 || !flag);


                    

                    int[][] array = new int[l][];

                    for (int i = 0; i < l; i++)
                    {
                        do
                        {
                            Console.Write("\nВведите количество элементов в строке {0} (от 1 до +INF): ",i+1);
                            buff = Console.ReadLine();
                            flag = int.TryParse(buff, out m);
                            if (m <= 0 || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                        } while (m <= 0 || !flag);

                        Console.WriteLine("\n1. Заполнение массива случайными числами от 1 до 9.\n2. Ввод элементов массива с клавиатуры.");
                        do
                        {
                            Console.Write("\nВаш выбор: ");
                            flag = int.TryParse(Console.ReadLine(), out choice);
                            if (!(choice == 1 || choice == 2) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                        } while (!(choice == 1 || choice == 2) || !flag);

                        array[i] = new int [m];

                        for (int j = 0; j < m; j++)
                        {
                            array[i][j] = (choice == 1) ? Rand.Next(1, 10) : ConsoleInput(i+1,j+1);
                        }
                    } 
                    

                    //for (int i = 0; i < l; i++)
                    //{
                    //    for (int j = 0; j < m; j++)
                    //    {
                    //        array[i, j] = (choice == 1) ? Rand.Next(1, 10) : ConsoleInput();
                    //    }
                    //}

                    Console.WriteLine("\nСоздан рваный двумерный массив с количеством строк {0}", l);

                    return array;
                }
            }

            else return 0;
        }
        
        //Добавляет элементы в новый массив, копирует старые элементы и возвращает его 
        static int[] AddElements(int[] oldarray)
        {
            bool flag;
            int k, choice;

            do
            {
                Console.Write("\nСколько элементов добавить в начало массива (от 1 до 99): ");
                flag = int.TryParse(Console.ReadLine(), out k);
                if (k <= 0 || k >= 100 || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
            } while (k <= 0 || k >= 100 || !flag);

            Console.WriteLine("\n1. Заполнение массива случайными числами от 1 до 9.\n2. Ввод элементов массива с клавиатуры.");
            do
            {
                Console.Write("\nВаш выбор: ");
                flag = int.TryParse(Console.ReadLine(), out choice);
                if (!(choice == 1 || choice == 2) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
            } while (!(choice == 1 || choice == 2) || !flag);

            int[] array = new int[oldarray.Length + k];

            Random R = new Random();

            for (int i = 0; i < k; i++)
            {
                array[i] = (choice == 1) ? R.Next(1, 10) : ConsoleInput(i+1);
            }
            for (int n = 0; n < oldarray.Length; n++) array[n + k] = oldarray[n];

            Console.WriteLine("\nВ массив было добвалено элементов: {0}", k);

            return array;
        }

        //Удаляет строчки из двумерного массива, оставшиеся копирует в новый массив и возвращает его 
        static int[,] DeleteRows(ref int[,] oldarray)
        {
            int rows = oldarray.GetLength(0);
            int k1, k2;
            string buff;
            bool flag;

            Console.WriteLine("\nУдаление строк с К1 до К2 включительно. Количество строк в массиве: {0}", rows);

            do
            {
                Console.Write("\nВведите K1 (от 1 до {0}): ", rows);
                buff = Console.ReadLine();
                flag = int.TryParse(buff, out k1);
                Console.Write("\nВведите K2 (от 1 до {0}): ", rows);
                buff = Console.ReadLine();
                flag &= int.TryParse(buff, out k2);
                if (k1 < 1 || k1 > rows || k2 < 1 || k2 > rows || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
            } while (k1 < 1 || k1 > rows || k2 < 1 || k2 > rows || !flag);

            int to_del = Math.Abs(k1 - k2) + 1;

            if (k1 > k2)
            {
                k1 = k1 + k2;
                k2 = k1 - k2;
                k1 = k1 - k2;
            }

            int[,] array = new int[rows - to_del, oldarray.GetLength(1)];

            flag = false;

            for (int i = 0; i < oldarray.GetLength(0); i++)
            {
                if (i + 1 >= k1 && i + 1 <= k2)
                {
                    flag = true;
                }
                else
                {
                    for (int j = 0; j < oldarray.GetLength(1); j++)
                    {
                        if (flag)
                        {
                            array[i - to_del, j] = oldarray[i, j];
                        }
                        else
                        {
                            array[i, j] = oldarray[i, j];
                        }
                    }
                }
            }

            Console.WriteLine("\nБуло удалено строк: {0}", to_del);

            return array;
        }

        //Создает двумерный рваный массив, добавляет в него одну строчку, копирует все строки из старго массива, возвращает новый массив
        static int[][] AddRows(ref int[][] oldarray)
        {

            bool flag;
            int k, choice,len;
            Random R = new Random();

            do
            {
                Console.Write("\nВ какую строку добавить массив (от 1 до {0}): ", oldarray.Length+1);
                flag = int.TryParse(Console.ReadLine(), out k);
                if (k < 1 || k > oldarray.Length+1 || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
            } while (k < 1 || k > oldarray.Length+1 || !flag);

            do
            {
                Console.Write("\nВведите количество элементов в строке {0} (от 1 до +INF): ", k);
                flag = int.TryParse(Console.ReadLine(), out len);
                if (len <= 0 || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
            } while (len <= 0 || !flag);

            Console.WriteLine("\n1. Заполнение массива случайными числами от 1 до 9.\n2. Ввод элементов массива с клавиатуры.");
            do
            {
                Console.Write("\nВаш выбор: ");
                flag = int.TryParse(Console.ReadLine(), out choice);
                if (!(choice == 1 || choice == 2) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
            } while (!(choice == 1 || choice == 2) || !flag);

            int[][] array = new int[oldarray.Length + 1][];
            array[k - 1] = new int[len];
            for (int j = 0; j < len; j++)
            {
                array[k-1][j] = (choice == 1) ? R.Next(1, 10) : ConsoleInput(k,j+1);
            }

            for (int i = 0; i < oldarray.Length + 1; i++)
            {
                if (i < k - 1) array[i] = oldarray[i];
                if (i > k - 1) array[i] = oldarray[i-1];  
            }

            return array;
        }

        //Меню работы с одномерным массивом
        static void Task1()
        {
            int choice;
            bool exit = false, flag;
            int[] array = new int[0];
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine(
@"Меню работы с одномерным массивом:
    1. Создать одномерный массив;	
    2. Добавить К элементов в начало массива;
    3. Распечатать массив;
    4. Вернуться в главное меню.");
                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(1 <= choice && choice <= 4) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(1 <= choice && choice <= 4) || !flag);

                if (array.Length == 0 && (choice == 2 || choice == 3))
                {
                    Console.WriteLine("\nСоздайте массив!");
                }
                else
                {
                    switch (choice)
                    {
                        case 1: array = CreateArray(1); break;
                        case 2: array = AddElements(array); break;
                        case 3: PrintArray(ref array); break;
                        case 4: exit = true; break;
                    }
                }
            }
        }

        //Меню работы с двумерным массивом
        static void Task2()
        {
            int choice;
            bool exit = false, flag;
            int[,] array = new int[0, 0];
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine(
@"Меню работы с двумерным массивом:
    1. Создать двумерный массив;	
    2. Удалить строки, начиная со строки К1 и до строки К2 включительно;
    3. Распечатать массив;
    4. Вернуться в главное меню.");
                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(1 <= choice && choice <= 4) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(1 <= choice && choice <= 4) || !flag);

                if (array.GetLength(0) == 0 && (choice == 2 || choice == 3))
                {
                    Console.WriteLine("\nСоздайте массив!");
                }
                else
                {
                    switch (choice)
                    {
                        case 1: array = CreateArray(2); break;
                        case 2: array = DeleteRows(ref array); break;
                        case 3: PrintArray(ref array); break;
                        case 4: exit = true; break;
                    }
                }
            }
        }

        //Меню работы с двумерным рваным массивом
        static void Task3()
        {
            int choice;
            bool exit = false, flag;
            int[][] array = new int[0][];
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine(
@"Меню работы с рваным массивом:
    1. Создать рваный массив;	
    2. Добавить строку с заданным номером;
    3. Распечатать массив;
    4. Вернуться в главное меню.");
                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(1 <= choice && choice <= 4) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(1 <= choice && choice <= 4) || !flag);

                if (array.GetLength(0) == 0 && (choice == 2 || choice == 3))
                {
                    Console.WriteLine("\nСоздайте массив!");
                }
                else
                {
                    switch (choice)
                    {
                        case 1: array = CreateArray(3); break;
                        case 2: array = AddRows(ref array); break;
                        case 3: PrintArray(ref array); break;
                        case 4: exit = true; break;
                    }
                }
            }
        }

        //Основное меню
        static void Menu()
        {
            int choice;
            bool exit = false, flag;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine(
@"Меню:
    1. Работа с одномерным массивом;	
    2. Работа с двумерным массивом;
    3. Работа с рваным массивом;
    4. Выход из программы.");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(1 <= choice && choice <= 4) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(1 <= choice && choice <= 4) || !flag);

                switch (choice)
                {
                    case 1: Task1(); break;
                    case 2: Task2(); break;
                    case 3: Task3(); break;
                    case 4: exit = true; break;
                }
            }
            Console.WriteLine("\nЗавершение работы программы");
        }
    }
}
