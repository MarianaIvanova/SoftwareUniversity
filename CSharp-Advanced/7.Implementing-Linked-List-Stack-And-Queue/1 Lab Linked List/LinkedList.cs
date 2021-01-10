using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Lab_LinkedListSingly
{
    public class LinkedList
    {
        public Node Head { get; set; }
        //This is not necessary in Singly Linked List:
        //public Node Tail { get; set; }

        public void AddHead(Node node)
        {
            node.Next = Head;
            Head = node;
        }

        //if it was a stack it should be added this:
        public Node Pop()
        {
            var oldHead = this.Head;
            this.Head = this.Head.Next;//And we forget that the old one is existing, cause there is no link towards it. We have it 
            //only in oldHead

            return oldHead;
        }
        //if it was a stack it should be added this:
        public Node Peek()
        {
            return this.Head;
        }
        //if we want the value of the head:
        public int PeekValue()
        {
            return this.Head.Value;
        }

        public void PrintList()
        {
            Node currentNode = Head;
            while(currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
    }
}
