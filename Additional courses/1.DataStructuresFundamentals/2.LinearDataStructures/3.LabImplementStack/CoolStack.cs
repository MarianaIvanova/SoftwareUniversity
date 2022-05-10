using _2.LabImplementLinkedList;

namespace _3.LabImplementStack
{
    public class CoolStack<T>
    {
        private LinkedList<T> linkedList;//Използваме създадения клас в другия проект LinkedList

        public CoolStack()
        {
            linkedList = new LinkedList<T>();
        }

        public int Count { get { return linkedList.Count; } }
        //public int Count { get => linkedList.Count; }

        public void Push(T element)
        {
            linkedList.Add(element);//Добавяме го отпред! Ако използваме AddLast - ще добави накрая
        }

        public T Peek()
        {
            return linkedList.Head.Value;//Value to return T
        }

        public T Pop()
        {
            //По-дълго:
            //var head = linkedList.Head;
            //linkedList.RemoveHead();
            //return head.Value;

            return linkedList.RemoveHead().Value;
        }
    }
}
