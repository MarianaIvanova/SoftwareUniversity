using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car newCar = new Car();
            newCar.Make = "hop";
            newCar.Model = "X3";
            newCar.Year = 55;
            Console.WriteLine($"{newCar.Make} - {newCar.Model} - {newCar.Year}");
        }
    }
}
