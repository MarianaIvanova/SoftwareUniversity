using System;

namespace _1_Lab_Complexity
{
    class Program
    {
        //Calculate maximum steps to find the result.
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());//5 //100000
            //Console.WriteLine(GetOperationsCount(n));//25

            //O(3 + 3n + 3(n^2)) 
            Console.WriteLine(3 + 3 * n + 3 * (n * n));//93 //30000300003
            //O(n^2) 
            Console.WriteLine(n * n);//25 //10000000000
        }
        //BigO() - Big O notation - в повечето случаи е обвързана с n:
        //O(3 + 3n + 3(n^2)) - това е comlexity-то на този алгоритъм
        //O(3 + 15 + 75) - при n = 5
        //O(93) - при n = 5
        static long GetOperationsCount(int n)//Това е функция, математическа или програмистка
        {
            // Грубо броим операциите, без да отчитаме сложността им
            // дефиниране на counter: 1
            // дефиниране на i = 0 в първия цикъл: 1
            // дефиниране на i < n в първия цикъл: n
            // дефиниране на i ++ в първия цикъл: n
            // дефиниране на j = 0 в втория цикъл: n
            // дефиниране на j < n в втория цикъл: n^2
            // дефиниране на j ++ в втория цикъл: n^2
            // дефиниране на counter ++ в втория цикъл: n^2
            // дефиниране на return counter: 1
            // ОБЩО: 3 + 3n + 3(n^2) //При n = 5, имаме 93 НО - СЕ ПРИЕМА САМО n^2 т.е. 25
            long counter = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    counter++;
            return counter;
        }
    }
}
