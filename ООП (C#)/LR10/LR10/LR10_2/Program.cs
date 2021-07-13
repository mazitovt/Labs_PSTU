//1.Реализовать метод для выполнения заданных запросов. 
    //При необходимости (для выполнения запроса) в класс могут быть добавлены новые поля (по сравнению с частью 1). 
    //В программе должно быть минимум ввода с клавиатуры. 
    //Поля объектов задаются в тексте программы. 
    //С клавиатуры вводятся только параметры запроса.
//2.Реализовать не менее трех запросов, соответствующих иерархии классов (можно реализовать свои запросы). 


using LR10;
using System;
using System.Linq;

namespace LR10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] zoo = CreateZoo();

            Console.WriteLine("\nВсе животные зоопарка:");
            ShowAnimals(zoo);

            //Console.WriteLine("\nЗапрос 1. Количество млекопитающих в зоопарке: " + CountMammals(zoo));
            Console.WriteLine("\nЗапрос 1.1 Количество животных в зоопарке: " + CountSpecies(zoo, typeof(Animal)));
            Console.WriteLine("\nЗапрос 1.2 Количество птиц в зоопарке: " + CountSpecies(zoo, typeof(Bird)));
            Console.WriteLine("\nЗапрос 1.3 Количество млекопитающих в зоопарке: " + CountSpecies(zoo, typeof(Mammal)));
            Console.WriteLine("\nЗапрос 1.4 Количество парнокопытных в зоопарке: " + CountSpecies(zoo, typeof(Ungulate)));

            Console.WriteLine("\nЗапрос 2. Вывести информацию о птицах, возраст которых меньше заданного");

            Bird [] birdZoo = BirdInfo(zoo);

            ShowAnimals(birdZoo);

            Console.WriteLine("\nЗапрос 3. Средний вес животных заданного вида в зоопарке.");

            Type species = ChooseSpecies();

            Console.WriteLine($"Для представителей вида '{GetSpeciesName(species)}' средняя масса равна {AverageWeight(zoo, species)}.");

        }

        static Animal[] CreateZoo()
        {
            Animal animal = new Animal();
            Bird bird = new Bird();
            Bird bird2 = new Bird();
            Mammal mammal = new Mammal();
            Ungulate ungulate1 = new Ungulate();
            Ungulate ungulate2 = new Ungulate();

            Animal[] zoo = new Animal[6];
            zoo[0] = animal;
            zoo[1] = bird;
            zoo[2] = mammal;
            zoo[3] = ungulate1;
            zoo[4] = bird2;
            zoo[5] = ungulate2;

            zoo[0].Age = 1;
            zoo[0].Name = "Animal";
            zoo[0].Weight = 50;

            zoo[1].Age = 2;
            zoo[1].Name = "Bird1";
            zoo[1].Weight = 20;

            zoo[2].Age = 3;
            zoo[2].Name = "Mammal1";
            zoo[2].Weight = 100;

            zoo[3].Age = 4;
            zoo[3].Name = "Urgulate1";
            zoo[3].Weight = 250;

            zoo[4].Age = 5;
            zoo[4].Name = "Bird2";
            zoo[4].Weight = 30;

            zoo[5].Age = 6;
            zoo[5].Name = "Ungulate2";
            zoo[5].Weight = 350;

            return zoo;
        }

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
            Console.WriteLine();
            return elem;
        }

        static void ShowAnimals(Animal[] zoo)
        {
            foreach (var item in zoo.Select((value, index) => (value, index)))
            {
                Console.Write(item.index + 1 + ". ");
                item.value.Show();
            }
        }

        static int CountSpecies(Animal [] zoo, Type species) => zoo.Count(animal => species.IsInstanceOfType(animal));
 
        //static int CountMammals(Animal[] zoo) => zoo.Count((animal) => animal is Mammal);

        static Bird [] BirdInfo(Animal [] zoo)
        {
            int maxAge = ConsoleInput("Введите максимальный возраст [0 до 100]:", 0, 100);

            return zoo.Select(animal => animal as Bird).Where(b => b != null && b.Age < maxAge).ToArray();
        }

        static float AverageWeight(Animal[] zoo, Type species)
        {
            int Weight = zoo.Where(animal => species.IsInstanceOfType(animal)).Sum(animal => animal.Weight);

            //foreach (Animal _animal in zoo)
            //    if (species.IsInstanceOfType(_animal))
            //        Weight += _animal.Weight;

            return Weight / CountSpecies(zoo, species);            
        }

        static Type ChooseSpecies()
        {
            Console.WriteLine("\nВиды:\n1. Животные\n2. Птицы\n3. Млекопитающие\n4. Парнокопытные");

            Type[] arraySpecies = new Type[4] { typeof(Animal), typeof(Bird), typeof(Mammal), typeof(Ungulate) };

            int choice = ConsoleInput("Введите номер вида: ", 1, 4);

            Type species = arraySpecies[choice - 1];

            return species;
        }
       
        static string GetSpeciesName(Type species) => (species.GetField("className")).GetValue(null).ToString();
    }
}
