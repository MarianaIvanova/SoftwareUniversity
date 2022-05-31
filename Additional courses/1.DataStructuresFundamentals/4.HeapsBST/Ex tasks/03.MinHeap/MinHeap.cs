namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public MinHeap()
        {
            this._elements = new List<T>();
        }

        public int Size { get { return _elements.Count; } }

        public T Dequeue()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
            //save max
            T low = _elements[0];
            //swap top with last
            _elements[0] = _elements[Size - 1];
            //delete last
            _elements.RemoveAt(Size - 1);
            //Heapify
            if (Size > 1)
            {
                HeapifyDown(0);
            }
            return low;
        }

        public void Add(T element)
        {
            _elements.Add(element);
            if(Size > 1)
            {
                HeapifyUp(Size - 1);
            }
        }

        private void HeapifyUp(int index)
        {
            if (index == 0) return;

            int indexParent = (index - 1) / 2;

            if (_elements[index].CompareTo(_elements[indexParent]) < 0)//Add  where T: IComparable<T>  to the class to use compare - it's already added in the interface
            {
                T tmp = _elements[indexParent];
                _elements[indexParent] = _elements[index];
                _elements[index] = tmp;

                HeapifyUp(indexParent);
            }
        }
        private void HeapifyDown(int index)//Heapify from up to down
        {
            var indexLeftChild = index * 2 + 1;
            var indexRightChild = index * 2 + 2;
            var indexMinChild = indexLeftChild;

            if (indexLeftChild >= Size) return;

            if (indexRightChild < Size && _elements[indexLeftChild].CompareTo(_elements[indexRightChild]) > 0)
            {
                indexMinChild = indexRightChild;
            }

            if (_elements[index].CompareTo(_elements[indexMinChild]) > 0)
            {
                var tmp = _elements[index];
                _elements[index] = _elements[indexMinChild];
                _elements[indexMinChild] = tmp;

                HeapifyDown(indexMinChild);
            }
        }
        public T Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }

            return _elements[0];
        }
    }
}
