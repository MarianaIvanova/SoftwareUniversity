using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _4.Cinema
{
    class Program
    {
        //We use permutaions
        private static List<string> nonStaticFriends;
        private static string[] permutaions;//Seats
        private static bool[] used;
        static void Main(string[] args)
        {
            nonStaticFriends = Console.ReadLine().Split(", ").ToList();
            used = new bool[nonStaticFriends.Count];
            permutaions = new string[nonStaticFriends.Count];

            var input = Console.ReadLine();

            while(input != "generate")
            {
                var currentFriend = input.Split(" - ");
                var name = currentFriend[0];
                var seat = int.Parse(currentFriend[1]) - 1;

                permutaions[seat] = name;
                used[seat] = true;
                nonStaticFriends.Remove(name);//Премахваме приятелят, който има вече седалка

                input = Console.ReadLine();
            }

            Generate(0);//seat = index + 1;
        }

        private static void Generate(int index)
        {
            //Base:
            if(index >= permutaions.Length)
            {
                PrintPermutation();
                return;
            }

            Generate(index + 1);

            for (int i = index + 1; i < nonStaticFriends.Count; i++)//Use only nonStaticFriends
            {
                Swap(index, i);
                Generate(index + 1);
                Swap(index, i);
            }
        }
        private static void Swap(int first, int second)
        {
            var temp = nonStaticFriends[first];
            nonStaticFriends[first] = nonStaticFriends[second];
            nonStaticFriends[second] = temp;
        }

        private static void PrintPermutation()
        {
            int nonStaticInd = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < permutaions.Length; i++)
            {
                if(!used[i])
                {
                    permutaions[i] = nonStaticFriends[nonStaticInd++];
                }
            }

            Console.WriteLine(string.Join(" ", permutaions));
            //for (int i = 0; i < permutaions.Length; i++)
            //{
            //    if (used[i])
            //    {
            //        sb.Append($"{permutaions[i]} ");//тук са фиксираните седалки
            //    }
            //    else
            //    {
            //        sb.Append($"{nonStaticFriends[nonStaticInd++]} ");//тук са нефиксираните седалки
            //        //permutationInd++;
            //    }
            //}

            //Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
//Write a program that prints all of the possible distributions of a group of friends in a cinema hall. On the first line, you will be given all of the friends' names separated by comma and space.  Until you receive the command "generate" you will be given some of those friends' names and a number of the place that they want to have. (format: "{name} - {place}") So here comes the tricky part. Those friends want only to sit in the place that they have chosen. They cannot sit in other places. For more clarification see the examples below.
//Output
//Print all the possible ways to distribute the friends having in mind that some of them want a particular place and they will sit there only. The order of the output does not matter.
//Constrains
//•	The friends' names and the number of the place will always be valid
//Input
//Peter, Amy, George, Rick
//Amy - 1
//Rick - 4
//generate

//Output
//Amy Peter George Rick
//Amy George Peter Rick

//Comments
//Amy only wants to sit on the first seat and Rick wants to sit on the fourth, so we only switch the other friends
