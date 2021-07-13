using System;
using System.Numerics;

namespace LR9
{
    class Program
    {
        static void Main(string[] args)
        {
            //DemoMoney();
            //DemoMoneyArray();

            Test1();

        }

        public static void Test1()
        {
            MoneyArray ma = new MoneyArray(3);
            ma[0] = new Money(0, 3);
            ma[1] = new Money(6, 2);
            ma[2] = new Money(3, 1);


            Money avg = Average(ma);

            try
            {
                Console.WriteLine(ma[6]); 
            }
            catch ( Exception e)
            {
                Console.WriteLine(e.Message);
            }

            avg.Show();

        }

        private static void DemoMoney()
        {

            Money m1,m2,m3;
            int x;

            Console.WriteLine("\n\nТестирование конструкторов." +
                "\nПри передаче отрициательного числа в поле устанавливается значений по умолчанию - 0");

            m1 = new Money(000, 000);
            Console.WriteLine("\nm1 = new Money(000, 000);");
            m1.Show();

            m1 = new Money();
            Console.WriteLine("\nm1 = new Money();");
            m1.Show();

            m1 = new Money(100, 100);
            Console.WriteLine("\nm1 = new Money(100, 100);");
            m1.Show();

            m1 = new Money(-100, 100);
            Console.WriteLine("\nm1 = new Money(-100, 100);");
            m1.Show();

            m1 = new Money(100, -100);
            Console.WriteLine("\nm1 = new Money(100, -100);");
            m1.Show();

            m1 = new Money(-100, -100);
            Console.WriteLine("\nm1 = new Money(-100, -100);");
            m1.Show();

            m1 = new Money(-100);
            Console.WriteLine("\nm1 = new Money(-100);");
            m1.Show();

            m1 = new Money(100);
            Console.WriteLine("\nm1 = new Money(100);");
            m1.Show();

            m1 = new Money(50);
            Console.WriteLine("\nm1 = new Money(50);");
            m1.Show();

            //Console.WriteLine("\n\nТестирование SubtractKopecks." +
            //    "\nПримечание: вычитание не происходит, если 0 рублей и 0 копеек");

            //m1 = new Money(10, 1);
            //m1.Show();
            //m1 = m1.SubtractKopecks(1);
            //m1.Show();
            //m1 = m1.SubtractKopecks(1);
            //m1.Show();
            //m1 = m1.SubtractKopecks(998);
            //m1.Show();
            //m1 = m1.SubtractKopecks(1);
            //m1.Show();
            //m1 = m1.SubtractKopecks(1);
            //m1.Show();


            //Console.WriteLine("\n\nТестирование StaticSubtractKopecks." +
            //    "\nПримечание: вычитание не происходит, если 0 рублей и 0 копеек");

            //m1 = new Money(10, 1);
            //m1.Show();
            //m1 = Money.StaticSubtractKopecks(m1, 1);
            //m1.Show();
            //m1 = Money.StaticSubtractKopecks(m1, 1);
            //m1.Show();
            //m1 = Money.StaticSubtractKopecks(m1, 998);
            //m1.Show();
            //m1 = Money.StaticSubtractKopecks(m1, 1);
            //m1.Show();
            //m1 = Money.StaticSubtractKopecks(m1, 1);
            //m1.Show();


            //Console.WriteLine("\n\nТестирование унарных операций." +
            //    "\nПримечание: вычитание не происходит, если 0 рублей и 0 копеек");


            //m1 = new Money(1, 0);
            //m1++;
            //m1.Show();
            //m1 = new Money(1, 99);
            //m1++;
            //m1.Show();
            //m1++;
            //m1.Show();

            //m1--;
            //m1.Show();
            //m1--;
            //m1.Show();
            //m1 = new Money(0, 1);
            //m1.Show();
            //m1--;
            //m1.Show();
            //m1--;
            //m1.Show();

            //Console.WriteLine("\n\nТестирование преобразования типов." +
            //   "\nПримечание: в переменную записывается число рублей." +
            //   "\nПримечание: в переменную записывается true, если сумма не равна 0.");

            //m1 = new Money();
            //x = (int)m1;
            //Console.WriteLine(x);
            //m1 = new Money(0, 1);
            //x = (int)m1;
            //Console.WriteLine(x);
            //m1 = new Money(0, 100);
            //x = (int)m1;
            //Console.WriteLine(x);
            //m1 = new Money(2, 100);
            //x = (int)m1;
            //Console.WriteLine(x);

            //bool flag;
            //m1 = new Money();
            //flag = m1;
            //Console.WriteLine(flag);
            //m1 = new Money(1, 1);
            //flag = m1;
            //Console.WriteLine(flag);
            //m1 = new Money(0, 1);
            //flag = m1;
            //Console.WriteLine(flag);

            //Console.WriteLine("\n\nТестирование операторов сложения и вычитания." +
            //   "\nПримечание: ___ ");

            //m1 = new Money(0, 1);
            //m2 = new Money(0, 1);
            //m3 = m1 - m2;
            //m3.Show();
            //m2 = m3 - m1;
            //m2.Show();
            //m1 = new Money(1, 0);
            //m2 = new Money(50);
            //m3 = m2 - m1;
            //m3.Show();


            //m1 = new Money(0, 1);
            //m2 = new Money(0, 1);
            //m3 = m1 + m2;
            //m3.Show();
            //m2 = m3 + m1;
            //m2.Show();

            //m1 = new Money(1, 0);
            //m1 += 100;
            //m1.Show();
            //m1 += -100;
            //m1.Show();
            //m1 += 1;
            //m1.Show();

            //m1 = new Money(1, 1);
            //x = 500;
            //x -= m1;
            //Console.WriteLine(x);
            //x += new Money(2, 1);
            //Console.WriteLine(x);

            //Console.WriteLine("\n\nТестирование счетчика количества объектов." +
            //   "\nПримечание: ___ ");

            //m1 = new Money();
            //Console.WriteLine(Money.ObjectCount);

            //m2 = new Money();
            //Console.WriteLine(Money.ObjectCount);

            //m3 = new Money();
            //Console.WriteLine(Money.ObjectCount);
        }

