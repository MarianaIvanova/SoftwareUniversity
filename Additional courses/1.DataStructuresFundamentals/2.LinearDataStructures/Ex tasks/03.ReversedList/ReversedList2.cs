namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    //The reversed list should support the same operations that the List we have developed in the Lab implements but in a reversed order of adding elements.
    //ИЗПОЛЗВАНО ТУК! Hint: you can keep the elements in the order of their adding but access them in reversed order (from end to start).
    public class ReversedList_NOT<T> : IAbstractList<T>//ALL is like List, but the access of the elements is in reverse order
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public ReversedList_NOT()
            : this(DefaultCapacity) { }

        public ReversedList_NOT(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this._items = new T[capacity];
        }

        public T this[int index]//Ако работим с елементите на обратно - трябва да разменя индексите на get и set
        {
            get
            {
                ValidateIndex(index);
                return _items[Count - index - 1];//To be get reversed!!
            }
            set
            {
                ValidateIndex(index);
                _items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)//in normal order of adding elements.
        {
            _items = Grow(_items, Count);

            _items[Count++] = item;
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
            int realIndex = 0;

            for (int i = Count - 1; i >= 0; i--)
            {
                if (_items[i].Equals(item))
                {
                    return realIndex;//- Ако въртим от 0 до Count - 1 тук връщаме return Count - i - 1; НО не е пълно! 
                }

                realIndex++;
            }

            return isContaining;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            _items = Grow(_items, Count);
            //Достъпваме като ревърс по обратен ред 
            for (int i = Count; i >= Count - index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[Count - index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            bool isItRemoved = false;

            for (int i = Count - 1; i >= 0; i--)
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

            for (int i = Count - index - 1; i > 0; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[0] = default;

            Count--;
        }

        public IEnumerator<T> GetEnumerator()//Енумераторите са тези, които ни позволяват да направим foreach на дадена колекция. Трябва да се итерира в обратен ред, затова слагаме for в намалящ ред! За да могат тестовете да работят в обратен ред, както и аз работя!
        {
            for (int i = Count - 1; i >= 0; i--)
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

        private T[] Grow(T[] _currentItems, int itemsCount)
        {
            if (Count == _currentItems.Length)
            {
                var newArray = new T[_currentItems.Length * 2];
                for (int i = 0; i < _currentItems.Length; i++)
                {
                    newArray[i] = _currentItems[i];
                }
                //Array.Copy(_currentItems, newArray, itemsCount);
                _currentItems = newArray;
            }

            return _currentItems;
        }
    }
}