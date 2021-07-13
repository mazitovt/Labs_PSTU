// Лабораторная работа 4

//Вариант 	        13  
//Удаление          N элементов, начиная с номера K	
//Добавление        К элементов в начало массива	
//Перестановка      Поменять местами минимальный и максимальный элементы	
//Поиск             Первый четный	
//Сортировка        Простой обмен

//1)	Сформировать массив из n элементов с помощью датчика случайных чисел (n задается пользователем с клавиатуры).
//2)	Распечатать массив.
//3)    Выполнить удаление указанных элементов из массива.
//4)	Выполнить добавление указанных элементов в массив.
//5)	Выполнить перестановку элементов в массиве.
//6)	Выполнить поиск указанных в массиве элементов и подсчитать количество сравнений, необходимых для поиска нужного элемента.
//7)	Выполнить сортировку массива указанным методом.
//8)	Выполнить поиск указанных элементов в отсортированном массиве и подсчитать количество сравнений, необходимых для поиска нужного элемента.

//1.    Реализация основных функций задачи (создание, обработка в соответствии с вариантом, вывод полученных результатов).
//2.    Дополнительные функции (проверка правильности вводимых данных и т.д.)
//5.	Использование исключений.
//6.	Использование возможностей языка программирования, изучаемых самостоятельно.

