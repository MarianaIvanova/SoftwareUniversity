using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Lab_CustomDoublyLinkedList
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        //public int Count { get; private set; }// If we define Count

        //public bool isReverse { get; set; } //this will help us to keep info if we have reversed the list like below
        //How to create constant reverse - questions for an interview?
        //We make it by switching the head and the tail like this and all elements are reverse too 
        //and we should keep a bool isReverse too:
        public void Reverse()
        {
            var oldHead = Head;
            Head = Tail;
            Tail = oldHead;
        }

        public void AddFirst(Node newHead)//If we work with int element instead of Node newHead
        {
            if(Head == null)//We can use count here i.e. if(Count == 0)
            {
                Head = newHead;//Head = new Node(element);
                Tail = newHead;//Tail = new Node(element);
            }
            else
            {
                //Node newHead = new Node(element);
                newHead.Next = Head;
                Head.Previous = newHead;
                Head = newHead;
            }
            //Count++;//If we use count
        }
        public void AddLast(Node newTail)//If we work with int element instead of Node newTail
        {
            if (Tail == null)//We can use count here i.e. if(Count == 0)
            {
                Head = newTail;//Head = new Node(element);
                Tail = newTail;//Tail = new Node(element);
            }
            else
            {
                //Node newTail = new Node(element);
                newTail.Previous = Tail;
                Tail.Next = newTail;
                Tail = newTail;
            }
            //Count++;//If we use count
        }

        public Node RemoveFirst()
        {
            //Node oldHead = Head.Value;//if we use int element, not Node 
            Node oldHead = Head;
            if (Head == null)//We can use count here i.e. if(Count == 0)
            {
                Console.WriteLine("The list is empty - invalid operation exception");
            }

            Head = Head.Next;
            Head.Previous = null;
            //if(Head != null)
            //{
            //    Head.Previous = null;
            //}
            //else
            //{
            //    Tail = null;
            //}
            //Count--;

            return oldHead;
        }
        public Node RemoveLast()
        {
            //Node oldTail = Tail.Value;//if we use int element, not Node 
            if (Tail == null)//We can use count here i.e. if(Count == 0)
            {
                Console.WriteLine("The list is empty - invalid operation exception");
            }
            Node oldTail = Tail;
            Tail = Tail.Previous;
            Tail.Next = null;
            //if(Tail != null)
            //{
            //    Tail.Next = null;
            //}
            //else
            //{
            //    Head = null;
            //}
            //Count--;

            return oldTail;
        }

        public void ForEach(Action<Node> action)
        {
            Node currentNode = Head;
            while(currentNode != null)
            {
                action(currentNode);//action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
        //Instead of so long print like this:
        //public void PrintList()
        //{
        //    Node currentNode = Head;
        //    while (currentNode != null)
        //    {
        //        Console.WriteLine(currentNode.Value);
        //        currentNode = currentNode.Next;
        //    }
        //}
        //we can make this:
        public void PrintList()
        {
            this.ForEach(node => Console.WriteLine(node.Value));
        }

        public void ReverseForEach(Action<Node> action)
        {
            Node currentNode = Tail;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Previous;
            }
        }
        public void ReversePrintList()
        {
            this.ReverseForEach(node => Console.WriteLine(node.Value));
        }
        public Node[] ToArray()//int[] ToArray()
        {
            List<Node> list = new List<Node>();
            this.ForEach(node => list.Add(node));
            return list.ToArray();

            //in case we use int element instead of node
            //int[] array = new int[this.Count];
            //int counter = 0;
            //Node currentNode = Head;
            //while(currentNode != null)
            //{
            //    array[counter] = currentNode.Value;
            //    currentNode = currentNode.Next;
            //    counter++;
            //}
            //return array;
        }
        public bool Remove(int value)//It is very slowly working for big lists
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                if(currentNode.Value == value)
                {
                    currentNode.Previous.Next = currentNode.Next;//If the value is the first or the last in the list - it gives mistake the way we have made next and previous
                    currentNode.Next.Previous = currentNode.Previous;//If the value is the first or the last in the list - it gives mistake the way we have made next and previous
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }

        public bool Contains(int value)//It is very slowly working for big lists
        {
            bool isFound = false;
            ForEach(node =>
            {
                if (node.Value == value)
                {
                    isFound = true;
                }
            });

            return isFound;
        }
    }
}
