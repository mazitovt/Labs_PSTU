using System;
using System.Collections.Generic;
using System.Collections;


namespace LR12_2
{
    public class MyEnumerator<T> : IEnumerator<T> where T: ICloneable
    {
        public TDoublePoint<T> start;
        public TDoublePoint<T> current;

        public T Current => current.data;

        object IEnumerator.Current => Current;

        public MyEnumerator(MyCollection<T> col)
        {
            start = new TDoublePoint<T>(default(T), col.Start, null);
            current = start;
        }

        public bool MoveNext()
        {
            if (current.Next == null)
            {
                Reset();
                return false;
            }

            current = current.Next;
            return true;
        }

        public void Reset()
        {
            current = start;
        }

        public void Dispose()
        {
       
        }
    }

}
