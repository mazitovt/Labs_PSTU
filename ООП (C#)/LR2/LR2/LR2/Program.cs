using System;

namespace LR2
{
    class Program
    {
        static void Main(string[] args) => Task();

        static double Series(double x) => (x-1)/(x+1);
    
        static double Series(double Prev, double x, int n)
        {
            double c0 = Series(x);
            double c1 = Math.Pow(c0, 2);
            double c2 = 1 - 1 / (n + 0.5);
            return (Prev * c1 * c2);

        }

        static void Task()
        {
            int n, k = 10;
            double e = 0.0001, a = 0.2, b = 1, x , step, r_n, SE, SN, Prev;
            step = (b-a) / k;

            Console.WriteLine("{0,6}|{1,25}|{2,25}|{3,25}|", "X", "SN", "SE", "Y");

            for (x = a; x <= b; x += step)
            {
                Console.WriteLine(" ".PadLeft(86, '-'));
                //Console.WriteLine("{0,6}|{1,25}|{2,25}|{3,25}|"," ", " ", " ", " ");
                
                x = Math.Round(x, 2);
                SN = Prev = Series(x);
                for (n = 1; n <= 10; n++)
                {
                    Prev = Series(Prev, x, n);
                    SN += Prev; 
                }

                n = 0;
                SE = 0;
                Prev = Series(x);
                while (!(Math.Abs(Prev) < e))
                {
                    SE += Prev;
                    n++;
                    Prev = Series(Prev, x, n);
                }

                var y = Math.Round((0.5 * Math.Log(x)), 3);
               
                Console.WriteLine("{0,6}|{1,25}|{2,25}|{3,25}|", x, Math.Round(SN,3), Math.Round(SE,3), y);                
            }
            Console.WriteLine(" ".PadLeft(86, '-'));
        }

    }
}
