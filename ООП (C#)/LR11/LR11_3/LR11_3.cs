//2.3.Задание 3.
// Создать иерархию классов (базовый  – производный) в соответствии с вариантом (см. лаб. раб. №10).
//В производном классе определить свойство, которое возвращает ссылку на объект базового класса 
//  (это свойство должно возвращать ссылку на объект  базового класса, а не ссылку на вызывающий объект производного класса). 
//Определить класс TestCollections, который содержит поля следующих типов 
//Коллекция_1<TKey> ;
//Коллекция_1<string>;
//Коллекция_2<TKey, TValue>;
//Коллекция_2<string, TValue>.
//где тип ключа TKey и тип значения TValue связаны отношением базовый-производный (см. задание 1), 
//Коллекция_1 и Коллекция_2 – коллекции из пространства имен System.Collections.Generic.
//Написать конструктор класса TestCollections, в котором создаются коллекции с заданным числом элементов. 
//Предусмотреть автоматическую генерацию элементов коллекции таким образом, что каждый объект (Student) содержит подобъект базового класса (Person). 
//Все четыре коллекции должны содержать одинаковое число элементов. Каждому элементу из коллекции Коллекция_1<TKey> должен отвечать элемент в коллекции Коллекция_2<TKey, TValue> с равным значением ключа. 
//Список Коллекция_1<string> состоит из строк, которые получены в результате вызова метода ToString() для объектов TKey из списка Коллекция_1<TKey>. Каждому элементу списка Коллекция_1<string> отвечает элемент в Коллекция_2 <string, TValue> с равным значением ключа типа string.
//Для четырех разных элементов – первого, центрального, последнего и элемента, не входящего в коллекцию – надо измерить время поиска элемента в коллекциях Коллекция_1<TKey> и Коллекция_1<string> с помощью метода Contains; элемента по ключу в коллекциях Коллекция_2< TKey, TValue> и Коллекция_2 <string, TValue > с помощью метода ContainsKey; значения элемента в коллекции Коллекция_2< TKey, TValue > с помощью метода ContainsValue.  Обратите внимание на то, что искать нужно сами элементы, а не ссылки на них!
//Предусмотреть методы для работы с  коллекциями (добавление и удаление элементов).

using System;
using System.Linq;

namespace LR11_3
{

    class LR11_3
    {
        static TestCollections test;
        static void Main(string[] args) => Menu();
        
        static void Menu()
        {
            StatisticsCollectoins.Initialize();
            test = new TestCollections();

            int choice;
            bool exit = false, flag;
            while (!exit)
            {
                Console.WriteLine("\n\nМеню\n0. Выход\n1. Добавить элемент.\n2. Удалить элемент.\n3. Измерение времени поиска элементов.\n4. Распечатать коллекции.\n5. Заполнить коллекцию (заново).\n6. Статистика");

                do
                {
                    Console.Write("\nВаш выбор: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (!(0 <= choice && choice <= 6) || !flag) Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                } while (!(0 <= choice && choice <= 6) || !flag);
            
                switch (choice)
                {
                    case 1: test.AddFile(); break;
                    case 2: test.RemoveFile(); break;
                    case 3: test.SearchForFiles(); break;
                    case 4: test.ShowCollections(); break;
                    case 5: test.FillCollections(); break;
                    case 6: StatisticsCollectoins.PrintStatistics(); break;

                    case 0: exit = true; break;
                }                
            }
            Console.WriteLine("\nЗавершение работы программы");
        }

        static void MakeBigCollections()
        {
            foreach (var _ in Enumerable.Range(0, 100))
            {
                test.FillCollections();
                test.SearchForFiles();
            }
        }
    }
}
