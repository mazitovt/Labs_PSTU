using System.Collections.Generic;

namespace ExecutablesLibrary
{
    public class SortByIdDesc : IComparer<int>
    {
        int IComparer<int>.Compare(int obj1, int obj2)
        {
            if (obj1 > obj2) return -1;
            if (obj1 == obj2) return 0;
            else return 1;
        }

    }
}