using System;

namespace _1_Ex_CustomDataStructure_LinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomList myCustomList = new CustomList();
            for (int i = 1; i <= 4; i++)
            {
                myCustomList.Add(i);
            }

            //The list is 1 2 3 4

            myCustomList.RemoveAt(1);//The list is 1 3 4 0

            //myCustomList.Insert(10, 5); //Out of range exception
            myCustomList.Insert(2, 10);//The list is 1 3 10 4

            Console.WriteLine(myCustomList.Contains(3));//True
            Console.WriteLine(myCustomList.Contains(9));//False

            myCustomList.Swap(0, 3);//The list is 4 3 10 1

            Console.WriteLine(myCustomList); //4, 3, 10, 1 - it comes from public override string ToString()

            CustomStack myCustomStack = new CustomStack();
            for (int i = 1; i <= 5; i++)
            {
                myCustomStack.Push(i);
            }

            myCustomStack.ForEach(x => Console.WriteLine(x));//Action

            Console.WriteLine();

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(myCustomStack.Peek());
                Console.WriteLine(myCustomStack.Pop());
            }

            //myCustomStack.Peek();//Exception
            //myCustomStack.Pop();//Exception
        }
    }
}
