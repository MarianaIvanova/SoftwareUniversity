using System;
using System.Collections.Generic;

namespace _3LabPriorityQueue
{
    //MAX
    public class PriorityQueue<T> where T: IComparable<T> //За да можем да сравняваме T
    {
        private List<T> heap;

        public PriorityQueue()
        {
            heap = new List<T>();
        }

        public int Size { get { return heap.Count; } }

        public T Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }

            return heap[0];
        }

        public T Dequeue()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
            //save top
            T top = heap[0];
            //swap top with last
            heap[0] = heap[heap.Count - 1];
            //delete last
            heap.RemoveAt(heap.Count - 1);
            //heapify from top to down
            HeapifyDown(0);

            return top;
        }
        public void Add(T element)
        {
            heap.Add(element);
            HeapifyUp(heap.Count - 1);
        }

        private void HeapifyUp(int index)//Heapify from down to up
        {
            if (index == 0) return;

            var parentIndex = (index - 1) / 2;

            if (heap[index].CompareTo(heap[parentIndex]) > 0) //Add  where T: IComparable<T>  to the class to use compare
            {
                T tmp = heap[parentIndex];
                heap[parentIndex] = heap[index];
                heap[index] = tmp;

                HeapifyUp(parentIndex);
            }
        }
        private void HeapifyDown(int index)//Heapify from up to down
        {
            //if (index == 0) return;

            int leftChildIndex = index * 2 + 1;
            int rightChildIndex = index * 2 + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= heap.Count) return;

            if ((rightChildIndex < heap.Count) && heap[leftChildIndex].CompareTo(heap[rightChildIndex]) < 0)
            {
                maxChildIndex = rightChildIndex;
            }
            
            if(heap[index].CompareTo(heap[maxChildIndex]) < 0)
            {
                T tmp = heap[index];
                heap[index] = heap[maxChildIndex];
                heap[maxChildIndex] = tmp;

                HeapifyDown(maxChildIndex);
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
