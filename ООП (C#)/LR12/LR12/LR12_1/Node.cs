using ExecutablesLibrary;

namespace LR12_1
{
    class Node
    {

        public File File;
        public Node Parent;
        public Node LeftChild;
        public Node RightChild;

        public int RightCount;
        public int LeftCount;


        public Node()
        {

        }

        public Node(File file)
        {
            (File, Parent, LeftChild, RightChild) = (file, null, null, null);
        }

        public Node(File file, Node parent, Node leftChild, Node rightChild)
        {
            (File, Parent, LeftChild, RightChild) = (file, parent, leftChild, rightChild);
        }

        public void Delete()
        {
            Parent = null;
            LeftChild = null;
            RightChild = null;
            File = null;
        }

        public override string ToString()
        {
            return File.ToString();
        }
    }
}
