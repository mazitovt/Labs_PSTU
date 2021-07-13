using System;

namespace LR12_2
{
    public class TDoublePoint<T>
    {
        public T data;
        public TDoublePoint<T> Next;
        public TDoublePoint<T> Previous;

        public TDoublePoint()
        {
            data = default(T);
            Next = null;
        }

        public TDoublePoint(T data)
        {
            this.data = data;
            Next = null;
            Previous = null;
        }

        public TDoublePoint(T data, TDoublePoint<T> next, TDoublePoint<T> prev)
        {
            this.data = data;
            Next = next;
            Previous = prev;
        }

        ~TDoublePoint()
        {
            //Console.WriteLine("TDoublePoint was deleted.");
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
}