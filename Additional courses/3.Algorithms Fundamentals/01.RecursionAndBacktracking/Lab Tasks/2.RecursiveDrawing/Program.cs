using System;

namespace _2.RecursiveDrawing
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            DrawingRecursively(n);
        }

        private static void DrawingRecursively(int row)
        {
            //Base
            if(row == 0)
            {
                return;
            }

            //Pre-actions
            //for (int i = 1; i <= row; i++)
            //{
            //    Console.Write("*");
            //}
            //Console.WriteLine();

            Console.WriteLine(new string('*', row));

            //Recursion
            DrawingRecursively(row - 1);

            //Post-actions

            //for (int i = 1; i <= row; i++)
            //{
            //    Console.Write("#");
            //}
            //Console.WriteLine();

            Console.WriteLine(new string('#', row));
        }
    }
}
