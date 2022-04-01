using System;

namespace _3.Generating0_1Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());//3

            var array = new int[n];

            Gen01(array, 0);
            //000
            //001
            //010
            //011
            //100
            //101
            //110
            //111
        }
        private static void Gen01(int[] array, int index)
        {
            //Base
            if(index == array.Length)
            {
                Console.WriteLine(string.Join(string.Empty, array));//000 then 001 then 010 and so on
                return;
            }

            for (int i = 0; i < 2; i++)//For 0 and 1
            {
                array[index] = i;//On the index we asign 0 or 1

                Gen01(array, index + 1);//We make the same for the next index + 1 and so on
            }
        }
    }
}
//Generate all n-bit vectors of 0 and 1 in lexicographic order.
