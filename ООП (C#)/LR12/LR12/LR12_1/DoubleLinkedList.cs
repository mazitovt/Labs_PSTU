using ExecutablesLibrary;
using System;
using System.Linq;

namespace LR12_1
{
    public class DoubleLinkedList
    {
        private DoublePoint Start { get; set; }

        public int Count
        {
            get
            {
                DoublePoint temp = Start;
                int count = 0;
                while (temp != null)
                {
                    temp = temp.Next;
                    count++;
                }

                return count;
            }
        }

        public DoubleLinkedList()
        {
            Start = null;
        }

        ~DoubleLinkedList()
        {
            Console.WriteLine("DoubleLinkedList was deleted.");
        }

        /// <summary>
        /// Создать список и заполнить его сгенерированными значениями
        /// </summary>
        /// <param name="size">Размер коллекции</param>
        public DoubleLinkedList(int size)
        {
            int postfix = 0;
            foreach (var i in Enumerable.Range(1, size))
                Add(FileCreator.CreateRandomFile(ref postfix));
        }

        public void Print()
        {
            DoublePoint temp = Start;

            Console.WriteLine();
            while (temp != null)
            {
                Console.WriteLine(temp.file);
                temp = temp.Next;
            }
        }

        public void PrintWithNextAndPrev()
        {
            DoublePoint temp = Start;

            Console.WriteLine();
            while (temp != null)
            {
                Console.WriteLine();
                if (temp.Previous != null) Console.WriteLine(temp.Previous.file + " ");
                Console.WriteLine(temp.file + " ");
                if (temp.Next != null) Console.WriteLine(temp.Next.file + " ");

                temp = temp.Next;
            }
        }

        // Добавление в конец
        public void Add(File file)
        {
            DoublePoint temp = Start;
            DoublePoint newPoint = new DoublePoint(file, null, null);

            if (Start == null)
                Start = newPoint;
            else
            {
                while (temp.Next != null)
                    temp = temp.Next;

                temp.Next = newPoint;
                newPoint.Previous = temp;
            }

        }        

        // Удалить первое вхождение элемента в список
        public bool Remove(int id)
        {
            if (Start.file.Id == id)
            {
                Start = Start.Next;

                if (Start != null)
                    Start.Previous = null;

                return true;
            }

            DoublePoint temp = Start;

            while (temp != null && temp.file.Id != id)
                temp = temp.Next;

            if (temp == null)
                return false;

            temp.Previous.Next = temp.Next;
            if (temp.Next != null)
                temp.Next.Previous = temp.Previous;
            temp.Previous = null;
            temp.Next = null;
            return true;         
        }

        /// <summary>
        /// Удаляет все файлы со значением размера меньше среднего.
        /// </summary>
        /// <param name="averageSize"></param>
        /// <returns>Возвращает количество удаленных файлов</returns>
        public int RemoveWithLessThanAvgSize(double averageSize)
        {
            int count = 0;

            DoublePoint temp = Start;

            while (temp != null)
            {
                if (temp.file.Size < averageSize)
                {
                    Remove(temp.file.Id);
                    count++;
                    temp = Start;
                    continue;
                }
                temp = temp.Next;
            }

            //while (Start.file.Size < averageSize)
            //{
            //    Start = Start.Next;
            //    Start.Previous = null;
            //    count++;
            //}

            //DoublePoint temp = Start;

            //while (temp != null && temp.Next != null)
            //{
            //    if (temp.Next.file.Size < averageSize)
            //    {
            //        temp.Next = temp.Next.Next;
            //        if (temp.Next != null)
            //            temp.Next.Next.Previous = temp;
            //        count++;
            //    }
            //    temp = temp.Next;
            //}

            return count;
        }

        public double AverageSize()
        {
            double averageSize = 0;
            int count = 0;

            DoublePoint temp = Start;

            while (temp != null)
            {
                count++;
                averageSize += temp.file.Size;
                temp = temp.Next;
            }

           return averageSize / count;
        }
    }
}