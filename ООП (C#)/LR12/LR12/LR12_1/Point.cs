using ExecutablesLibrary;

namespace LR12_1
{
    class Point
    {
        public File file;
        public Point Next;

        public Point()
        {
            file = null;
            Next = null;
        }

        public Point(File file)
        {
            this.file = file;
            Next = null;
        }

        public Point(File file, Point next)
        {
            this.file = file;
            Next = next;
        }

        public override string ToString()
        {
            return file.ToString();
        }
    }
}