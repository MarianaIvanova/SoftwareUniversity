namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;
        public MaxHeap()
        {
            heap = new List<T>();
        }
        public int Size { get { return heap.Count; } }

        public void Add(T element)
        {
            heap.Add(element);
            Heapify(Size - 1);
        }

        private void Heapify(int index)
        {
            if (index == 0) return;

            int indexParent = (index - 1) / 2;

            if(heap[index].CompareTo(heap[indexParent]) > 0)//Add  where T: IComparable<T>  to the class to use compare - it's already added in the interface
            {
                T tmp = heap[indexParent];
                heap[indexParent] = heap[index];
                heap[index] = tmp;

                Heapify(indexParent);
            }
        }
        public T Peek()
        {
            if(Size == 0)
            {
                throw new InvalidOperationException();
            }

            return heap[0];
        }
    }
}
