using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LR9
{
    public class MoneyArray
    {

//-------------- ПОЛЯ КЛАССА ----------------//

        private Money[] arr;
        private int size;

//------------- СВОЙСТВА КЛАССА -------------//

        public int Size
        {
            
            get { return size; }
            private set { 
                if (value >= 0) size = value;
                else Console.WriteLine("Недопустимое значение");
            }
        }

        /// <summary>
        /// Возвращает среднее арифметическое рублей 
        /// </summary>
        /// <returns>Число float</returns>
        public double AverageRubles
        {
            get
            {
                double average = 0;
                foreach (var m in arr)
                    average += m.Rubles;
                average /= Size;
                return Math.Round(average, 2);
            }
        }

        /// <summary>
        /// Возвращает среднее арифметическое копеек 
        /// </summary>
        /// <returns>Число float</returns>
        public double AverageKopecks
        {
            get
            {
                double average = 0;
                foreach (var m in arr)
                    average += m.Kopecks;
                average /= Size;
                return Math.Round(average, 2);
            }
        }

        //----------- КОНСТРУКТОРЫ КЛАССА -----------//

        /// <summary>
        /// Сводка:
        ///     Создает объект по умолчанию (пустой массив).
        /// </summary>
        /// <returns>Объект класса MoneyArray.</returns>
        public MoneyArray()
        {
            Size = 0;
            arr = new Money[Size];          
        }

        /// <summary>
        /// Сводка:
        ///     Создает объект и заполняет массив значениями по умолчанию.
        /// </summary>
        /// <param name="Size">Количество элементов в массиве.</param> 
        /// <returns>Объект класса MoneyArray.</returns>
        public MoneyArray(int s)
        {
            Size = s;
            arr = new Money[Size]; 
            
            for (int i = 0; i < Size; i++)
                arr[i] = new Money();
        }

        /// <summary>
        /// Сводка:
        ///     Создает объект и заполняет его массив случайными числами от 0 до end.
        /// </summary>
        /// <param name="Size">Количество элементов в массиве.</param> 
        /// <param name="end">Верхний предел диапазона значений.</param> 
        /// <returns>Объект класса MoneyArray.</returns>
        public MoneyArray(int s, int end)
        {
            Random rnd = new Random();
            Size = s;
            arr = new Money[Size];
            for (int i = 0; i < Size; i++)
            {
                arr[i] = new Money(rnd.Next(0,end), rnd.Next(0, end));
            }
        }

        /// <summary>
        /// Создает объект на основе массива in_arr.
        /// </summary>
        /// <param name="in_arr">Массив объектов класса Money.</param> 
        /// <returns>Объект класса MoneyArray.</returns>
        public MoneyArray(Money [] in_arr)
        {
            Size = in_arr.Length;
            arr = new Money[Size];
            in_arr.CopyTo(arr,0);
        }

        //------------ ИНДЕКСАТОР КЛАССА ------------//

        /// <summary>
        /// Доступ к элементам массива по индексу.
        /// </summary>
        /// <param name="i">Номер элемента в массиве.</param> 
        /// <returns>Объект класса Money.</returns>


        
        public Money this[int i]
        {
            get
            {
                if (i >= 0 || i < arr.Length)
                    return arr[i];
                else
                {
                    Console.WriteLine("Недопустимый индекс");
                    //return null;
                    throw new Exception();
                }
            }
            set {
                if (i >= 0 || i < arr.Length)
                {
                    arr[i] = value;
                }
                else
                    Console.WriteLine("Недопустимый индекс");
            } 
        }
        
//------------- МЕТОДЫ КЛАССА ---------------//
        
        /// <summary>
        /// Вывод элементов массива. 
        /// </summary>
        public void Show()
        {
            Console.WriteLine("\n\nВывод элементов массива:");
            if (Size == 0) Console.WriteLine("В массиве нет элементов.");
            for (int i = 0; i < Size; i++)
                arr[i].Show();
        }
        
        /// <summary>
        /// Создание объекта на основе данных пользователя. 
        /// </summary>
        /// <returns>Новый объект класса MoneyArray</returns>
        public static MoneyArray MoneyArrayInput()
        {
            Console.WriteLine("\n\nСоздание массива: ");
            int Size = Money.ConsoleInput("Введите количество элементов в массиве (от 1 до 10): ", 1, 10);

            Money[] array = new Money[Size];
            
            for (int i = 0; i < Size; i++)
            {
                array[i] = Money.MoneyInput(0,100);
            }

            return new MoneyArray(array);
        }

        /// <summary>
        /// Возвращает среднее арифметическое значение для элементов массива.        
        /// </summary>
        /// <returns>Новый объект класса Money</returns>
        public Money Average()
        {
            Money average = new Money();
            int kop = 0;
            for (int i = 0; i < Size; i++)
            {
                kop += arr[i].Kopecks + arr[i].Rubles * 100;
            }

            if (Size != 0)
                average.Kopecks = (kop /= Size);
            
            return average;
        }
        
    }
}
