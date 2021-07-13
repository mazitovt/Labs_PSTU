using ExecutablesLibrary;
using System;
using System.Linq;

namespace LR12_1
{
    class LinkedList
    {
        private Point Start { get; set; }
        private Point End { get; set; }

        public int Count { 
            get
            {
                Point temp = Start;
                int count = 0;
                while (temp != null)
                {
                    temp = temp.Next;
                    count++;
                }

                return count;
            }
        }

        public LinkedList()
        {
            Start = null;
        }

        ~LinkedList()
        {
            //Console.WriteLine("LinkedList deleted.");
        }

        /// <summary>
        /// Создать список и заполнить его сгенерированными значениями
        /// </summary>
        /// <param name="size">Размер коллекции</param>
        public LinkedList(int size)
        {
            int postfix = 0;
            foreach (var i in Enumerable.Range(1, size))
                Add(FileCreator.CreateRandomFile(ref postfix));
        }

        /// <summary>
        /// Распечатать элементы списка
        /// </summary>
        public void Print()
        {
            Point temp = Start;

            Console.WriteLine();
            while (temp != null)
            {
                Console.WriteLine(temp.file + " ");
                temp = temp.Next;
            }
        }

        /// <summary>
        /// Добавление в конец списка
        /// </summary>
        /// <param name="file"></param>
        public void Add(File file)
        {
            Point temp = Start;
            Point newPoint = new Point(file);

            if (Start == null)
                Start = newPoint;
            else
            {
                while (temp.Next != null)
                    temp = temp.Next;

                temp.Next = newPoint;
            }

        }

        /// <summary>
        /// Добавление в позицию (с 0). Если позиция больше количество элементов, то вставка в конец.
        /// </summary>
        /// <param name="file">Файл для добавления</param>
        /// <param name="pos">Позиция, в которую нажно вставить файл</param>
        public void AddAt(File file, int pos)
        {
            if (pos >= 0)
            {
                int cur = 0;
                Point temp = Start;

                if (pos == 0)
                {
                    Point newPoint1 = new Point(file, Start);
                    Start = newPoint1;
                }
                else
                {
                    while (temp.Next != null && cur < pos - 1)
                    {
                        temp = temp.Next;
                        cur++;
                    }

                    Point newPoint = new Point(file, temp.Next);
                    temp.Next = newPoint;
                }
            }
        }


        // МЕТОД ДЛЯ РЕШЕНИЯ ЗАДАНИЯ
        // Связать с Add(file, pos)
        /// <summary>
        /// Добавляет файл после файла, с заданным id.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool AddAfter(File file, int id)
        {
            Point temp = Start;
            var pos = 0;

            while (temp != null && temp.file.Id != id)
            {
                temp = temp.Next;
                pos++;
            }
            if (temp == null)
                return false;
            else
            {
                Point newPoint = new Point(file, temp.Next);
                temp.Next = newPoint;
                return true;
            }
        }


        /// <summary>
        /// Удаление первого вхождения элемента в список
        /// </summary>
        /// <param name="file"></param>
        /// <returns>True, если элемент успешно удален из списка</returns>
        public bool Remove(int id)
        {
            if (Start == null)
            {
                return false;
            }
            if (Start.file.Id == id)
            {
                Start = Start.Next;
                return true;
            }

            Point temp = Start;

            while (temp.Next != null && temp.Next.file.Id != id)
                temp = temp.Next;
            if (temp.Next == null)
                return false;
            else
            {
                temp.Next = temp.Next.Next;
                return true;
            }

        }
    }
}