namespace _01.BinaryTree
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }
        //Task 2
        public string AsIndentedPreOrder(int indent)
        {
            //return DFSPreOrder(this, 0);
            StringBuilder result = new StringBuilder();
            return PreOrderDfs(this, result, 0);
        }
        //Task 2 - help file v1
        private string DFSPreOrder(IAbstractBinaryTree<T> node, int indent)
        {
            string result = $"{new string(' ', indent)}{node.Value}\r\n";
            if (node.LeftChild != null)
            {
                result += DFSPreOrder(node.LeftChild, indent + 2);
            }

            if (node.RightChild != null)
            {
                result += DFSPreOrder(node.RightChild, indent + 2);
            }

            return result;
        }
        //Task 2 - help file v2
        private string PreOrderDfs(IAbstractBinaryTree<T> tree, StringBuilder result, int indent)
        {
            result.Append(new string(' ', indent)).Append(tree.Value)
                  .Append(Environment.NewLine);
            if (tree.LeftChild != null)
            {
                this.PreOrderDfs(tree.LeftChild, result, indent + 2);
            }
            if (tree.RightChild != null)
            {
                this.PreOrderDfs(tree.RightChild, result, indent + 2);
            }

            return result.ToString();
        }
        //Task 3
        public List<IAbstractBinaryTree<T>> InOrder()
        {
            return DFSInOrder(this);
        }
        //Task 3 - help file
        private List<IAbstractBinaryTree<T>> DFSInOrder(IAbstractBinaryTree<T> node)
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();

            if (node.LeftChild != null)
            {
                list.AddRange(DFSInOrder(node.LeftChild));
            }

            list.Add(node);

            if (node.RightChild != null)
            {
                list.AddRange(DFSInOrder(node.RightChild));
            }

            return list;
        }
        //Task 4
        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            return DFSPostOrder(this);
        }
        //Task 4 - help file
        private List<IAbstractBinaryTree<T>> DFSPostOrder(IAbstractBinaryTree<T> node)
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();

            if (node.LeftChild != null)
            {
                list.AddRange(DFSPostOrder(node.LeftChild));
            }

            if (node.RightChild != null)
            {
                list.AddRange(DFSPostOrder(node.RightChild));
            }

            list.Add(node);

            return list;
        }
        //Task 5
        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            return DFSPreOrder(this);
        }
        //Task 5 - help file
        private List<IAbstractBinaryTree<T>> DFSPreOrder(IAbstractBinaryTree<T> node)
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();
            list.Add(node);

            if (node.LeftChild != null)
            {
                list.AddRange(DFSPreOrder(node.LeftChild));
            }

            if (node.RightChild != null)
            {
                list.AddRange(DFSPreOrder(node.RightChild));
            }

            return list;
        }
        //Task 6
        public void ForEachInOrder(Action<T> action)
        {
            ForEachInOrder(action, this);
        }
        public void ForEachInOrder(Action<T> action, BinaryTree<T> node)
        {
            if (node == null)
            {
                return;
            }
            if (node.LeftChild != null)
            {
                node.LeftChild.ForEachInOrder(action);
            }

            action.Invoke(this.Value);

            if (node.RightChild != null)
            {
                node.RightChild.ForEachInOrder(action);
            }
        }
    }
}
