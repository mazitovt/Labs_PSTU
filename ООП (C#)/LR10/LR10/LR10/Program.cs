//13)	млекопитающие, парнокопытные, птицы, животное;
//Основное содержание работы.
//Написать программу, в которой создается иерархия классов. 
//Записать объекты классов в массив, выполнить просмотр элементов массива. Показать использование виртуальных функций.
//Порядок выполнения работы. 
//1.Определить иерархию классов(в соответствии с вариантом). 
//2.Реализовать классы.
//3.Написать демонстрационную программу, в которой создаются объекты различных классов и помещаются в массив, после чего массив просматривается.
//4.Реализовать 2 варианта программы: с помощью виртуальных и не виртуальных методов. 
//5.Без виртуальных функций программа будет работать не правильно! Объяснить почему. Объяснить необходимость виртуальных функций


using System;

namespace LR10
{

    class Program
    {
        static void Main(string[] args)
        {

            Animal animal = new Animal();
            Bird bird = new Bird();
            Mammal mammal = new Mammal();
            Ungulate ungulate = new Ungulate();

            Console.WriteLine("Метод Eat. Определен как виртуальный в классе Animal, переопределен в каждом классе.\n");

            animal.Eat();
            bird.Eat();
            mammal.Eat();
            ungulate.Eat();

            Animal[] animals = new Animal[4];
            animals[0] = animal;
            animals[1] = bird;
            animals[2] = mammal;
            animals[3] = ungulate;

            animals[0].Age = 1;
            animals[0].Name = "Animal";

            animals[1].Age = 2;
            animals[1].Name = "Bird";

            animals[2].Age = 3;
            animals[2].Name = "Mammal";

            animals[3].Age = 4;
            animals[3].Name = "Urgulate";

            Console.WriteLine("\nМетод Show. Определен только в классе Animal.\n");

            foreach (Animal _animal in animals)
                _animal.Show();

            Console.WriteLine("\nМетод Voice. Определен в каждом классе. Вызов метода элементов массива типа Animal\n");

            foreach (var _animal in animals)
                _animal.Voice();

            Console.WriteLine("\nМетод Voice. Определен в каждом классе. Вызов метода при обращении к каждому объекту\n");

            animal.Voice();
            bird.Voice();
            mammal.Voice();
            ungulate.Voice();

        }
    }

    public class Animal
    {
        public static string className = "Животные";
        //public virtual string ClassName { get { return className; } }

        protected int age;
        protected string name;

        public virtual string Name { get { return name; } set { name = value; } }
        public virtual int Age { get { return age; } set { age = value; } }
        public int Weight { get; set; }

        public virtual void Eat()
        {
            Console.WriteLine("Animal eat");
        }

        public void Show()
        {
            Console.WriteLine("Name: " + Name + ", Age: " + Age.ToString() + ", Weight: " + Weight.ToString());
        }

        public void Voice()
        {
            Console.WriteLine("Animal voice");
        }

    }

    public class Bird : Animal
    {

        public static new string className = "Птицы";
        //public override string ClassName { get { return className; } }

        public override int Age { get { return age; } set { age = value * 2; } }

        public override void Eat()
        {
            Console.WriteLine("Bird eat");
        }
        public void Voice()
        {
            Console.WriteLine("Bird voice");
        }
    }

    public class Mammal : Animal
    {

        public static new string className = "Млекопитающие";
        //public override string ClassName { get { return className; } }

        public override string Name { get { return name; } set { name = "Mammal" + value; } }

        public override void Eat()
        {
            Console.WriteLine("Mammal eat");
        }
        public void Voice()
        {
            Console.WriteLine("Mammal voice");
        }

    }

    public class Ungulate : Mammal
    {
        public static new string className = "Парнокопытные";
        //public override string ClassName { get { return className; } }

        public override void Eat()
        {
            Console.WriteLine("Artiodactyls eat");
        }

        public void Voice()
        {
            Console.WriteLine("Ungulate voice");
        }
    }
}
