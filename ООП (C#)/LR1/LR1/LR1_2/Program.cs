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

        static bool Circle(double x1, double y1, double r)
        {
            //var c = Math.Pow(x1, 2) + Math.Pow(y1, 2);
            if (((Math.Pow(x1, 2) + Math.Pow(y1, 2) <= Math.Pow(r, 2))) && (x1 * y1 <= 0))
            {
                return true;
            }
            else return false;
        }
        static void Read(ref double x1, ref double y1, ref double r)
        {
            bool flag;
            do
            {
                Console.WriteLine("Введите число x1: ");
                string buff = Console.ReadLine();
                buff = buff.Replace(".", ",");
                flag = double.TryParse(buff, out x1);
                Console.WriteLine("Введите число y1: ");
                buff = Console.ReadLine();
                buff = buff.Replace(".", ",");
                flag &= double.TryParse(buff, out y1);
                Console.WriteLine("Введите число r: ");
                buff = Console.ReadLine();
                buff = buff.Replace(".", ",");
                flag &= double.TryParse(buff, out r);
            } while (!flag || r < 0);
        }

        static void Test()
        {
            int count = 0;
            var testDict = new Dictionary<List<double>, bool>
            {
                [new List<double> { 5, 5, 1 }] = false,
                [new List<double> { -1, -1, 1 }] = false,
                [new List<double> { -1, 1, 1 }] = false,
                [new List<double> { 1, -1, 1 }] = false,
                [new List<double> { 1, 1, 1 }] = false,
                [new List<double> { 0, 0, 1 }] = true,
                [new List<double> { 1, 0, 1 }] = true,
                [new List<double> { 0, 1, 1 }] = true,
                [new List<double> { -1, 0, 1 }] = true,
                [new List<double> { 0, -1, 1 }] = true,
                [new List<double> { 0.99, 0, 1 }] = true,
                [new List<double> { 0, 0.99, 1 }] = true,
                [new List<double> { -0.99, 0, 1 }] = true,
                [new List<double> { 0, -0.99, 1 }] = true,
                [new List<double> { 0.1, 0.1, 1 }] = false,
                [new List<double> { -0.1, -0.1, 1 }] = false,
                [new List<double> { 0.1, -0.1, 1 }] = true,
                [new List<double> { -0.1, 0.1, 1 }] = true,
                [new List<double> { 0.8, 0.6, 1 }] = false,
                [new List<double> { -0.8, 0.6, 1 }] = true,
                [new List<double> { 0.8, -0.6, 1 }] = true,
                [new List<double> { -0.8, -0.6, 1 }] = false
            };

  
            Console.WriteLine("\nСписок тестов");
            Console.WriteLine("{0,7}{1,7}{2,7}{3,10}", "X", "Y", "R", "Попадание");

            foreach (var i in testDict)
            {
                Console.WriteLine("{0,7}{1,7}{2,7}{3,10}", i.Key[0], i.Key[1], i.Key[2], i.Value);
            }

            Console.WriteLine("\n Входные данные (X,Y,R)\t Ожидаемый результат\tРеальный результат");

            foreach (var i in testDict)
            {
                var res = Circle(i.Key[0], i.Key[1], i.Key[2]);
                if (res == i.Value) count++;
                Console.WriteLine("{0,7},{1,7},{2,7}{3,21}{4,22}", i.Key[0], i.Key[1], i.Key[2], i.Value, res);
            }

            Console.WriteLine("\n\nРезультаты тестирования:\n\tВсего тестов:\t{0}\n\tУспешно:\t{1}\n\tПровалено:\t{2}", testDict.Count, count, (testDict.Count - count));
        }

        static void Task()
        {
            double x1 = 0, y1 = 0, r = 0;
            Read(ref x1, ref y1, ref r);

            if (Circle(x1, y1, r))
            {
                Console.WriteLine("\nТочка с координатами ({0},{1}) принадлежит области с радиусом {2}", x1, y1, r);
            }
            else Console.WriteLine("\nТочка с координатами ({0},{1}) НЕ принадлежит области с радиусом {2}", x1, y1, r);

            Test();
        }
    }
}
