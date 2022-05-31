namespace _02.LowestCommonAncestor
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    //BST - ТУК винаги трябва наляво да са по-малки деца, надясно - по-големи!
    //ТУК се иска да се намери на два нода най-близкия (като разстояние, не като стойност) родител.
    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            if(LeftChild != null)//Да асайнем и родителя при инициализирането! Така инициализираме цялата структура!
            {
                leftChild.Parent = this;
            }
            RightChild = rightChild;
            if (rightChild != null)// Да асайнем и родителя при инициализирането! Така инициализираме цялата структура!
            {
                rightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var firstNodeAncestors = GetAncestor(Search(first));
            var secondNodeAncestors = GetAncestor(Search(second));

            var intersection = firstNodeAncestors.Intersect(secondNodeAncestors);//    using System.Linq;

            return intersection.ToArray()[0];
        }
        private List<T> GetAncestor(IAbstractBinaryTree<T> node)
        {
            List<T> list = new List<T>();

            while(node != null)
            {
                list.Add(node.Value);//Добавяме и самите нодове, така ако са равни - имаме и тях и дава 100 точки!
                node = node.Parent;
            }

            return list;
        }
        private IAbstractBinaryTree<T> Search(T element)
        {
            var node = this;

            if (node == null)
            {
                return null;
            }

            while (node != null)
            {
                if (IsGreater(node.Value, element))
                {
                    node = node.LeftChild;
                }
                else if (IsSmaller(node.Value, element))
                {
                    node = node.RightChild;
                }
                else
                {
                    return node;
                }
            }

            return null;
        }

        private bool IsGreater(T value, T other)
        {
            return value.CompareTo(other) > 0;
        }
        private bool IsSmaller(T value, T other)
        {
            return value.CompareTo(other) < 0;
        }
    }
}
