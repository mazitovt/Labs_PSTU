using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysApp
{
    public static class ArrayWorker
    {
        public static string[] array1;
        public static string[,] array2;
        public static string[][] array3;
        public static int[] indexes;
        public static int[] Main_indexes;

        public static void NewIndexes(int[] array)
        {
            if (indexes != null)
            {
                Main_indexes = new int[indexes.Length];
                for (int i = 0; i < indexes.Length; i++)
                    Main_indexes[i] = indexes[i];
            }
            indexes = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                indexes[i] = array[i];

        }

        private static Dictionary<int, object> ArrayFromType = new Dictionary<int, object>();

        public static void AddPage(int type, object array) => ArrayFromType[type] = array;

        public static dynamic GetArray(int type) => ArrayFromType[type];

        public static void ArrayFromString(string items, int type)
        {
            if (type == 1)
            {
                string[] temp = items.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                ArrayFromType[type] = temp;
            }


            if (type == 2)
            {
                string[] row = new string[0];
                string[] temp = items.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                if (temp.Length != 0)
                    row = temp[0].Split(' ');

                ArrayFromType[type] = new string[temp.Length, row.Length];
                array2 = (string[,])ArrayFromType[type];

                for (int i = 0; i < temp.Length; i++)
                {
                    row = temp[i].Split(' ');
                    for (int j = 0; j < row.Length; j++)
                        array2[i, j] = row[j];
                }
            }

            if (type == 3)
            {

                string[] row;
                string[] temp = items.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                ArrayFromType[type] = new string[Convert.ToInt32(temp.Length)][];
                array3 = (string[][])ArrayFromType[type];

                for (int i = 0; i < array3.Length; i++)
                {
                    row = temp[i].Split(' ');
                    array3[i] = new string[row.Length];
                    for (int j = 0; j < row.Length; j++)
                        array3[i][j] = row[j];
                }
            }
        }

        public static void CreateArrayRandom(TabPageModified page, int columns, int rows = -1)
        {

            switch (page.Type)
            {
                case 1:
                    CreateArray1(columns, page.Type); break;
                case 2:
                    CreateArray2(columns, rows, page.Type); break;
                case 3:
                    CreateArray3(columns, rows, page.Type); break;
            }
        }

        public static void CreateArray1(int size, int type)
        {
            ArrayFromType[type] = new string[size];
            string[] array = (string[])ArrayFromType[type];

            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(1, 10).ToString();
            }
        }

        public static void CreateArray2(int rows, int columns, int type)
        {
            ArrayFromType[type] = new string[rows, columns];
            string[,] array = (string[,])ArrayFromType[type];

            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = rnd.Next(1, 10).ToString();
                }
            }
        }

        public static void CreateArray3(int rows, int columns, int type)
        {
            ArrayFromType[type] = new string[rows][];
            string[][] array = (string[][])ArrayFromType[type];

            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                array[i] = new string[rnd.Next(1, columns + 1)];

                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = rnd.Next(1, 10).ToString();
                }
            }
        }

        public static void AddElements(string text)
        {
            string elements = text.Trim(' ');
            string[] add = elements.Split(' ').ToArray();
            string[] oldarray = (string[])ArrayFromType[1];
            ArrayFromType[1] = new string[oldarray.Length + add.Length];
            string[] array = (string[])ArrayFromType[1];

            for (int i = 0; i < add.Length; i++)
                array[i] = add[i];

            for (int i = 0; i < oldarray.Length; i++)
                array[i + add.Length] = oldarray[i];
        }

        public static void CopyArray(int[] array)
        {
            indexes = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
                indexes[i] = array[i];

        }

        public static void DeleteRows()
        {

            bool flag = false;
            int k1 = Main_indexes[0] + 1;
            int k2 = Main_indexes.Last() + 1;
            int to_del = Math.Abs(k1 - k2) + 1;

            string[,] oldarray = (string[,])ArrayFromType[2];
            string[,] array = new string[oldarray.GetLength(0) - to_del, oldarray.GetLength(1)];

            if (k1 > k2)
            {
                k1 = k1 + k2;
                k2 = k1 - k2;
                k1 = k1 - k2;
            }

            for (int i = 0; i < oldarray.GetLength(0); i++)
            {
                if (i + 1 >= k1 && i + 1 <= k2)
                {
                    flag = true;
                }
                else
                {
                    for (int j = 0; j < oldarray.GetLength(1); j++)
                    {
                        if (flag)
                        {
                            array[i - to_del, j] = oldarray[i, j];
                        }
                        else
                        {
                            array[i, j] = oldarray[i, j];
                        }
                    }
                }
            }
            foreach (var i in array)
                Console.WriteLine(i);

            ArrayFromType[2] = array;

        }

        public static void AddRow(string elements)
        {

            string[] add = elements.Split(' ').ToArray();
            string[][] oldarray = (string[][])ArrayFromType[3];
            ArrayFromType[3] = new string[oldarray.Length + 1][];
            string[][] array = (string[][])ArrayFromType[3];

            int k = Main_indexes[0];

            array[k] = add;

            for (int i = 0; i < oldarray.Length + 1; i++)
            {
                if (i < k) array[i] = oldarray[i];
                if (i > k) array[i] = oldarray[i - 1];
            }
        }
    }
}
