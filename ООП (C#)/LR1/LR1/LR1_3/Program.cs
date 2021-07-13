using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task();
        }


        static void Equation(double a, double b)
        {
            double res1 = (Math.Pow((a + b), 4) - Math.Pow(a, 4)) / (6 * Math.Pow(a, 2) * Math.Pow(b, 2) + 4 * a * Math.Pow(b, 3) + Math.Pow(b, 4) + 4 * b * Math.Pow(a, 3));
            double res2 = ((a + b) * (a + b) * (a + b) * (a + b) - a * a * a * a) / (6 * a * a * b * b + 4 * a * b * b * b + b * b * b * b + 4 * b * a * a * a);
            Console.WriteLine("С использование Math.Pow: " + res1);
            Console.WriteLine("Без использования Math.Pow: " + res2);
        }

        static void Equation(float a, float b)
        {
            float c = (float)(Math.Pow((a + b), 4));
            float d = (float)(Math.Pow(a, 4));
            float e = (float)(Math.Pow(a, 2));
            float f = (float)(Math.Pow(b, 2));
            float g = (float)(Math.Pow(b, 3));
            float h = (float)(Math.Pow(b, 4));
            float i = (float)(Math.Pow(a, 3));
            float res1 = (float)(c - d) / (6 * e * f + 4 * a * g + h + 4 * b * i);
            float res2 = (float)((a + b) * (a + b) * (a + b) * (a + b) - a * a * a * a) / (6 * a * a * b * b + 4 * a * b * b * b + b * b * b * b + 4 * b * a * a * a);
            Console.WriteLine("С использование Math.Pow: " + res1);
            Console.WriteLine("Без использования Math.Pow: " + res2);
        }


        static void Task()
        {
            double a = 1000d, b = 0.0001d;
            float c = 1000f, d = 0.0001f;
            Console.WriteLine("\nРезультат с типом double: ");
            Equation(a, b);
            Console.WriteLine("\nРезультат с типом float: ");
            Equation(c, d);
        }
    }
}
