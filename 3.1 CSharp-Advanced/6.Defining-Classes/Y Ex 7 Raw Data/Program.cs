using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_7_Raw_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> allCars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfoSplit = Console.ReadLine().Split(" ").ToArray();
                string model = carInfoSplit[0];
                int engineSpeed = int.Parse(carInfoSplit[1]);
                int enginePower = int.Parse(carInfoSplit[2]);
                string cargoType = carInfoSplit[4];
                int cargoWeight = int.Parse(carInfoSplit[3]);
                //double tire1Pressure = double.Parse(carInfoSplit[5]);
                //int tire1Age = int.Parse(carInfoSplit[6]);
                //double tire2Pressure = double.Parse(carInfoSplit[7]);
                //int tire2Age = int.Parse(carInfoSplit[8]);
                //double tire3Pressure = double.Parse(carInfoSplit[9]);
                //int tire3Age = int.Parse(carInfoSplit[10]);
                //double tire4Pressure = double.Parse(carInfoSplit[11]);
                //int tire4Age = int.Parse(carInfoSplit[12]);

                Engine currentCarEngine = new Engine(engineSpeed, enginePower);
                Cargo currentCarCargo = new Cargo(cargoType, cargoWeight);
                Tire[] currentCarTires = new Tire[4];
                //currentCarTires[0].Age = tire1Age;
                //currentCarTires[1].Age = tire2Age;
                //currentCarTires[2].Age = tire3Age;
                //currentCarTires[3].Age = tire4Age;
                //currentCarTires[0].Pressure = tire1Pressure;
                //currentCarTires[1].Pressure = tire2Pressure;
                //currentCarTires[2].Pressure = tire3Pressure;
                //currentCarTires[3].Pressure = tire4Pressure;
                for (int j = 0; j < 4; j++)
                {
                    currentCarTires[j] = new Tire();
                    currentCarTires[j].Pressure = double.Parse(carInfoSplit[j * 2 + 5]);
                    currentCarTires[j].Age = int.Parse(carInfoSplit[j * 2 + 6]);
                }

                //Или цикълът по-горе, може да се напише по стандартния начин:
                //int counter = 0;
                //for (int j = 5; j < carInfoSplit.Length; j+=2)
                //{
                //    double tirePressure = double.Parse(carInfoSplit[j]);
                //    int tireAge = int.Parse(carInfoSplit[j + 1]);
                //    currentCarTires[counter] = new Tire(tirePressure, tireAge);
                //    counter++;
                //}

                Car currentCar = new Car(model, currentCarEngine, currentCarCargo, currentCarTires);
                allCars.Add(currentCar);
            }

            string command = Console.ReadLine();
            if(command == "fragile")
            {
                List<Car> allCarsFragileAndPressurLess1forACar = allCars.
                    Where(x => x.Tires.Any(x => x.Pressure < 1)).ToList();

                if(allCarsFragileAndPressurLess1forACar.Count > 0)
                {
                    foreach (var car in allCarsFragileAndPressurLess1forACar)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
                //Или по по-грозния начин:
                //List<Car> allCarsFragile = allCars.Where(x => x.Cargo.Type == "fragile").ToList();
                //foreach (var car in allCarsFragile)
                //{
                //    bool isUnder1 = false;
                //    for (int i = 0; i < 4; i++)
                //    {
                //        if(car.Tires[i].Pressure < 1)
                //        {
                //            isUnder1 = true;
                //        }
                //    }

                //    if(isUnder1)
                //    {
                //        Console.WriteLine(car.Model);
                //    }
                //}
            }
            else if (command == "flamable")
            {
                List<Car> allCarsFlamable = allCars.Where(x => x.Cargo.Type == "flamable").ToList();
                foreach (var car in allCarsFlamable)
                {
                    if(car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }

                //List<Car> allCarsFlamable = allCars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList();
                //foreach (var car in allCarsFlamable)
                //{
                //    Console.WriteLine(car.Model);
                //}
            }
        }
    }
}
