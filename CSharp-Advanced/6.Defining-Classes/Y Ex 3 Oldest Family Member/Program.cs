using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family newFamily = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] inputSplit = Console.ReadLine().Split().ToArray();
                string currentName = inputSplit[0];
                int currentAge = int.Parse(inputSplit[1]);
                Person currentPerson = new Person(currentName, currentAge);

                newFamily.AddMember(currentPerson);
            }

            Person oldestPerson = newFamily.GetOldestMember();

            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
