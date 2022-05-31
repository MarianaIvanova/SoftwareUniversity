namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public PriorityQueue()
        {
            heap = new List<T>();
        }

        public int Size { get { return heap.Count; } }

        public T Dequeue()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
            //save max
            T top = heap[0];
            //swap top with last
            heap[0] = heap[Size - 1];
            //delete last
            heap.RemoveAt(Size - 1);
            //Heapify
            HeapifyDown(0);

            return top;
        }

        public void Add(T element)
        {
            heap.Add(element);
            HeapifyUp(Size - 1);
        }

        public T Peek()
        {
            if(Size == 0)
            {
                throw new InvalidOperationException();
            }

            return heap[0];
        }

        private void HeapifyUp(int index)//Heapify from down to up
        {
            if (index == 0) return;

            var indexParent = (index - 1) / 2;

            if (heap[index].CompareTo(heap[indexParent]) > 0)//Add  where T: IComparable<T>  to the class to use compare
            {
                T tmp = heap[index];
                heap[index] = heap[indexParent];
                heap[indexParent] = tmp;

                HeapifyUp(indexParent);
            }
        }
        private void HeapifyDown(int index)//Heapify from up to down
        {
            var indexLeftChild = index * 2 + 1;
            var indexRightChild = index * 2 + 2;
            var indexMaxChild = indexLeftChild;

            if (indexLeftChild >= Size) return;

            if(indexRightChild < Size && heap[indexLeftChild].CompareTo(heap[indexRightChild]) < 0)
            {
                indexMaxChild = indexRightChild;
            }

            if(heap[index].CompareTo(heap[indexMaxChild]) < 0)
            {
                var tmp = heap[index];
                heap[index] = heap[indexMaxChild];
                heap[indexMaxChild] = tmp;

                HeapifyDown(indexMaxChild);
            }
        }
    }
}
