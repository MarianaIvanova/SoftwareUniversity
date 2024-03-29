﻿namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _last;
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this._head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            var headItem = this._head.Item;
            var newHead = this._head.Next;
            this._head.Next = null;
            this._head = newHead;

            this.Count--;

            return headItem;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item, null);

            if (_last != null)//Count != 0 - работи по-точно
            {
                _last.Next = newNode;
                _last = newNode;
            }
            else
            {
                _head = newNode;
                _last = newNode;
            }

            Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this._head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;
            while (current != null)
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
                throw new InvalidOperationException();
        }
    }
}