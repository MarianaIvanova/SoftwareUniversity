namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            bool isThereItem = false;

            Node<T> current = _head;

            while(current != null)
            {
                if(current.Value.Equals(item))
                {
                    isThereItem = true;
                }

                current = current.Next;
            }

            return isThereItem;
        }

        public T Dequeue()
        {
            InsureNotEmpty();

            var _headOld = _head;

            if(_head.Next != null)
            {
                _head = _head.Next;
            }
            else
            {
                _head.Next = null;
                _head = null;
            }
            
            Count--;

            return _headOld.Value;
        }

        public void Enqueue(T item)
        {
            Node<T> newItem = new Node<T>(item);
            newItem.Next = null;
            Node<T> current = _head;

            if(current != null)
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newItem;
            }
            else
            {
                _head = newItem;
            }

            Count++;
        }

        public T Peek()
        {
            InsureNotEmpty();

            return _head.Value;
        }

        public IEnumerator<T> GetEnumerator()//Енумераторите са тези, които ни позволяват да направим foreach на дадена колекция
        {
            Node<T> current = _head;

            while(current != null)
            {
                yield return current.Value;//Това не е връщане само, а многократно връщане, защото имаме енумератор. Ако беше само return, за всяко влизане в метода, щяхме да изпълним само 1 return, а сега при yield return, ще върне толкова пъти return, колкото завъртания имаме на цикъла - т.е. връщаме енумератор (който може да е всяква линейна структура)
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void InsureNotEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}