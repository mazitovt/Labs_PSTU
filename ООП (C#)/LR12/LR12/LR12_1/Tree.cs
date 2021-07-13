//Сформировать идеально сбалансированное бинарное дерево, в информационное поле записать объекты из иерархии классов лабораторной работы №10.
//Распечатать полученное дерево.
//Выполнить обработку дерева в соответствии с заданием, вывести полученный результат.

//Преобразовать идеально сбалансированное дерево в дерево поиска.

//Распечатать полученное дерево. 
//Удалить дерево из памяти.


using System;
using ExecutablesLibrary;

namespace LR12_1
{
    class Tree
    {
        private Node Root { get; set; }

        public bool IsEmpty
        {
            get => Root == null;
        }

        public Tree()
        {
            Root = null;
        }

        public Tree(Node root)
        {
            Root = root;
        }
        
        public Tree(int capacity)
        {
            Root = FormBalancedTree(FileCreator.CreateFilesArray(capacity)).Root;
        }

        // Печать дерева
        public void Print(int paddingIncrease, bool IsDetailed)
        {
            void ShowLeaf(Node node,int padding)
            {
                if (node != null)
                {
                    ShowLeaf(node.LeftChild, padding + paddingIncrease);

                    Console.WriteLine(new string(' ', padding) + (IsDetailed ? node.File : node.File.Name + " " + node.File.Id));

                    ShowLeaf(node.RightChild, padding + paddingIncrease);
                }
            }

            ShowLeaf(Root, 0);
        }

        // Формирование идельно сбалансированного бинарного дерева поиска
        public static Tree FormBalancedTree(File[] files)
        {
            Node BalancedNode(int lowerIndex, int upperIndex, Node parent)
            {
                var size = (upperIndex - lowerIndex) + 1;
                var middleIndex = lowerIndex + size / 2;


                if (size == 0)
                {
                    return null;
                }

                Node node = new Node()
                {
                    File = files[middleIndex],
                    Parent = parent
                };

                node.LeftChild = BalancedNode(lowerIndex, middleIndex - 1, node);
                node.RightChild = BalancedNode(middleIndex + 1, upperIndex, node);

                return node;
            }

            return new Tree(BalancedNode(0, files.Length - 1, null));
        }
        
        // Если файл с таким же id уже существует, вернуть false
        public void Add(File file)
        {

            Node Run(File file, Node parent, Node curNode)
            {
                if (curNode == null)
                {
                    Node node = new Node(file, parent, null, null);
                    return node;
                }

                if (curNode.File.Id > file.Id)
                    curNode.LeftChild = Run(file, curNode, curNode.LeftChild);
                if (curNode.File.Id < file.Id)
                    curNode.RightChild = Run(file, curNode, curNode.RightChild);
                if (curNode.File.Id == file.Id)
                    curNode.File = file;

                return curNode;
            }

            if (Root == null)
            {
                Root = new Node(file);
                return;
            }

            if (Root.File.Id == file.Id)
            {
                Root.File = file;
                return;
            }

            Root = Run(file, null, Root);           
        }

        public bool Remove(int id)
        {
            Node toDel = null;

            bool FindId(Node parent, Node curNode)
            {
                if (curNode == null)
                    return false;

                if (curNode != null && curNode.File.Id == id)
                {
                    toDel = curNode;
                    return true;
                }

                bool IsFound = false;

                if (curNode.File.Id > id)
                    IsFound = FindId(curNode, curNode.LeftChild);

                if (IsFound)
                    return true;

                return FindId(curNode, curNode.RightChild);
                    
            }

            bool ReplaceNodeFromLeft(Node curNode)
            {
                if (curNode == null)
                    return false;
                if (curNode.RightChild != null)
                    return ReplaceNodeFromLeft(curNode.RightChild);
                else
                {
                    FreeNode(curNode);
                    InsertOnDel(toDel, curNode);

                    return true;
                }
            }

            bool ReplaceNodeFromRight(Node curNode)
            {
                if (curNode == null)
                    return false;
                if (curNode.LeftChild != null)
                    return ReplaceNodeFromRight(curNode.LeftChild);
                else
                {
                    FreeNode(curNode);
                    InsertOnDel(toDel, curNode);

                    return true;
                }
            }

            void FreeNode(Node curNode)
            {
                if (curNode.LeftChild != null)
                {
                    if (curNode.Parent != null)
                    {
                        if (curNode.Parent.LeftChild == curNode)
                        {
                            curNode.Parent.LeftChild = curNode.LeftChild;
                            curNode.LeftChild.Parent = curNode.Parent;
                        }
                        if (curNode.Parent.RightChild == curNode)
                        {
                            curNode.Parent.RightChild = curNode.LeftChild;
                            curNode.LeftChild.Parent = curNode.Parent;
                        }
                    }
                }
                
                else if (curNode.RightChild != null)
                {
                    if (curNode.Parent != null)
                    {
                        if (curNode.Parent.LeftChild == curNode)
                        {
                            curNode.Parent.LeftChild = curNode.RightChild;
                            curNode.RightChild.Parent = curNode.Parent;
                        }
                        if (curNode.Parent.RightChild == curNode)
                        {
                            curNode.Parent.RightChild = curNode.RightChild;
                            curNode.RightChild.Parent = curNode.Parent;
                        }
                    }
                }
                
                else if (curNode.LeftChild != null && curNode.RightChild != null)
                {
                    throw new Exception("Почему оба ребенка не равны нулю?");
                }
                
                else
                {
                    if (curNode.Parent == null)
                    {
                        Root = null;
                    }
                    else
                    {
                        if (curNode.Parent.RightChild == curNode)
                        {
                            curNode.Parent.RightChild = null;
                        }
                        if (curNode.Parent.LeftChild == curNode)
                        {
                            curNode.Parent.LeftChild = null;
                        }
                    }                 
                }

                curNode.Parent = null;
                curNode.LeftChild = null;
                curNode.RightChild = null;
            }

            void InsertOnDel(Node nodeToDel, Node curNode)
            {
                if (nodeToDel.Parent == null)
                {
                    Root = curNode;
                }
                else
                {
                    if (nodeToDel.Parent.LeftChild == nodeToDel)
                    {
                        nodeToDel.Parent.LeftChild = curNode;
                        curNode.Parent = nodeToDel.Parent;
                    }

                    if (nodeToDel.Parent.RightChild == nodeToDel)
                    {
                        nodeToDel.Parent.RightChild = curNode;
                        curNode.Parent = nodeToDel.Parent;
                    }

                    nodeToDel.Parent = null;
                }

                if (nodeToDel.RightChild != null)
                {
                    nodeToDel.RightChild.Parent = curNode;
                    curNode.RightChild = nodeToDel.RightChild;
                }

                if (nodeToDel.LeftChild != null)
                {
                    nodeToDel.LeftChild.Parent = curNode;
                    curNode.LeftChild = nodeToDel.LeftChild;
                }

                nodeToDel.LeftChild = null;
            }

            if (FindId(null, Root))
            {
                if (toDel != null)
                {
                    if (!ReplaceNodeFromLeft(toDel.LeftChild))
                    {
                        if (!ReplaceNodeFromRight(toDel.RightChild))
                        {
                            FreeNode(toDel);
                        }
                    }
                }

                return true;
            }

            return false;            
        }

        // Найти среднее арифметическое элементов дерева (размер файлов).
        public double AverageFileSize()
        {
            void Run(Node node, ref int size, ref int count)
            {
                if (node != null)
                {
                    size += node.File.Size;
                    count++;

                    Run(node.LeftChild, ref size, ref count);
                    Run(node.RightChild, ref size, ref count);
                }
            }
            int size = 0, count = 0;
            Run(Root, ref size , ref count);

            return count != 0 ? size / count : 0;
        }
    }
}
