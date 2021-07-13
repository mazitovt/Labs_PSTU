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
using ExecutablesLibrary;
using System.Linq;
using System.Diagnostics;


namespace LR11_3
{
    class TestCollections
    {
        //public File[] ArrayOfFiles;

        public List<ShortFile> ShortFiles = new List<ShortFile>();

        public List<string> NamesOfShortFiles = new List<string>();

        public Dictionary<ShortFile, File> ShortFileToFile = new Dictionary<ShortFile, File>();

        public Dictionary<string, File> NameToFile = new Dictionary<string, File>();


        public File[] CreateRandom()
        {
            var size = ConsoleInput("Введите размер коллекции (от 1 до 9900): ", 1, 9900);
            return FileCreator.CreateFilesArray(size);
        }

        public void FillCollections()
        {
            FileCreator.CleanUniqueIds();

            ShortFiles.Clear();

            NamesOfShortFiles.Clear();

            ShortFileToFile.Clear();
            
            NameToFile.Clear();

            foreach (var file in CreateRandom())
            {
                ShortFile shortfile = file.BaseFile;

                ShortFiles.Add(shortfile);
                NamesOfShortFiles.Add(shortfile.ToString());
                ShortFileToFile[file.BaseFile] = file;
                NameToFile[shortfile.ToString()] = (File)file.Clone();
            }
        }

        public void ShowCollections()
        {

            if (ShortFiles.Count != 0)
            {
                Console.WriteLine(new string('-', 100));
                Console.WriteLine("\nShortFiles List<ShortFile>:\n");
                foreach (ShortFile file in ShortFiles)
                    Console.WriteLine(file);

                Console.WriteLine(new string('-', 100));
                Console.WriteLine("\nNamesOfShortFiles List<string>:\n");
                foreach (var name in NamesOfShortFiles)
                    Console.WriteLine(name);

                Console.WriteLine(new string('-', 100));
                Console.WriteLine("\nShortFileToFile Dictionary<ShortFile, File>:\n");
                foreach (var pair in ShortFileToFile)
                    Console.WriteLine($"{pair.Key,-45}| {pair.Value}");

                Console.WriteLine(new string('-', 100));
                Console.WriteLine("\nNameToFile Dictionary<string, File>:\n");
                foreach (var pair in NameToFile)
                    Console.WriteLine($"{pair.Key,-45}| {pair.Value}");
                return;
            }

            Console.WriteLine("\nКоллекции пусты.");

        }

        public void AddFile()
        {
            var file = FileCreator.CreateFile();

            ShortFile shortfile = file.BaseFile;
            string str = shortfile.ToString();

            ShortFiles.Add(file.BaseFile);
            NamesOfShortFiles.Add(str);
            ShortFileToFile[file.BaseFile] = file;
            NameToFile[str] = (File)file.Clone();
        }

        public void RemoveFile()
        {
            if (ShortFiles.Count != 0)
            {
                Console.WriteLine("Ключи в коллекции.");

                foreach (var i in Enumerable.Range(0, ShortFiles.Count()))
                    Console.WriteLine($"{i}: {ShortFiles[i]}");

                int index = ConsoleInput("Введите номер ключа для удаления: ", 0, ShortFiles.Count() - 1);

                string str = ShortFiles[index].ToString();

                ShortFileToFile.Remove(ShortFiles[index]);
                ShortFiles.RemoveAt(index);

                NameToFile.Remove(str);
                NamesOfShortFiles.Remove(str);
                return;
            }

            Console.WriteLine("\nКоллекции пусты.");
        }

        public void SearchForFiles()
        {
            try
            {
                var filesList = new List<(File file, string msg)>
                {
                    ((File)ShortFileToFile.Values.First().Clone(),"первый"),
                    ((File)ShortFileToFile.Values.Last().Clone(), "последний"),
                    ((File)ShortFileToFile.Values.ElementAt(ShortFileToFile.Values.Count / 2).Clone(), "средний"),
                    (new File { Name = "NotInDict", Id = 0, Size = 0, Publisher = new Publisher("NoPublisher", 0) }, "не существующий" )
                };

                foreach (var tuple in filesList)
                    Console.WriteLine($"{tuple.msg, 15} файл: {tuple.file}");

                foreach (var tuple in filesList)
                    FindFile(tuple.file, tuple.msg);
             } catch
            {
                Console.WriteLine("\nДобавьте элементы в коллекции.");
            }
        }

        public void FindFile(File file, string fileOrder)
        {
            void ContainingTest(Predicate<object> IsContained, object elem, string colName)
            {
                var sw = new Stopwatch();

                sw.Restart();

                if (IsContained(elem))
                {
                    sw.Stop();
                    Console.Write($"Файл найден за {sw.ElapsedTicks} ticks.");

                    StatisticsCollectoins.AddInfo(colName, fileOrder, sw.ElapsedTicks);
                }
                else
                {
                    sw.Stop();
                    Console.Write("Файл не найден.");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(new string('-', 100));

            Console.WriteLine($"\nИщем {fileOrder} файл в List<ShortFile>.");

            ContainingTest((elem) => ShortFiles.Contains(elem), file.BaseFile, "List<ShortFile>");

            Console.WriteLine($"\n\nИщем {fileOrder} файл в List<string>.");

            ContainingTest((elem) => NamesOfShortFiles.Contains(elem), file.BaseFile.ToString(), "List<string>");

            Console.WriteLine($"\n\nИщем {fileOrder} файл в Dictionary<ShortFile, File>.Keys.");

            ContainingTest((elem) => ShortFileToFile.ContainsKey((ShortFile)elem), file.BaseFile, "Dict<ShortFile, File>.Keys");

            Console.WriteLine($"\n\nИщем {fileOrder} файл в Dictionary<ShortFile, File>.Values.");

            ContainingTest((elem) => ShortFileToFile.ContainsValue((File)elem), file, "Dict<ShortFile, File>.Values");

            Console.WriteLine($"\n\nИщем {fileOrder} файл в Dictionary<string, File>.Keys.");

            ContainingTest((elem) => NameToFile.ContainsKey((string)elem), file.BaseFile.ToString(), "Dict<string, File>.Keys");

            Console.WriteLine($"\n\nИщем {fileOrder} файл в Dictionary<string, File>.Values.");

            ContainingTest((elem) => NameToFile.ContainsValue((File)elem), file, "Dict<string, File>.Values");
        }
          
        public static int ConsoleInput(string msg, int beg, int end)
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

            return elem;
        }
    }
}
