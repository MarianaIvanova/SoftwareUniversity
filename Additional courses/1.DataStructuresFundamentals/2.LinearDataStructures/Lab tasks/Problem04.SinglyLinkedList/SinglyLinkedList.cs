namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _last;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newItem = new Node<T>(item);
            newItem.Next = null;

            if(_head != null)
            {
                newItem.Next = _head;
                _head = newItem;
            }
            else
            {
                _head = newItem;
                _last = newItem;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newItem = new Node<T>(item);
            newItem.Next = null;

            if(_last != null)
            {
                _last.Next = newItem;
                _last = newItem;
            }
            else
            {
                _head = newItem;
                _last = newItem;
            }

            Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();

            return _head.Value;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            return _last.Value;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            Node<T> _headOld = _head;
            _head = _head.Next;
            Count--;

            return _headOld.Value;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            Node<T> _lastOld = _last;
            Node<T> current = _head;

            if(current.Next != null)
            {
                while (current.Next != _last)
                {
                    current = current.Next;
                }

                current.Next = null;
                _last = current;
            }
            else
            {
                _head = null;
                _last = null;
            }

            Count--;

            return _lastOld.Value;
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
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }               
        }
    }
}