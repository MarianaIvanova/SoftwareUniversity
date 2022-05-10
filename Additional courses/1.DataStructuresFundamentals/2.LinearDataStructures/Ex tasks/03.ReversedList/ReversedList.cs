namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    //The reversed list should support the same operations that the List we have developed in the Lab implements but in a reversed order of adding elements.
    //НЕ СЪМ ГО ИЗПОЛЗВАЛА ТУК! Hint: you can keep the elements in the order of their adding but access them in reversed order (from end to start). ONE TEST IS NOT WORKING!
    public class ReversedList<T> : IAbstractList<T>//ALL is like List, but the access of the elements is in reverse order
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this._items = new T[capacity];
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
                _items[Count - index - 1] = value;//To be reversed!!
            }
        }

        public int Count { get; private set; }

        public void Add(T item)//in a reversed order of adding elements.
        {
            Grow();
            for (int i = Count; i >= 1; i--)
            {
                _items[i] = _items[i - 1];
            }
            _items[0] = item;
            Count++;
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
            //int realIndex = 0;

            //for (int i = Count - 1; i >= 0; i--)
            //{
            //    if (_items[i].Equals(item))
            //    {
            //        return realIndex;
            //    }

            //    realIndex++;
            //}

            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }

            return isContaining;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            Grow();
            ////Достъпваме като ревърс по обратен ред - НЕ МОГА ДА ГО НАПРАВЯ ДА РАБОТИ ТАКА
            //for (int i = Count; i >= Count - index; i--)
            //{
            //    _items[i] = _items[i - 1];
            //}

            //_items[Count - index] = item;
            //Count++;

            for (int i = Count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = item;

            Count++;
        }

        public bool Remove(T item)
        {
            bool isItRemoved = false;

            for (int i = 0; i < Count; i++)
            {
                if (_items[i].ToString() == item.ToString())
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

            Count--;
        }

        private void Grow()
        {
            if (Count == _items.Length)
            {
                var newArray = new T[_items.Length * 2];
                for (int i = 0; i < _items.Length; i++)
                {
                    newArray[i] = _items[i];
                }

                _items = newArray;
            }
        }
        public IEnumerator<T> GetEnumerator()//Енумераторите са тези, които ни позволяват да направим foreach на дадена колекция
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
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