using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> peopleOver30 = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] currentPersonInfo = Console.ReadLine().Split().ToArray();
                string currentName = currentPersonInfo[0];
                int currentAge = int.Parse(currentPersonInfo[1]);

                if(currentAge > 30)
                {
                    Person currentPerson = new Person(currentName, currentAge);
                    peopleOver30.Add(currentPerson);
                }
            }

            peopleOver30 = peopleOver30.OrderBy(x => x.Name).ToList();

            //Second type of code:
            //for (int i = 0; i < n; i++)
            //{
            //    string[] currentPersonInfo = Console.ReadLine().Split().ToArray();
            //    string currentName = currentPersonInfo[0];
            //    int currentAge = int.Parse(currentPersonInfo[1]);
            //    Person currentPerson = new Person(currentName, currentAge);
            //    peopleOver30.Add(currentPerson);
            //}
            //peopleOver30 = peopleOver30.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();

            //Third type of code is to use class Family from Y Ex 3 Oldest Family Member and to make in the class method
            //public Person[] GetPeople()
            //{
            //    return peopleOver30 = peopleOver30.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
            //}
 
            foreach (var person in peopleOver30)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
