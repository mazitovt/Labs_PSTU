using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace LR12_2
{

    /// <summary>
    /// Двунаправленный обобщенный список
    /// </summary>
    /// <typeparam name="T">Класс или тип данных, объекты которого будет содержать список</typeparam>
    public class MyCollection<T> : IEnumerable<T> where T : ICloneable
    {

//----------ПРИВАТНЫЕ ПОЛЯ----------
        private TDoublePoint<T> _start;


//----------ПУБЛИЧНЫЕ СВОЙСТВА----------
        /// <summary>
        /// Возвращает количество элементов в коллекции.
        /// </summary>
        public bool IsEmpty
        {
            get => Start == null;
        }
        
        public int Count
        {
            get
            {
                int count = 0;
                var temp = _start;

                while (temp != null)
                {
                    temp = temp.Next;
                    count++;
                }

                return count;
            }
        }

        public TDoublePoint<T> Start
        {
            get => _start;
        }


//----------ИНДЕКСАТОР----------
        public virtual T this[int index]
        {
            get => getPointOnIndex(index).data;

            set => getPointOnIndex(index).data = value;
        }


//----------КОНСТРУКТОРЫ----------
        public MyCollection()
        {
            _start = null;
        }

        public MyCollection(int capacity)
        {
            foreach (var _ in Enumerable.Range(1, capacity))
                Add(default(T));
        }

        public MyCollection(MyCollection<T> col)
        {
            foreach (var elem in col)
                Add(elem);
        }


//----------ПРИВАТНЫЕ МЕТОДЫ----------
        private TDoublePoint<T> getPointOnIndex(int index)
        {
            if (_start == null)
                throw new IndexOutOfRangeException("\nОШИБКА! Коллекция пуста.");

            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("\nОШИБКА! Выход за пределы индексов коллекции.");

            TDoublePoint<T> temp = _start;

            while (index != 0)
            {
                temp = temp.Next;
                index--;
                if (temp == null)
                    throw new IndexOutOfRangeException("\nОШИБКА! Выход за пределы индексов списка.");
            }

            return temp;
        }


//----------ПУБЛИЧНЫЕ МЕТОДЫ----------
        public void PrintWithNextAndPrev()
        {
            TDoublePoint<T> temp = _start;

            Console.WriteLine();
            while (temp != null)
            {
                Console.WriteLine();
                if (temp.Previous != null) Console.WriteLine(temp.Previous.data + " ");
                Console.WriteLine(temp.data + " ");
                if (temp.Next != null) Console.WriteLine(temp.Next.data + " ");

                temp = temp.Next;
            }
        }

        /// <summary>
        /// Добавление элемента в конец списка
        /// </summary>
        /// <param name="item">Объект типа T, который нужно добавить в список</param>
        public virtual void Add(T item)
        {
            TDoublePoint<T> temp = _start;
            TDoublePoint<T> newPoint = new TDoublePoint<T>(item, null, null);

            if (_start == null)
                _start = newPoint;
            else
            {
                while (temp.Next != null)
                    temp = temp.Next;

                temp.Next = newPoint;
                newPoint.Previous = temp;
            }
        }

        /// <summary>
        /// Добавление нескольких элементов в список
        /// </summary>
        /// <param name="items">Массив типа T</param>
        public virtual void AddMany(T[] items)
        {
            foreach (var item in items)
                Add(item);
        }

        public virtual bool Remove(T item)
        {
            if (_start.data.Equals(item))
            {
                _start = _start.Next;
                if (_start != null)
                {
                    _start.Previous = null;
                }
                return true;
            }

            TDoublePoint<T> temp = _start;

            while (temp != null && temp.Next != null)
            {
                if (temp.Next.data.Equals(item))
                {
                    temp.Next = temp.Next.Next;
                    if (temp.Next != null)
                        temp.Next.Previous = temp;
                    return true;
                }
                temp = temp.Next;
            }

            return false;

        }

        public virtual bool Remove(int index)
        {
            if (index >= Count)
                throw new Exception("Выход за пределы списка");

            if (index == 0)
            {
                if (_start == null)
                    return false;

                _start = _start.Next;
                if (_start != null)
                {
                    _start.Previous.Next = null;
                    _start.Previous = null;
                }
                return true;
            }

            TDoublePoint<T> temp = _start;

            while (index != 0)
            {
                if (temp != null)
                {
                    temp = temp.Next;
                    index--;
                }
                else
                    throw new Exception("Выход за пределы списка");
            }

            temp.Previous.Next = temp.Next;

            if (temp.Next != null)
            {
                temp.Next.Previous = temp.Previous;
            }
            
            temp.Next = null;
            temp.Previous = null;

            return true;
        }

        // НЕ ИСПОЛЬЗОВАТЬ
        // Возвращает true, если удалены все переданные значения
        public virtual bool RemoveMany(T[] items)
        {
            return items.Select(item => Remove(item)).Aggregate((x, y) => x && y);
        }

        /// <summary>
        /// Поиск элемента с помощью предиката
        /// </summary>
        /// <param name="IsThatFile">Предикат с параметрами поиска элемента</param>
        /// <param name="data">Переменная, куда элемнт будет записан</param>
        /// <returns>Найден элемент или нет</returns>
        public bool Find(Predicate<T> IsThatFile, out T data)
        {
            TDoublePoint<T> temp = _start;

            while (temp != null)
            {
                if (IsThatFile(temp.data))
                {
                    data = temp.data;
                    return true;
                }
                temp = temp.Next;
            }

            data = default(T);
            return false;
        }

        /// <summary>        
        /// Глубокое копирование с новыми узлами, файлами и издателями
        /// </summary>
        public MyCollection<T> Clone()
        {
            MyCollection<T> newCol = new MyCollection<T>();
            //{
            //    _start = new TDoublePoint<T>((T)_start.data.Clone(), null, null)     // попробовать убрать
            //};

            foreach (var file in this)
                newCol.Add((T)file.Clone());

            return newCol;
        }

        /// <summary>
        /// Поверхностное копирование 
        /// </summary>
        public MyCollection<T> Shallowclone()
        {
            return (MyCollection<T>)this.MemberwiseClone();
        }

        public void DeleteCollection()
        {
            var temp = _start;

            while (temp != null)
            {
                temp.Previous = null;               
                temp = temp.Next;
                if (temp != null)
                    temp.Previous.Next = null;
            }

            _start = null;
        }

        ~MyCollection()
        {
            //Console.WriteLine("MyCollection was deleted.");
        }


//----------РЕАЛИЗОВАННЫЕ МЕТОДЫ ИНТЕРФЕЙСА IEnumerable----------
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


//----------ПЕРЕГРУЖЕННЫЕ МЕТОДЫ КЛАССА Object----------

        public override string ToString()
        {
            return $"Тип элементов коллекции: {typeof(T).GetField("Type").GetValue(null)}, количество элементов: {Count}";
        }
    }
}