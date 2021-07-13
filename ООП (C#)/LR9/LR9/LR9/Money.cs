//Вычитание копеек(int) из объекта типа Money (учесть, что  рублей и копеек  не может быть меньше 0). 
//Результат должен быть типа Money. 

//Унарные операции:
//--вычитание  копейки из объекта типа Money (учесть, что рублей и копеек  не может быть меньше 0).
//++добавление копейки к объекту типа Money (учесть, что копеек  не может быть больше 99).
//При этом нам не надо определять отдельно операторы для префиксного и для постфиксного инкремента (а также декремента), так как одна реализация будет работать в обоих случаях.

//Операции приведения типа:
//int(явная) результатом является количество рублей (копейки отбрасываются);
//bool(неявная) результатом является true, если  денежная сумма не равна 0.
//Бинарные операции:
//-Money m, целое число(лево- и право- сторонние операции). Увеличиваются копейки, необходимо учесть, что копеек не может быть больше 99.
//-Money m1, Money m2 вычитание денежных сумм, учесть, что результат не может быть меньше 0.

//1.Реализовать класс(в отдельном файле), полем которого является одномерный массив из элементов заданного в варианте типа. Например, для класса Fraction нужно создать класс FractionArray следующим образом:
//class FractionArray
//{
//	Fraction[] arr;
//	int size;
//. . . .
//}
//В классе реализовать 
//•	конструктор без параметров,
//•	конструктор с параметрами, заполняющий элементы случайными значениями,
//•	конструктор с параметрами, позволяющий заполнить массив элементами, заданными пользователем с клавиатуры,
//•	индексатор (для доступа к элементам массива),
//•	метод для просмотра элементов массива.
//2.	Написать демонстрационную программу, позволяющую создать массив разными способами и распечатать элементы массива. Подсчитать количество созданных объектов.
//3.	Выполнить указанное в варианте задание (если необходимо, перегрузить нужные для выполнения задачи операции или функции).

//13  Money Среднее арифметическое

using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Markup;


namespace LR9
{
    public class Money
    {

//-------------- ПОЛЯ КЛАССА ----------------//

		private int rubles = 0;
		private int kopecks = 0;
		
//------------- СВОЙСТВА КЛАССА -------------//

		public int Rubles
        {
			get { return rubles; }
			set 
			{
				if (value < 0)
					Console.WriteLine("\nОшибка: нельзя присвоить отрицательное значение");
				else rubles = value; 
			}
        }
		public int Kopecks
        {
			get { return kopecks; }
			set 
			{	
				if (value < 0) 
					Console.WriteLine("\nОшибка: нельзя присвоить отрицательное значение");
				else
				{
					Rubles += value / 100;
					kopecks = value % 100;
				}
			}
        }
		public static int ObjectCount { get; set; } = 0;

//----------- КОНСТРУКТОРЫ КЛАССА -----------//

		//static Money() => ObjectCount = 0;

		public Money()
        {
			Rubles = 0;
			Kopecks = 0;
			ObjectCount++;
        }

		public Money(int rubles, int kopecks): this()
		{ 
			Rubles = rubles;
			Kopecks = kopecks;
        }

		public Money(int kopecks): this() => Kopecks = kopecks;


//---------- ПЕРЕГРУЖЕННЫЕ МЕТОДЫ КЛАССА ---------//

        public override bool Equals(object obj)
        {
			return Rubles == ((Money)obj).Rubles && Kopecks == ((Money)obj).Kopecks;
        }

//---------- СТАТИЧЕСКИЕ МЕТОДЫ КЛАССА ---------//

        // Возвращает пользовательский ввод с консоли
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

		// Создает объект на основе пользовательского ввода
		public static Money MoneyInput(int beg, int end)
        {
			int r = ConsoleInput($"Введите рубли (от {beg} до {end}): ", beg, end);
			int k = ConsoleInput($"Введите копейки (от {beg} до {end}): ", beg, end);

			return new Money(r,k);
        }

		// Вычитает копейки (статический)

		public static Money StaticSubtractKopecks(Money m, int kopecks)
        {
			int k = m.Sum() - kopecks;
			if (k < 0)
			{
				Console.WriteLine("\nОшибка: нельзя вычесть такое количество копеек.");
				return new Money(m.Rubles, m.Kopecks);
			}
			else
				return new Money(k);		
		}

		// Выводит в консоль информацию о количестве созданных объектов
		public static void ShowObjCount()
		{
			Console.WriteLine($"\nЗа время работы программы {(ObjectCount == 1 ? "был создан" : "было создано")} {ObjectCount} {(ObjectCount % 10 > 0 && ObjectCount % 10 < 5 ? ObjectCount % 10 == 1 ? "объект" : "объекта" : "объектов")} класса Money.");
		}

//-------------- МЕТОДЫ КЛАССА --------------//

		// Вывод количества рублей и копеек в консоль.
		public void Show()
        {
			Console.WriteLine($"\nСумма: {Rubles} {(Rubles % 10 > 0 && Rubles % 10 < 5 ? Rubles % 10 == 1 ? "рубль" : "рубля" : "рублей")} и " +
										   $"{Kopecks} {(Kopecks % 10 > 0 && Kopecks % 10 < 5 ? Kopecks % 10 == 1 ? "копейка" : "копейки" : "копеек")}.");
        }
		
		// Возвращает сумму в копейках
		public int Sum()
        {
			return Rubles * 100 + Kopecks;
        }

		// Вычитает копейки
		// Если вычитаемое количество больше суммы, то вычитание не происходит
		public Money SubtractKopecks(int kopecks)
		{
			int k = Sum() - kopecks;
			if (k < 0)
				Console.WriteLine("\nОшибка: нельзя вычесть такое количество копеек.");
            else
            {
				Rubles = 0;
				Kopecks = k;
            }

			return this; 
		}

		// Установливает нули в полях
		public void SetToZero()
        {
			Kopecks = 0;
			Rubles = 0;
        }

//------------- УНАРНЫЕ ОПЕРАЦИИ ------------//

		public static Money operator ++(Money m)
        {
			return new Money {Rubles = m.Rubles, Kopecks =  m.Kopecks + 1 };
        }
		public static Money operator --(Money m)
		{
			return m.SubtractKopecks(1);
		}

//----------- ПРЕОБРАЗОВАНИЯ ТИПОВ ----------//

		public static explicit operator int(Money m)
		{
			return m.Rubles;
		}

		public static implicit operator bool(Money m)
		{
			return m.Rubles > 0 || m.Kopecks > 0;
		}
		
//------------ БИНАРНЫЕ ОПЕРАЦИИ ------------//

		//------------- Money +- Money --------------//
		public static Money operator -(Money m1, Money m2)
        {
			return Money.StaticSubtractKopecks(m1, m2.Sum());
        }
		public static Money operator +(Money m1, Money m2)
		{
			return new Money { Kopecks = m1.Sum() + m2.Sum() };
		}

		//-------------- Money +- int ---------------//
		public static Money operator -(Money m, int in_kopecks)
		{
			return m.SubtractKopecks(in_kopecks);
		}
		public static Money operator +(Money m, int in_kopecks)
		{
			if (in_kopecks < 0)
				return m -= -in_kopecks;
			else 
				return new Money { Rubles = m.Rubles, Kopecks = m.Kopecks + in_kopecks };
		}

		//-------------- int +- Money ---------------//
		public static int operator +(int num, Money m)
		{
			return num + m.Sum();
		}
		public static int operator -(int num, Money m)
		{
			return num - m.Sum();
		}

		//-------------- Money / int ---------------//
		public static Money operator / (Money m, int divider)
        {
			if (divider <= 0)
            {
				throw new Exception();
            }
			else
            {
				return new Money(m.Sum() / divider);
            }
        }

	}
}