using System;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace LR4
{
    class Program
    {
        static Random Rand = new Random();

        static void Main() => Menu();
  
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

        static int InputChoice()
        {
            Console.WriteLine("\n1. Заполнение массива случайными числами от 1 до 9.\n2. Ввод элементов массива с клавиатуры.");
            return ConsoleInput("Ваш выбор: ",1,2);
        }

        static int[] CreateArray()
        {
            int l = ConsoleInput("Введите длину массива (от 1 до 10): ",1,10);

            int choice = InputChoice();

            int[] array = new int[l];

            for (int i = 0; i < l; i++)
            {
                array[i] = (choice == 1) ? Rand.Next(1, 10) : ConsoleInput(String.Format("Введите элемент [{0}] (от {1} до {2}): ", i + 1, 0, 9), 0, 9);
            }

            Console.WriteLine("Создан одномерный массив длиной {0}", l);

            return array;
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine("\nВывод элементов массива.\n");
            foreach (var x in array) Console.Write(" {0}  ", x);
            Console.WriteLine();
            for (int i = 1; i <= array.Length; i++) Console.Write("[{0}] ", i);
            Console.WriteLine();
        }
        
        static int[] DeleteElements(int[] oldarray)
        {
            int begin = ConsoleInput("Включая с какого элемента производить удаления: ", 1, oldarray.Length);
            int toDel = ConsoleInput("Сколько элементов удалить: ", 1, oldarray.Length - begin + 1);

            int[] array = new int[oldarray.Length - toDel];

            for (int i = 0; i < oldarray.Length; i++)
            {
                if (i < begin-1) array[i] = oldarray[i];
                if (i >= begin + toDel - 1) array[i-toDel] = oldarray[i];
            }

            Console.WriteLine($"Из массива было удалено {toDel} элементов.");

            return array;
        }
        
        static int[] AddElements(int[] oldarray)
        {
            int toAdd = ConsoleInput("Сколько элементов добавить в начало массива (от 1 до 10): ",1,10);

            int[] array = new int[oldarray.Length + toAdd];

            int choice = InputChoice();

            for (int i = 0; i < array.Length; i++)
            {
                if (i < toAdd) array[i] = (choice == 1) ? Rand.Next(1, 10) : ConsoleInput(String.Format("Введите элемент [{0}] (от {1} до {2}): ", i + 1, 0, 9), 0, 9);
                else array[i] = oldarray[i - toAdd];
            }

            Console.WriteLine("\nВ массив было добвалено элементов: {0}", toAdd);

            return array;
        }
        
        static void ReplaceElements(int[] oldarray)
        {
            int max = oldarray[0], min = oldarray[0];
            int[,] positions = new int[2, oldarray.Length];
            positions[0, 0] = 1;
            positions[1, 0] = 1;
            int max_count = 1;
            int min_count = 1;

            int max_ch = 0, min_ch = 0, temp;

            for (int i = 1; i< oldarray.Length; i++)
            {
                if (oldarray[i] > max)
                {
                    max = oldarray[i];
                    for (int j = 0; j < max_count; j++) positions[0, j] = 0;
                    positions[0, 0] = i+1;
                    max_count = 1;
                }
                else if (oldarray[i] == max)
                {
                    positions[0, max_count] = i+1;
                    max_count++;
                }

                if (oldarray[i] < min)
                {
                    min = oldarray[i];
                    for (int j = 0; j < min_count; j++) positions[1, j] = 0;
                    positions[1, 0] = i+1;
                    min_count = 1;
                }
                else if (oldarray[i] == min)
                {
                    positions[1, min_count] = i+1;
                    min_count++;
                }
            }

            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < positions.GetLength(1); j++)
            //    {
            //        Console.Write(" "+positions[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            if (max_count > 1)
            {
                Console.WriteLine($"\nКоличество максимальных элементов: {max_count}");
                max_ch = ConsoleInput($"Какой максимальный элемент будем менять (от {1} до {max_count}): ", 1, max_count);
            }
            else max_ch = 1;  

            if (min_count > 1)
            {
                Console.WriteLine($"\nКоличество минимальных элементов: {min_count}");
                min_ch = ConsoleInput($"Какой минимальный элемент будем менять (от {1} до {min_count}): ", 1, min_count);
            }
            else min_ch = 1;
 
            temp = oldarray[positions[0,max_ch-1]-1];
            oldarray[positions[0, max_ch - 1]-1] = oldarray[positions[1,min_ch-1]-1];
            oldarray[positions[1, min_ch - 1]-1] = temp;

        }
        
        static void FindElement(int[] array)
        {
            int count = 0, first_even = 0, pos = 0;

            for (int i = 0; i < array.Length; i++)
            {
                count++;
                if (array[i] % 2 == 0)
                {
                    first_even = array[i];
                    pos = i+1;
                    break;
                }   
            }
            if (pos == 0) Console.WriteLine("\nВ массиве нет четных чисел.");
            else Console.WriteLine($"\nПервое четное число {first_even} в позиции {pos} было найднено за {count} {(count > 0 && count < 5 ? count == 1 ? "сравнение" : "сравнения" : "сравнений")}");
        
        }

        static void SortArray(int[] array)
        {
            int t;

            for (int i=0; i < array.Length - 1; i++)
            {
                for (int j=0; j < array.Length - i -1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        t= array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = t;
                    }
                }
            }
        }

        static void BinarySearch(int[] array)
        {
            SortArray(array);

            bool flag;
            int elem;

            do
            {
                Console.Write("\nКакой элемент будем искать в массиве: ");
                flag = int.TryParse(Console.ReadLine(), out elem);
                if (!flag || elem < array[0] || elem > array[array.Length - 1]) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
            } while (!flag || elem < array[0] || elem > array[array.Length-1]);

            Console.WriteLine($"\nПервый элемент {elem} находится в позиции {BinarySearch(elem, array)}");

        }

        static int BinarySearch (int elem, int[] array)
        {
            int 
                start_index = 0, 
                middle_index = array.Length / 2,
                end_index = array.Length - 1;
                
            while (array[middle_index] != elem)
            {
                if (array[start_index] == elem) { middle_index = start_index; break; }
                if (array[end_index] == elem) { middle_index = end_index; break; }

                if (elem < array[middle_index])
                {
                    end_index = middle_index - 1;
                }
                if (elem > array[middle_index])
                {
                    start_index = middle_index + 1;
                }

                middle_index = start_index + (end_index - start_index + 1) / 2;
            }
            
            if (middle_index != 0)
            {
                int j = middle_index - 1;
                while (j != -1 && array[j] == array[middle_index]) middle_index = j--;
            }

            return middle_index + 1;               
        }
        
        static void Menu()
        {
            int[] array = new int[0];
            int choice;
            bool exit = false, flag;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine(
@"Меню:
    1. Создать одномерный массив;	
    2. Распечатать массив;
    3. Удалить N элементов, начиная с номера K;
    4. Добавить К элементов в начало массива;	
    5. Поменять местами минимальный и максимальный элементы;
    6. Найти первый четный элемент;
    7. Отсортировать методом простой сортировки;
    8. Поиск в массиве.
    9. Выход из программы.");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(1 <= choice && choice <= 9) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(1 <= choice && choice <= 9) || !flag);

                if (array.Length == 0 && choice >= 2 && choice <=8)
                {
                    Console.WriteLine("\nСоздайте массив!");
                }
                else
                {
                    switch (choice)
                    {
                        case 1: array = CreateArray(); break;
                        case 2: PrintArray(array); break;
                        case 3: array = DeleteElements(array); break;
                        case 4: array = AddElements(array); break;
                        case 5: ReplaceElements(array); break;
                        case 6: FindElement(array); break;
                        case 7: SortArray(array); break;
                        case 8: BinarySearch(array);break;
                        case 9: exit = true; break;
                    }
                }
                
            }
            Console.WriteLine("\nЗавершение работы программы");
        }
    }
}
