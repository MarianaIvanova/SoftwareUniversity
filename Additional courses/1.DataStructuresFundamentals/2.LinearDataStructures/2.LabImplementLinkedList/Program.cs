using System;

namespace _2.LabImplementLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Това беше нужно, когато имахме САМО клас Node, след като създадохме клас LinkedList -  вече не ни е нужно!
            ////1. Създаваме нодовете
            //Node<int> node1 = new Node<int>(1);//This is the head
            //Node<int> node2 = new Node<int>(2);
            //Node<int> node3 = new Node<int>(3);
            //Node<int> node4 = new Node<int>(4);

            ////2. Навръзваме нодовете
            //node1.Next = node2;
            //node2.Next = node3;
            //node3.Next = node4;

            ////Console.WriteLine(node1.Next.Next.Next.Value);//4

            ////3. Обхождане на LinkedList structure става така
            //var currentNode = node1;
            //while(currentNode != null)
            //{
            //    Console.WriteLine(currentNode.Value);
            //    currentNode = currentNode.Next;
            //}

            ////var node = node1.Next.Next.Next.Next.Next.Next.Next.Next.Next; //безброй пъти можем да го напишем и въпреки това, ще се компилира, защото това е рекурсивна структура от данни. Ако го стартираме, ще гръмне обаче. 
            ////1
            ////2
            ////3
            ////4

            LinkedList<int> linkedList = new LinkedList<int>();

            for (int i = 0; i < 10; i++)//ПОВЕДЕНИЕТО МУ ТУК Е КАТО НА STACK!
            {
                linkedList.Add(i);
            }

            //Обхождане на LinkedList structure става така
            Node<int> currentNode = linkedList.Head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
            //9
            //8
            //7
            //6
            //5
            //4
            //3
            //2
            //1
            //0

            //Console.WriteLine();
            //Console.WriteLine($"Removed: {linkedList.RemoveHead().Value}");//Ще изтрие 9 и ще принтира Removed: 9
            //Console.WriteLine($"Removed: {linkedList.RemoveHead().Value}");//Ще изтрие 8 и ще принтира Removed: 8
            //Console.WriteLine($"Removed: {linkedList.RemoveHead().Value}");//Ще изтрие 7 и ще принтира Removed: 7
            //Console.WriteLine();

            //currentNode = linkedList.Head;
            //while (currentNode != null)
            //{
            //    Console.WriteLine(currentNode.Value);
            //    currentNode = currentNode.Next;
            //}
            ////6
            ////5
            ////4
            ////3
            ////2
            ////1
            ////0

            Console.WriteLine();

            for (int i = 0; i < 11; i++)//ПОВЕДЕНИЕТО МУ ТУК Е КАТО НА QUEUE!
            {
                linkedList.AddLast(i);
            }

            //Обхождане на LinkedList structure става така
            currentNode = linkedList.Head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
            //0
            //1
            //2
            //3
            //4
            //5
            //6
            //7
            //8
            //9
            //10

            Console.WriteLine($"Head is: {linkedList.Head.Value}");//Head is: 9
            Console.WriteLine($"Last is: {linkedList.Last.Value}");//Last is: 10

        }
    }
}