        private static void DemoMoneyArray()
        {

            MoneyArray m = new MoneyArray();

            Console.WriteLine("\n\nТестирование конструкторов.");
            Console.WriteLine("\nКонструктор по умолчанию (пустой массив).");
            m.Show();
            m = new MoneyArray(5);
            Console.WriteLine("\nКонструктор с одним параметром (в массиве 5 элементов).");
            m.Show();
            m = new MoneyArray(5, 15);
            Console.WriteLine("\nКонструктор с двумя параметрами (в массиве пять элементов заполненных случаными числами).");
            m.Show();
            Console.WriteLine("\nСоздание массива из ввода пользователя.");
            m = MoneyArray.MoneyArrayInput();
            m.Show();

            Console.WriteLine("\n\nТестирование доступа по индексу.");
            m = new MoneyArray(5);
            m[0] = new Money(350);
            m[4] = new Money(9,9);
            m[2] = m[4];
            m.Show();
            Console.WriteLine("\nПопытка обратиться к несуществующему элементу массива");
            try
            {
                Console.WriteLine(m[5]); // эта строка вызовет ошибку
            }catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("\n" + e.Message);
            }

            Console.WriteLine("\n\nТестирование методов поиска среднего арифметического.");
            m.Show();
            Console.WriteLine("\n\nСреднее значение (общее): ");
            m.Average().Show();
            Console.WriteLine($"\nСреднее значение только рублей: {m.AverageRubles}" +
                              $"\nСреднее значение только копеек: {m.AverageKopecks}");


        }

        private static void Test()
        {

            //MoneyArray ma = new MoneyArray(5);
            //ma.Show();

            MoneyArray ma = new MoneyArray(new Money[] {
                new Money(1,50),
                new Money(2,71),
                new Money(3,99)
            });
            ma.Show();



            Console.WriteLine(ma.AverageKopecks);
            Console.WriteLine(ma.AverageRubles);
            Money.ShowObjCount();


            //MoneyArray ma1 = MoneyArray.MoneyArrayInput();
            //ma1.Show();
            //MoneyArray ma1 = new MoneyArray(3);
            //ma1.Show();



            //



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
1. Создать объект Money;

2. Создать объект MoneyArray;
3. ;
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

                if (array.Length == 0 && choice >= 2 && choice <= 8)
                {
                    Console.WriteLine("\nСоздайте массив!");
                }
                else
                {
                    switch (choice)
                    {
                        //case 1: array = CreateArray(); break;
                        //case 2: PrintArray(array); break;
                        //case 3: array = DeleteElements(array); break;
                        //case 4: array = AddElements(array); break;
                        //case 5: ReplaceElements(array); break;
                        //case 6: FindElement(array); break;
                        //case 7: SortArray(array); break;
                        //case 8: BinarySearch(array); break;
                        //case 9: exit = true; break;
                    }
                }

            }
            Console.WriteLine("\nЗавершение работы программы");
        }
        
        public static Money Average(MoneyArray ma)
        {
            Money average = new Money();

            for (int i = 0; i < ma.Size; i++)         
                average += ma[i];
            
            if (ma.Size != 0)
                average /= ma.Size;

            return average;
        }
    }
}

