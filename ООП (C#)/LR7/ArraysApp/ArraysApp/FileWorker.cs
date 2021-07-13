using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysApp
{
    public static class FileWorker
    {
        private static readonly string DIR = "E:/Texts/";

        public static string[] GetFilesList()
        {
            string[] files = Directory.GetFiles(DIR);
            for (int i = 0; i < files.Length; i++)
                files[i] = Path.GetFileName(files[i]);

            return files;
        }

        public static void SaveToFile(string name, TabPageModified page)
        {
            var array = ArrayWorker.GetArray(page.Type);
            SaveToFile(name, array);
        }

        public static void SaveToFile(string name, string[] array)
        {
            string path = DIR + name + ".txt";

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("1");

                sw.Write(String.Join(" ", array));
            }

        }

        public static void SaveToFile(string name, string[,] array)
        {
            string path = DIR + name + ".txt";

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write("2");
                int i = 0;
                foreach (var item in array)
                {
                    if (i % array.GetLength(1) == 0)
                        sw.WriteLine();
                    else
                        sw.Write(" ");
                    sw.Write(item);
                    i++;
                }
            }


        }

        public static void SaveToFile(string name, string[][] array)
        {
            string path = DIR + name + ".txt";

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write("3");

                foreach (var item in array)
                {
                    sw.WriteLine();
                    sw.Write(String.Join(" ", item));
                }
            }

        }

        public static bool IsTypeCorrect(string name, int type)
        {
            StreamReader sr = File.OpenText(DIR + name);
            int t = Convert.ToInt32(sr.ReadLine());
            return type == t;
        }

        public static string ReadFromFile(string name)
        {
            StreamReader sr = File.OpenText(DIR + name);
            sr.ReadLine();
            return sr.ReadToEnd();
        }

    }
}
