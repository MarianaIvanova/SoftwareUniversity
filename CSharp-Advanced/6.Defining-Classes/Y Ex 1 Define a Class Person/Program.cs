using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person newPerson = new Person("Pesho", 20);

            Console.WriteLine($"{newPerson.Name} {newPerson.Age}");

            Person newPerson2 = new Person("Gosho", 18);
            Console.WriteLine($"{newPerson2.Name} {newPerson2.Age}");

            Person newPerson3 = new Person();
            newPerson3.Name = "Stamat";
            newPerson3.Age = 43;
            Console.WriteLine($"{newPerson3.Name} {newPerson3.Age}");
        }
    }
}
