using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> allCars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] currentCarInfo = Console.ReadLine().Split(" ").ToArray();
                string model = currentCarInfo[0];
                double fuelAmount = double.Parse(currentCarInfo[1]);
                double fuelConsumptionFor1km = double.Parse(currentCarInfo[2]);
                double travelledDistance = 0;
                Car currentCar = new Car(model, fuelAmount, fuelConsumptionFor1km, travelledDistance);
                allCars.Add(currentCar);
            }

            string command = Console.ReadLine();

            while(command != "End")
            {
                string[] commandInfo = command.Split(" ").ToArray();
                string carModel = commandInfo[1];
                double amountOfKm = double.Parse(commandInfo[2]);

                bool isInTheList = false;
                int carIndex = 0;
                for (int i = 0; i < allCars.Count; i++)
                {
                    if (allCars[i].Model == carModel)
                    {
                        isInTheList = true;
                        carIndex = i;
                    }
                }

                if(isInTheList)
                {
                    allCars[carIndex].CheckCarMovingDistance(amountOfKm);
                }

                command = Console.ReadLine();
            }

            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
