using System;

namespace _2_Lab_LinkedListDoubly
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            for (int i = 0; i < 10; i++)
            {
                list.AddHead(new Node(i));
            }
            //or it's equivalent is for i = 3:
            //Node head = new Node(0);
            //Node second = new Node(1);
            //head.Next = second;
            //Node third = new Node(2);
            //second.Next = third;
            //Node forth = new Node(3);
            //third.Next = forth;

            list.PrintList();//on new line is printing from 9 to 0

            //This is for stack:
            Console.WriteLine($"Poped {list.Pop().Value}");//Poped 9
            Console.WriteLine($"Poped {list.Pop().Value}");//Poped 8
            Console.WriteLine($"Poped {list.Pop().Value}");//Poped 7

            list.PrintList();//on new line is printing from 6 to 0
            list.ReversePrintList();//on new line is printing from 0 to 9 - because the pop above is done only for changing the head 
            //- it is not deleting the elements, so here we start with tail and finish when there is no elements, that's why 
            //it is not from 0 to 6

            Node currentHead = list.Head;
            while(currentHead != null)
            {
                Console.WriteLine(currentHead.Value);
                currentHead = currentHead.Next;
            }
            ////on new line is printing from 6 to 0, but how we keep the data from 7 to 9 (we can see it only using tail and ReversePrintList()
        }
    }
}
