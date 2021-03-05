using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();
            Car seconfCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
            //Console.WriteLine(firstCar.Make);
            //Console.WriteLine(firstCar.Model);
            //Console.WriteLine(firstCar.Year);
            //Console.WriteLine(firstCar.FuelQuantity);
            //Console.WriteLine(firstCar.FuelConsumption);
            //Console.WriteLine(seconfCar.Make);
            //Console.WriteLine(seconfCar.Model);
            //Console.WriteLine(seconfCar.Year);
            //Console.WriteLine(seconfCar.FuelQuantity);
            //Console.WriteLine(seconfCar.FuelConsumption);
            //Console.WriteLine(thirdCar.Make);
            //Console.WriteLine(thirdCar.Model);
            //Console.WriteLine(thirdCar.Year);
            //Console.WriteLine(thirdCar.FuelQuantity);
            //Console.WriteLine(thirdCar.FuelConsumption);
        }
    }
}
