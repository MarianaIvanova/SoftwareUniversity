using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Ex_CustomDataStructure_LinkedList
{
    public class CustomStack
    {
        private const int INITIAL_CAPACITY_STACK = 4;
        private const string EMPTY_STACK_EXC_MSG = "Stack is empty!";
        private int[] itemsStack;

        public CustomStack()
        {
            this.itemsStack = new int[INITIAL_CAPACITY_STACK];
        }

        public int Count { get; private set; }//private set means we can manipulate the count only in this class i.e. this.Count = 1;
        //get is not private and we can print for example from other classes

        //other way is to define it as private int count; and then int the CustomStack() to define it as this.count = 0; and then:
        //public int Count
        //{
        //    get
        //    {
        //        return this.count;
        //    }
        //}

        private void Resize()
        {
            int[] copy = new int[this.itemsStack.Length * 2];
            for (int i = 0; i < this.itemsStack.Length; i++)
            {
                copy[i] = this.itemsStack[i];
            }

            this.itemsStack = copy;
        }

        public void Push(int item)
        {
            if(this.Count == this.itemsStack.Length)
            {
                this.Resize();
            }

            this.itemsStack[this.Count] = item;
            this.Count++;
        }

        public int Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentOutOfRangeException(EMPTY_STACK_EXC_MSG);
            }

            int itemToDelete = this.itemsStack[this.Count - 1];
            this.itemsStack[this.Count - 1] = default;
            this.Count--;
            return itemToDelete;
        }
        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentOutOfRangeException(EMPTY_STACK_EXC_MSG);
            }

            int itemToPeek = this.itemsStack[this.Count - 1];//Last item
            return itemToPeek;
        }

        public void ForEach(Action<int> action)//We can make it as ForEach(Action<object> action), but we work with int, 
            //so some problem may appear with this object
        {
            for (int i = 0; i < this.Count; i++)
            {
                //action(this.itemsStack[i]);//Will arrange it 1 2 3 4 5
                action(this.itemsStack[this.Count - i - 1]);////Will arrange it as stack 5 4 3 2 1
            }
        }
    }
}
