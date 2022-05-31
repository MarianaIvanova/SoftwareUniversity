using System;
using System.Collections.Generic;

namespace _2LabHeap
{
    //MAX
    public class Heap<T> where T: IComparable<T> //За да можем да сравняваме T
    {
        private List<T> heap;

        public Heap()
        {
            heap = new List<T>();
        }

        public int Size { get { return heap.Count; } }

        public T Peek()//GetMax
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }

            return heap[0];
        }

        public void Add(T element)
        {
            heap.Add(element);
            Heapify(heap.Count - 1);
        }

        private void Heapify(int index)//Heapify from down to up
        {
            if (index == 0) return;

            var parentIndex = (index - 1) / 2;

            if(heap[index].CompareTo(heap[parentIndex]) > 0) //Add  where T: IComparable<T>  to the class to use compare
            {
                T tmp = heap[parentIndex];
                heap[parentIndex] = heap[index];
                heap[index] = tmp;

                Heapify(parentIndex);
            }
        }

        public string DFSInOrder(int index, int indent)
        {
            string result = default;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            if (leftChild < heap.Count)
            {
                result += DFSInOrder(leftChild, indent + 3);
            }

            result += $"{new string(' ', indent)}{heap[index]}\n";

            if (rightChild < heap.Count)
            {
                result += DFSInOrder(rightChild, indent + 3);
            }

            return result;
        }
    }
}
