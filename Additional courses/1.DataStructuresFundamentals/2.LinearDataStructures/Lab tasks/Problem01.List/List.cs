namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;
        private int number;
        public List()
            : this(DEFAULT_CAPACITY) 
        {
        }

        public List(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));
            _items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _items[index];
            }
            set
            {
                ValidateIndex(index);
                _items[index] = value;
            }
        }

        public int Count { get { return number; } }
        private int CountInternalArray { get { return _items.Length; } }

        public void Add(T item)
        {
            Grow();
            _items[number++] = item;
        }

        public bool Contains(T item)
        {
            bool isContaining = false;

            for (int i = 0; i < Count; i++)
            {
                if (_items[i].ToString() == item.ToString())
                {
                    isContaining = true;
                }
            }

            return isContaining;
        }


        public int IndexOf(T item)
        {
            int isContaining = -1;

            for (int i = 0; i < Count; i++)
            {
                if (_items[i].ToString() == item.ToString())
                {
                    isContaining = i;
                }
            }

            return isContaining;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            Grow();

            for (int i = Count; i > index ; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = item;
            this.number++;
        }

        public bool Remove(T item)
        {
            bool isItRemoved = false;

            for (int i = 0; i < Count; i++)
            {
                if(_items[i].ToString() == item.ToString())
                {
                    RemoveAt(i);
                    isItRemoved = true;
                }
            }

            return isItRemoved;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < Count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[Count - 1] = default;

            this.number--;
        }

        public IEnumerator<T> GetEnumerator()//Енумераторите са тези, които ни позволяват да направим foreach на дадена колекция
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void Grow()
        {
            if(Count == _items.Length)
            {
                var newArray = new T[_items.Length * 2];
                for (int i = 0; i < _items.Length; i++)
                {
                    newArray[i] = _items[i];
                }

                _items = newArray;
            }
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }
    }
}