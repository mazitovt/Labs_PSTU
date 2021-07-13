using System;
using System.Collections.Generic;


namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task();
        }

        static void Read(ref float m, ref float n)
        {
            bool flag;
            do
            {
                Console.WriteLine("Введите число m: ");
                string buff = Console.ReadLine();
                buff = buff.Replace(".", ",");
                flag = float.TryParse(buff, out m);
                Console.WriteLine("Введите число n: ");
                buff = Console.ReadLine();
                buff = buff.Replace(".", ",");
                flag &= float.TryParse(buff, out n);
            } while (!flag);
        }

        static void Read_x(ref double x)
        {
            bool flag;
            do
            {
                Console.WriteLine("Введите число x [-1;INF): ");
                string buff = Console.ReadLine();
                buff = buff.Replace(".", ",");
                flag = double.TryParse(buff, out x);
            } while (x < -1 || !flag);
        }

        static void TestTask4()
        {
            int count = 0;
            var testDict = new Dictionary<double, double>
            {
                [-16] = -1,
                [-5] = -1,
                [-2] = -1,
                [-1.1] = -1,
                [-1] = 1,
                [-0.9] = 1.172,
                [0] = 0,
                [0.9] = 2.269,
                [1] = 2.414,
                [1.1] = 2.557,
                [2] = 3.786,
                [5] = 7.549,
                [16] = 20.243
            };


            Console.WriteLine("\nСписок тестов");
            Console.WriteLine("{0,7}{1,15}", "X", "Результат");

            foreach (var i in testDict)
            {
                Console.WriteLine("{0,7}{1,15}", i.Key, i.Value);
            }

            //List<double> testSet = new List<double> { -5, -2, -1.1, -1, -0.9, 0, 0.9, 1, 1.1, 2, 5 };
            Console.WriteLine();
            Console.WriteLine("ТЕСТИРОВАНИЕ".PadLeft(23, '-').PadRight(35, '-'));
            Console.WriteLine("\tX\tER\t   AR");
            foreach (var i in testDict)
            {
                var x = i.Key;
                var res = Task4(ref x);
                res = Math.Round(res, 3);
                if (res == i.Value) count++;

                Console.WriteLine("{0,9}{1,9}{2,11}", i.Key, i.Value, res);

            }
            Console.WriteLine("\n\nРезультаты тестирования:\n\tВсего тестов:\t{0}\n\tУспешно:\t{1}\n\tПровалено:\t{2}", testDict.Count, count, (testDict.Count - count));

        }
        static double Task4(ref double x)
        {

            if (x < -1)
            {
                return -1;
            }
            else
            {
                var res = Math.Sqrt(x + Math.Sqrt(Math.Sqrt(Math.Abs(x)))) + Math.Abs(x);
                return res;
            }
        }
        static void Task()
        {
            float m = 0, n = 0;
            double x = 0;
            Read(ref m, ref n);
            var res1 = n++ * m;
            Console.WriteLine("\t1) Результат выражения \"(n++*m)\" - " + (res1) + ", тип выражения - " + res1.GetType());
            var res2 = m-- < n;
            Console.WriteLine("\t2) Результат выражения \"(m--<n)\" - " + (res2) + ", тип выражения - " + res2.GetType());
            var res3 = ++m > n;
            Console.WriteLine("\t3) Результат выражения \"(++m>n)\" - " + (res3) + ", тип выражения - " + res3.GetType());
            Read_x(ref x);
            var res4 = Task4(ref x);
            Console.WriteLine("\t4) Результат выражения - " + res4 + " , тип выражения - " + res4.GetType());
            TestTask4();
        }
    }
}
