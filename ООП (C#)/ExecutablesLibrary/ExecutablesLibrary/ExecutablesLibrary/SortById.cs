using System.Collections;

namespace ExecutablesLibrary
{
    public class SortById : IComparer
    {
        int IComparer.Compare(object ob1, object ob2)
        {
            File file1 = (File)ob1;
            File file2 = (File)ob2;
            return file1.Id.CompareTo(file2.Id);
        }
    }
}