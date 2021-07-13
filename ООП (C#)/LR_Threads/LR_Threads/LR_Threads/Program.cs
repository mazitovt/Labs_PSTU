using System;
using System.Threading;

namespace LR_Threads
{
    public record Person(string Name, int Age, bool Man = true);

    class Program
    {

        
        static void Main(string[] args)
        {

            var p1 = new Person("boy", 23);
            var p2 = new Person("girl", 23, false);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
    }
}
