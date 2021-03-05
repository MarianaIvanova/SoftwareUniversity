using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_5_Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> allPeople = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] currentPersonInfo = Console.ReadLine().Split(", ").ToArray();
                Person currentPerson = new Person(currentPersonInfo[0], int.Parse(currentPersonInfo[1]));
                allPeople.Add(currentPerson);
            }

            string condition = Console.ReadLine();
            int ageToFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> conditionDelegate = GetCondition(condition, ageToFilter);
            Action<Person> printDelegate = GetPrint(format);
            FilterPeople(allPeople, conditionDelegate, printDelegate);

            //Add info from the lector:
            Console.WriteLine("------------------------------");
            FilterPeople(allPeople, x => x.Name.Length <= 3, printDelegate);
            Console.WriteLine("------------------------------");
            FilterPeople(allPeople, x => true, x => Console.WriteLine($"{x.Name}!!!"));
            Console.WriteLine("------------------------------");
            FilterPeople(allPeople, PrintOldPeople, printDelegate);
        }

        //Add info from the lector is PrintOldPeople:
        static bool PrintOldPeople(Person person)
        {
            return person.Age > 30;
        }
        static void FilterPeople(List<Person> allPeople, Func<Person, bool> conditionDelegate, Action<Person> printDelegate)
        {
            foreach (var person in allPeople)
            {
                if (conditionDelegate(person))
                {
                    printDelegate(person);
                }
            }
        }
        static Action<Person> GetPrint(string format)
        {
            switch(format)
            {
                case "name":
                    return x => Console.WriteLine($"{x.Name}");
                case "age":
                    return x => Console.WriteLine($"{x.Age}");
                case "name age":
                    return x => Console.WriteLine($"{x.Name} - {x.Age}");
                default:
                    return null;
            }
        }
        static Func<Person, bool> GetCondition(string condition, int age)
        {
            switch(condition)
            {
                case "younger":
                    return x => x.Age < age;
                case "older":
                    return x => x.Age >= age;
                default:
                    return null;
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
    }
}
