using ExecutablesLibrary;

namespace LR12_1
{
    class DoublePoint
    {
        public File file;
        public DoublePoint Next;
        public DoublePoint Previous;

        public DoublePoint()
        {
            file = null;
            Next = null;
        }

        public DoublePoint(File file)
        {
            this.file = file;
            Next = null;
            Previous = null;
        }

        public DoublePoint(File file, DoublePoint next, DoublePoint prev)
        {
            this.file = file;
            Next = next;
            Previous = prev;
        }

        public override string ToString()
        {
            return file.ToString();
        }
    }
}