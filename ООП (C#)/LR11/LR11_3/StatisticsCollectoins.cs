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
using System.Collections.Generic;
using System.Linq;

namespace LR11_3
{
    public static class StatisticsCollectoins
    {
        //public static List<Dictionary<string, int[]>> list = new List<Dictionary<string, int[]>>();


        // "имя_коллекции" -> "порядковый_номер_файла" -> "список полученных данных"
        public static Dictionary<string, Dictionary<string, List<long>>> data = new Dictionary<string, Dictionary<string, List<long>>>
        {
            ["List<ShortFile>"] = null,
            ["List<string>"] = null,
            ["Dict<ShortFile, File>.Keys"] = null,
            ["Dict<ShortFile, File>.Values"] = null,
            ["Dict<string, File>.Keys"] = null,
            ["Dict<string, File>.Values"] = null
        };

        public static void Initialize()
        {
            var keys = data.Keys.ToArray();
            foreach (var key in keys)
            {
                data[key] = new Dictionary<string, List<long>>()
                {
                    ["первый"] = new List<long>(),
                    ["средний"] = new List<long>(),
                    ["последний"] = new List<long>()
                };
            }
        }

        public static void AddInfo(string colName, string elemOrder, long ticks)
        {
            data[colName][elemOrder].Add(ticks);
        }

        public static void PrintStatistics()
        {
            try
            {
                Console.WriteLine($"{" ", 30} | {"первый", 10} | {"средний", 10} | {"последний", 10} |");
                Console.WriteLine(new string('-', 71));

                foreach(var p in data)
                {
                    Console.Write($"{p.Key, 30} | {Math.Round(p.Value["первый"].Average()), 10} | {Math.Round(p.Value["средний"].Average()), 10} | {Math.Round(p.Value["последний"].Average()), 10} |\n");             
                }

                Console.WriteLine("Количество выборок: " + data.Values.First().Values.First().Count);
            } catch
            {
                Console.WriteLine("\nНедостаточно данных. Произведите поиск файлов (пункт 3)");
            }
        }
    }
}
