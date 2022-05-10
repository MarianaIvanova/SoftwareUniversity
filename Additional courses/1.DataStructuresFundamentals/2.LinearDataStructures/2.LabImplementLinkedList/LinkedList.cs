using System;
using System.Collections.Generic;

namespace _2.LabImplementLinkedList
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Last { get; set; }
        public int Count { get; set; }

        public void Add(T element)//Новият елемент става вече главата на линкнатия лист, т.е. добавяме от ляво.
        {
            Node<T> newHead = new Node<T>(element);
            newHead.Next = Head;

            if(Head == null)
            {
                Last = newHead;//В този случай имаме само един елемент, който добавяме в момента и той е Head и Last
            }
            Head = newHead;
            Count++;
        }

        public void AddLast(T element)//Новият елемент става вече последния на линкнатия лист, т.е. добавяме от дясно.
        {
            Node<T> newLast= new Node<T>(element);

            if (Last == null)
            {
                Head = newLast;
                Last = newLast;
            }
            else
            {
                Last.Next = newLast;
                Last = newLast;//Тук само променяме референцията т.е. името Last да бъде за новия елемент, връзката от предишния ред се запазва.
            }

            Count++;
        }

        public Node<T> RemoveHead()
        {
            Node<T> oldHead = Head;//Запазихме я, за да я върнем.
            Head = Head.Next;

            if(Head == null)
            {
                Last = null;
            }

            if(Count > 0)
            {
                Count--;
            }

            return oldHead;
        }
    }
}
