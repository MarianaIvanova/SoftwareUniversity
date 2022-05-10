using System;
using Problem04.BalancedParentheses;

namespace HelpProjectFor4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var solve = new BalancedParenthesesSolve();

            solve.AreBalanced(input);
        }
    }
}
