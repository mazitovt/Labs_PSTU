//Постановка задачи 1.
//1.	Создать динамический массив (одномерный, двумерный, рваный) из элементов заданного типа. При заполнении массива использовать 2 способа (ручной и с помощью ДСЧ).
//2.Массив вывести на печать.
//3.	Выполнить операции с массивом, указанные в варианте, используя, по возможности, методы класса Array.
//4.	Результаты обработки вывести на печать.

//13  Одномерный char Удалить из массива все цифры

//Постановка задачи 2.
//1.	Ввести строку символов с клавиатуры. Строка состоит из слов, разделенных пробелами (пробелов может быть несколько) и знаками препинания (, ;:).  
//В строке может быть несколько предложений, в конце каждого предложения стоит знак препинания (.!?).
//2.Выполнить обработку строки в соответствии с вариантом.
//3.	Результаты обработки вывести на печать.

//13  Перевернуть все слова в предложении и отсортировать слова по убыванию.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace LR6
{
    public class LR6Program
    {
        public static void Main(string[] args) => Menu();

        static void Menu()
        {
            char[] array = new char[0];
            string stroke = "";
            int choice;
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nМеню:" +
                                "\n\t1. Создать одномерный массив;" +
                                "\n\t2. Распечатать массив;" +
                                "\n\t3. Удалить цифры;" +
                                "\n\t4. Создать строку;" +
                                "\n\t5. Перевернуть слова и расположить в порядке убывания длины;" +
                                "\n\t6. Распечатать строку;" +
                                "\n\t7. Выход из программы.");

                choice = IntInput("Ваш выбор: ",1,7);

                if (array.Length == 0 && choice >= 2 && choice <= 3)               
                    Console.WriteLine("\nОШИБКА. Создайте массив!");
                
                else if (stroke == "" && choice >= 5 && choice <= 6)              
                    Console.WriteLine("\nОШИБКА. Создайте строку!");
                
                else
                {
                    switch (choice)
                    {
                        case 1:
                            array = CreateArray();
                            break;
                        case 2:
                            Console.WriteLine("\nВывод элементов массива.\n");
                            PrintArray(array);
                            break;
                        case 3:
                            Console.WriteLine("\nУдаление цифр из массива.\n");
                            array = DeleteDigits(array);
                            break;
                        case 4:
                            stroke = CreateString();
                            break;
                        case 5: 
                            stroke = ReverseOrderString(stroke);
                            break;
                        case 6:
                            Console.WriteLine(stroke);
                            break;
                        case 7:
                            exit = true;
                            break;
                    }
                }
            }
            Console.WriteLine("\nЗавершение работы программы");
        }

        //---------- МЕТОДЫ ОБРАБОТКИ ВВОДА ---------- 

        public static bool RandomOrManual(string option1, string option2)
        {
            Console.WriteLine($"\n1. {option1}\n2. {option2}");          
            int choice = IntInput("Ваш выбор: ", 1, 2);            
            return (choice == 1) ? true : false;
        }
        
        public static int IntInput(string msg, int beg, int end)
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
        
        public static char IntLetInput(string msg)
        {
            bool flag;
            char elem = '1';

            do
            {
                flag = false;
                Console.WriteLine();
                Console.Write(msg);
                try
                {
                    elem = Convert.ToChar(Console.ReadLine());
                    if (!char.IsDigit(elem) && !char.IsLetter(elem)) throw new IndexOutOfRangeException();
                }
                catch
                {
                    flag = true;
                    Console.WriteLine("\nВы ввели некорректные данные. Повторите ввод.");
                }
            } while (flag);

            return elem;
        }

        //---------- ЗАДАНИЕ 1 ---------- 

        public static char[] CreateArray()
        {
            int length = IntInput("Введите длину массива [1, 10]: ", 1, 10);
            if (RandomOrManual("Заполнение массива случайными символами [0-9][a-z].", "Ввод элементов массива с клавиатуры."))
                return CreateArrayRandom(length);
            else
                return CreateArrayManual(length);
        }

        public static char[] CreateArrayRandom(int length)
        {
            Random rnd = new Random();
            return Enumerable.Range(0, length).Select(index => rnd.Next(0, 2) == 0 ? (char)rnd.Next('a', 'z') : (char)rnd.Next('0', '9')).ToArray();       
        }

        public static char[] CreateArrayManual(int length)
        {           
            return Enumerable.Range(0, length).Select(index => IntLetInput("Введите цифру или букву: ")).ToArray();
        }

        public static void PrintArray(char[] array)
        {
            Array.ForEach(array, x => Console.Write(" {0}  ", x));
            Console.WriteLine();
            foreach (var i in Enumerable.Range(1, array.Length)) Console.Write("[{0}] ", i);
            Console.WriteLine();
        }

        public static char[] DeleteDigits(char[] array)
        {
            return array.Where(x => !new Regex(@"[0-9]").IsMatch(x.ToString())).Select(x => x).ToArray();
        }

        //---------- ЗАДАНИЕ 2 ---------- 

        public static string CreateString()
        {
            if (RandomOrManual("Использовать готовую строку.","Ввести строку."))
                return  
                        "Сегодня, несмотря на погоду, был чудесный день! " +
                        "Я увидел много нового: как размышляют люди; как зарождается жизнь; как стареют поколения. " +
                        "Возможно, такое со мной никогда больше не случится? Но никто точно не знает.";
            else
                return CreateStringManual();
            }

        public static string CreateStringManual()
        {
            Console.WriteLine("\nВведите строку: ");
            return Console.ReadLine();
        }

        public static string ReverseOrderString(string text)
        {
            string [][] words = SplitString(text);
            words = ReverseWords(words);
            words = OrderDesc(words);
            string newstring = AssembleString(words);

            return newstring;
        }

        public static string[][] SplitString(string text)
        {
            string[] sentences = Regex.Split(text, @"(!)|(\.)|(\?)").Where(s => s != "").ToArray();
            string[][] words = sentences
                .Select(sentence => Regex.Split(sentence, @"(;)|(:)|(,)|( )")
                    .Where(w => w != "")
                    .ToArray())
                .ToArray();
            return words;
        }

        //public static string[][] ReverseWords(string[][] words)
        //{
        //    return words.Select(row => row.Select(word =>
        //        {
        //            var array = word.ToCharArray();
        //            Array.Reverse(array);
        //            return string.Join("", array);
        //        }
        //        ).ToArray()).ToArray();
        //}

        public static string[][] ReverseWords(string[][] words)
        {
            return words.Select(row => ReverseWordsSentence(row)).ToArray();
        }

        public static string[] ReverseWordsSentence(string[] words)
        {
            return words.Select(word =>
            {
                var array = word.ToCharArray();
                Array.Reverse(array);
                return string.Join("", array);
            }).ToArray();
        }

        public static string[][] OrderDesc(string [][] words)
        {
            return words.Select(row => OrderDescSentence(row)).ToArray();
        }
        //public static string[][] OrderDesc(string[][] words)
        //{
        //    return words.Select(row => 
        //    {
        //        var temp = row.ToArray();
        //        Array.Sort(temp);

        //        Stack<string> st = new Stack<string>(temp
        //                .SkipWhile(word => !char.IsLetterOrDigit(word[0]))
        //                .OrderBy(word => word.Length));
            
        //        foreach (var i in Enumerable.Range(0, row.Length))
        //        {
        //            if (char.IsLetterOrDigit(row[i][0]))
        //                row[i] = st.Pop();
        //        }

        //        return row; 
        //    }).ToArray();
        //}
        public static string[] OrderDescSentence(string[] row)
        {           
            var temp = row.ToArray();
            Array.Sort(temp);

            Stack<string> st = new Stack<string>(temp
                    .SkipWhile(word => !char.IsLetterOrDigit(word[0]))
                    .OrderBy(word => word.Length));

            foreach (var i in Enumerable.Range(0, row.Length))
            {
                if (char.IsLetterOrDigit(row[i][0]))
                    row[i] = st.Pop();
            }

            return row;          
        }

        public static string AssembleString(string[][] words)
        {
            return string.Join("", words.Select(row => string.Join("", row)));
        }

        //---------- НЕИСПОЛЬЗУЕМЫЕ МЕТОДЫ ---------- 

        public static void PrintWords(string[][] words)
        {
            Array.ForEach(words, row => 
            { 
                Array.ForEach(row, word => Console.Write(word));
                Console.WriteLine();
            });
            Console.WriteLine();
        }

        public static string[][] SSplitString(string text)
        {
            string[] sentences = text.Split(new char[] { '!', '?', '.' }, StringSplitOptions.RemoveEmptyEntries);
            string[][] words = sentences.Select(sentence => sentence.Split(new char[] { ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries)).ToArray();
            return words;
        }
    }  
}
