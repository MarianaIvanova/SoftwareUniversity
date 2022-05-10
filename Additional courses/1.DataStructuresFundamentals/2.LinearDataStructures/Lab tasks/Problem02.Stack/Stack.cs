namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            bool isThereElement = false;

            var current = _top;

            while(current != null)
            {
                if(current.Value.Equals(item))
                {
                    isThereElement = true;
                }

                current = current.Next;
            }

            return isThereElement;
        }
        public T Peek()
        {
            this.InsureNotEmpty();

            return _top.Value;
        }

        public T Pop()
        {
            this.InsureNotEmpty();
            var _topOld = _top;

            _top = _top.Next;
            Count--;

            return _topOld.Value;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = _top;
            this._top = newNode;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()//Енумераторите са тези, които ни позволяват да направим foreach на дадена колекция. В нашата задача не използваме foreach, но в тестовете се използва, затова ни е нужен!
        {
            Node<T> current = _top;

            while (current != null)
            {
                yield return current.Value;//Това не е връщане само, а многократно връщане, защото имаме енумератор. Ако беше само return, за всяко влизане в метода, щяхме да изпълним само 1 return, а сега при yield return, ще върне толкова пъти return, колкото завъртания имаме на цикъла - т.е. връщаме енумератор (който може да е всяква линейна структура)
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void InsureNotEmpty()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}