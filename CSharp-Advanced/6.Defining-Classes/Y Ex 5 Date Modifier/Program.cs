using System;
using System.Linq;

namespace DateModifierExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();
            int difference = dateModifier.GetDiffBetweenTwoDays(firstDate, secondDate);
            Console.WriteLine(difference);
        }
    }
}
