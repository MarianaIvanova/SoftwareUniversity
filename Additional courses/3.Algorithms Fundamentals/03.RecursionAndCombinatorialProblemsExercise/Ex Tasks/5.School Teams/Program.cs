using System;
using System.Collections.Generic;

namespace _5.School_Teams
{
    class Program
    {
        private static int k = 3; //Number of girls to be chosen
        private static int p = 2; //Number of boys to be chosen
        private static string[] allGirls;
        private static string[] allBoys;
        private static string[] combinationGirls;
        private static string[] combinationBoys;
        private static List<string> listsOfCombGirls;
        private static List<string> listsOfCombBoys;
        static void Main(string[] args)
        {
            allGirls = Console.ReadLine().Split(", ");
            allBoys = Console.ReadLine().Split(", ");

            combinationGirls = new string[k];
            combinationBoys = new string[p];

            listsOfCombGirls = new List<string>();
            listsOfCombBoys = new List<string>();

            GenCombinationsGirlsWithoutRepetition(0, 0);
            GenCombinationsBoysWithoutRepetition(0, 0);

            for (int i = 0; i < listsOfCombGirls.Count; i++)
            {
                for (int j = 0; j < listsOfCombBoys.Count; j++)
                {
                    Console.WriteLine($"{listsOfCombGirls[i]}, {listsOfCombBoys[j]}");
                }
            }
        }

        private static void GenCombinationsGirlsWithoutRepetition(int index, int elementsStartIndex)
        {
            //Base
            if(index >= combinationGirls.Length)
            {
                listsOfCombGirls.Add(string.Join(", ", combinationGirls));
                return;
            }

            for (int i = elementsStartIndex; i < allGirls.Length; i++)
            {
                combinationGirls[index] = allGirls[i];
                GenCombinationsGirlsWithoutRepetition(index + 1, i + 1);
            }
        }

        private static void GenCombinationsBoysWithoutRepetition(int index, int elementsStartIndex)
        {            
            //Base
            if (index >= combinationBoys.Length)
            {
                listsOfCombBoys.Add(string.Join(", ", combinationBoys));
                return;
            }

            for (int i = elementsStartIndex; i < allBoys.Length; i++)
            {
                combinationBoys[index] = allBoys[i];
                GenCombinationsBoysWithoutRepetition(index + 1, i + 1);
            }
        }
    }
}
//5.School Teams
//Write a program that receives the names of girls and boys in a class and generates all possible ways to create teams with 3 girls and 2 boys. Print each team on a separate line separated by comma and space ", " (first the girls then the boys). For more clarification see the examples below
//Note: "Linda, Amy, Katty, John, Bill" is the same as "Linda, Amy, Katty, Bill, John"; so print only the first case
//Input
//•	On the first line, you will receive the girls' names separated by comma and space ", "
//•	On the second line, you will receive the boys' names separated by comma and space ", "
//Output
//•	On separate lines print all the possible teams with exactly 3 girls and 2 boys separated by comma and space and starting with the girls
//Constrains
//•	There will always be at least 3 girls and 2 boys in the input
//Input
//Linda, Amy, Katty
//John, Bill
//Output
//Linda, Amy, Katty, John, Bill

//Input
//Lisa, Yoana, Marta, Rachel
//George, Garry, Bob

//Output
//Lisa, Yoana, Marta, George, Garry
//Lisa, Yoana, Marta, George, Bob
//Lisa, Yoana, Marta, Garry, Bob
//Lisa, Yoana, Rachel, George, Garry
//Lisa, Yoana, Rachel, George, Bob
//Lisa, Yoana, Rachel, Garry, Bob
//Lisa, Marta, Rachel, George, Garry
//Lisa, Marta, Rachel, George, Bob
//Lisa, Marta, Rachel, Garry, Bob
//Yoana, Marta, Rachel, George, Garry
//Yoana, Marta, Rachel, George, Bob
//Yoana, Marta, Rachel, Garry, Bob


