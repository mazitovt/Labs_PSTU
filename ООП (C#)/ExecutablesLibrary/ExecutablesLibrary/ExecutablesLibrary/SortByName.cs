using System;
using System.Collections;

namespace ExecutablesLibrary
{
    public class SortByName : IComparer
    {
        int IComparer.Compare(object ob1, object ob2)
        {
            File file1 = (File)ob1;
            File file2 = (File)ob2;
            return String.Compare(file1.Name, file2.Name);
        }

    }
}