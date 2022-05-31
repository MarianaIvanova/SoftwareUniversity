namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    //BINARY SEARCHED TREE
    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
   
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            Root = root;
        }

        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        //public bool Contains(T element)//Solved like in the lab lecture
        //{
        //    return Contains(element, Root);
        //}

        //private bool Contains(T value, Node<T> node)
        //{
        //    if (node == null)
        //    {
        //        return false;
        //    }

        //    if (node.Value.CompareTo(value) == 0)
        //    {
        //        return true;
        //    }
        //    else if (node.Value.CompareTo(value) > 0)
        //    {
        //        return Contains(value, node.LeftChild);
        //    }
        //    else
        //    {
        //        return Contains(value, node.RightChild);
        //    }
        //}
        public bool Contains(T element)//Solved like in the exercise lecture
        {
            var node = Root;

            while (node != null)
            {
                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }
                else if (node.Value.CompareTo(element) < 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    return true;//Така проверяваме и корена
                }
            }

            return false;
        }

        public void Insert(T element)
        {
            Insert(element, Root);
        }
        private void Insert(T value, Node<T> node)//Solved like in the lab lecture
        {
            //check if value is bigger or smaller than root
            //go left or right accordingly
            //repeat for child element
            //find the first null child element and put the node there
            if (node == null)//This is the root for the first time we call the method as we call it from another method with root!!!
            {
                node = new Node<T>(value, null, null);
                Root = node;
                Count++;
                return;
            }

            if (node.Value.CompareTo(value) < 0)
            {
                if(node.RightChild == null)
                {
                    node.RightChild = new Node<T>(value, null, null);
                    Count++;
                    return;
                }

                Insert(value, node.RightChild);
            }
            else 
            {
                if(node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(value, null, null);
                    Count++;
                    return;
                }

                Insert(value, node.LeftChild);
            }
        }
        //public void Insert(T element)//Solved like in the exercise lecture
        //{
        //    var newNode = new Node<T>(element, null, null);

        //    if(Count == 0)
        //    {
        //        Root = newNode;
        //        Count++;
        //        return;
        //    }

        //    Node<T> parentNode = null;
        //    var node = Root;

        //    while (node != null)//Въртим цикъла докато node стане null, тогава parentNode ще е родителя на null
        //    {
        //        parentNode = node;
        //        if(node.Value.CompareTo(element) > 0)
        //        {
        //            node = node.LeftChild;
        //        }
        //        else if(node.Value.CompareTo(element) < 0)
        //        {
        //            node = node.RightChild;
        //        }
        //    }

        //    //Тук имаме parentNode, който е родителя на null, но не знаем кое е null детето и затова проверяваме и на празното дете добавяме искания за добавяне newNode
        //    if (parentNode.Value.CompareTo(element) > 0)
        //    {
        //        parentNode.LeftChild = newNode;
        //    }
        //    else if (parentNode.Value.CompareTo(element) < 0)
        //    {
        //        parentNode.RightChild = newNode;
        //    }

        //    Count++;
        //}
        //public IAbstractBinarySearchTree<T> Search(T element)//Solved like in the lab lecture
        //{
        //    return Search(element, Root);
        //}

        //private IAbstractBinarySearchTree<T> Search(T value, Node<T> node)
        //{
        //    if(node == null)
        //    {
        //        return null;
        //    }

        //    if(node.Value.CompareTo(value) == 0)
        //    {
        //        return new BinarySearchTree<T>(node);//Връщаме копие на поддървото, за да не счупим голямото дърво при добавяне или махане на елемент!
        //    }
        //    else if(node.Value.CompareTo(value) > 0)
        //    {
        //        return Search(value, node.LeftChild); 
        //    }
        //    else
        //    {
        //        return Search(value, node.RightChild);
        //    }
        //}

        public IAbstractBinarySearchTree<T> Search(T element)//Solved like in the exercise lecture
        {
            var node = Root;

            if (node == null)
            {
                return null;
            }

            while (node != null)
            {
                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }
                else if (node.Value.CompareTo(element) < 0)
                {
                    node = node.RightChild;
                }
                else
                {
                    return new BinarySearchTree<T>(node);
                }
            }

            return null;
        }
        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action, Root);
        }
        private void EachInOrder(Action<T> action, Node<T> node)
        {
            if(node == null)
            {
                return;
            }

            EachInOrder(action, node.LeftChild);

            action.Invoke(node.Value);
               
            EachInOrder(action, node.RightChild);
        }
        public List<T> Range(T lower, T upper)
        {
            List<T> list = new List<T>();

            Range(lower, upper, Root, list);

            return list;
        }

        private void Range(T startRange, T endRange, Node<T> node, List<T> result)
        {
            if (node == null)
            {
                return;
            }

            //startRange = 5 - inStartRange = -1
            //endRange = 21 - inEndRange = 1
            //Root = 12
            var inStartRange = startRange.CompareTo(node.Value);//If > => 1, < => -1, == => 0
            var inEndRange = endRange.CompareTo(node.Value);

            if(inStartRange < 0)
            {
                Range(startRange, endRange, node.LeftChild, result);//Влизаме в първото дете наляво, защото е в рейнжда и 
            }

            if(inStartRange <= 0 && inEndRange >= 0)
            {
                result.Add(node.Value);
            }

            if (inEndRange > 0)
            {
                Range(startRange, endRange, node.RightChild, result); //проверяваме дали има дясно дете, което да е също в рейнжда
            }
        }

        public void DeleteMin()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }
            Root.LeftChild = DeleteMin(Root.LeftChild);
        }
        private Node<T> DeleteMin(Node<T> node)
        {
            if (node.LeftChild == null)
            {
                Count--;
                return node.RightChild;
            }

            node.LeftChild = DeleteMin(node.LeftChild);

            return node;
        }

        public void DeleteMax()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }

            Root.RightChild = DeleteMax(Root.RightChild);
        }

        private Node<T> DeleteMax(Node<T> node)
        {
            if(node.RightChild == null)
            {
                Count--;
                return node.LeftChild;
            }

            node.RightChild = DeleteMax(node.RightChild);

            return node;
        }
        public int GetRank(T element)
        {
            throw new NotImplementedException();//with return 0 - 86-100, with this 80-100
            //int countElements = 0;

            //if (Root == null)
            //{
            //    return countElements;
            //}

            //if (element.CompareTo(Root.Value) < 0)
            //{
            //    countElements = GetRankLeft(element, countElements, Root);
            //}
            //else if (element.CompareTo(Root.Value) >= 0)
            //{
            //    countElements = GetRankLeft(element, countElements, Root);
            //    //countElements += GetRankRight(element, countElements, Root);
            //}

            //return countElements;
        }
        //public int GetRankLeft(T element, int countElements, Node<T> node)//отваме наляво от root-а
        //{
        //    if (node == null)
        //    {
        //        return countElements;
        //    }

        //    var isSmaller = element.CompareTo(node.Value);//If > => 1, < => -1, == => 0

        //    if(isSmaller > 0)
        //    {
        //        GetRankLeft(element, countElements, node.LeftChild);//Влизаме в първото дете наляво, което е в рейнжда и така до нулата
        //    }

        //    if(isSmaller >= 0)
        //    {
        //        countElements++;
        //    }

        //    if (isSmaller > 0)
        //    {
        //        GetRankLeft(element, countElements, node.RightChild); //+ дясно дете на същия нод, което да е също в рейнжда
        //    }

        //    return countElements;
        //}

        //public int GetRankRight(T element, int countElements, Node<T> node)//отваме наляво от root-а
        //{
        //    return countElements;
        //}
    }
}
