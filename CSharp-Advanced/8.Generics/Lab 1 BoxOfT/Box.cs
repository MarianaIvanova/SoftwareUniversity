using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> internalStack;
        public Box()
        {
            internalStack = new Stack<T>();
        }
        public int Count 
        { 
            get
            {
                return internalStack.Count;
            }
        }

        public void Add(T element)
        {
            internalStack.Push(element);
        }

        public T Remove()//RemoveTopmostElement()
        {
            if(internalStack.Count == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return internalStack.Pop();
        }
    }
}
