//13.Списки студентов нескольких групп 1 курса хранятся в отдельных файлах – один файл на одну группу.
//a.	Добавлять, удалять, корректировать, просматривать записи файлов.
//b.	Создавать новый файл, в котором будет храниться общий список студентов 1 курса, отсортированный по алфавиту.


using System;
using System.Collections.Generic;
using System.IO;

namespace LR8
{
    class Program
    {
        static string dir = "E:/DB/1_kurs/";
        static void Main(string[] args)
        {
            StreamWriter sw = File.CreateText(dir + "2.txt");

            Student st = new Student
            {
                first_name = "sdf",
                second_name  = "abc",
                rating = 5
            };

            Console.WriteLine(st);
            sw.Write(st);
            sw.Close();
            //StreamReader sr = File.OpenText(dir + "2.txt");
            //Console.WriteLine(sr.ReadToEnd());
        }

        //static void Menu()
        //{
        //    char[] array = new char[0];
        //    string stroke = "";
        //    int choice;
        //    bool exit = false;

        //    while (!exit)
        //    {
        //        Console.WriteLine("\nМеню:" +
        //                        "\n\t1. Создать одномерный массив;" +
        //                        "\n\t2. Распечатать массив;" +
        //                        "\n\t3. Удалить цифры;" +
        //                        "\n\t4. Создать строку;" +
        //                        "\n\t5. Перевернуть слова и расположить в порядке убыванию длины;" +
        //                        "\n\t6. Распечатать строку;" +
        //                        "\n\t7. Выход из программы.");

        //        choice = IntInput("Ваш выбор: ", 1, 7);

        //        if (array.Length == 0 && choice >= 2 && choice <= 3)
        //            Console.WriteLine("\nОШИБКА. Создайте массив!");

        //        else if (stroke == "" && choice >= 5 && choice <= 6)
        //            Console.WriteLine("\nОШИБКА. Создайте строку!");

        //        else
        //        {
        //            switch (choice)
        //            {
        //                case 1:
        //                    array = CreateArray();
        //                    break;
        //                case 2:
        //                    Console.WriteLine("\nВывод элементов массива.\n");
        //                    PrintArray(array);
        //                    break;
        //                case 3:
        //                    Console.WriteLine("\nУдаление цифр из массива.\n");
        //                    array = DeleteDigits(array);
        //                    break;
        //                case 4:
        //                    stroke = CreateString();
        //                    break;
        //                case 5:
        //                    stroke = ReverseString(stroke);
        //                    break;
        //                case 6:
        //                    Console.WriteLine(stroke);
        //                    break;
        //                case 7:
        //                    exit = true;
        //                    break;
        //            }
        //        }
        //    }
        //    Console.WriteLine("\nЗавершение работы программы");
        //}
    }

    public class Group
    {
        public List<Student> Students { get; set; }
        public string Name { get; set; }
        public int Semestr { get; set; }
        public string Curator { get; set; }
    }

    public class Student
    {
        public string first_name { get; set; }
        public string second_name { get; set; }
        public int rating { get; set; }

        public override string ToString()
        {
            return first_name + " " + second_name + " " + rating;
        }
    }

}
