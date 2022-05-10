namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {         
            Node<T> headNew = new Node<T>(item);
            Node<T> headOld = head;
            head = headNew;
            head.Previous = null;

            if (headOld != null)//Count != 0 - работи по-точно, ако преди това не сме добавили главата, а я добавим в иф.
            {
                if (headOld.Next != null)
                {
                    head.Next = headOld;
                    headOld.Previous = head;
                }
                else
                {
                    head.Next = tail;                  
                    tail.Previous = head;
                }
            }
            else
            {
                tail = head;
                head.Next = tail;//Това може да не е нужно
                tail.Next = null;
                tail.Previous = head;//Това може да не е нужно
            }

            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> tailNew = new Node<T>(item);
            Node<T> tailOld = tail;
            tail = tailNew;
            tail.Next = null;

            if (tailOld != null)
            {
                if (tailOld.Previous != null)
                {
                    tail.Previous = tailOld;
                    tailOld.Next = tail;
                }
                else
                {
                    head.Next = tail;
                    tail.Previous = head;
                }
            }
            else
            {
                head = tail;
                head.Next = tail;
                head.Previous = null;
                tail.Previous = head;
            }

            Count++;

        }

        public T GetFirst()
        {
            EnsureNotEmpty();

            return head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            return tail.Item;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            Node<T> headOld = head;
            
            if(head.Next != null)
            {
                head = head.Next;
                head.Previous = null;
                headOld.Next = null;
            }
            else
            {
                head = null;
                tail = null;
            }

            Count--;

            return headOld.Item;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            Node<T> tailOld = tail;

            if (tail.Previous != null)
            {
                tail = tail.Previous;
                tail.Next = null;
                tailOld.Next = null;
            }
            else
            {
                head = null;
                tail = null;
            }

            Count--;

            return tailOld.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.head;

            while(current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }              
        }
    }
}