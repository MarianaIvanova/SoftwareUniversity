using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string inputTires = Console.ReadLine();
            List<Tire[]> tiresData = GetTiresData(inputTires);//OK here! 

            string inputEngine = Console.ReadLine();
            List<Engine> engineData = GetEngineData(inputEngine);//OK here!

            string inputCar = Console.ReadLine();
            List<Car> carData = GetCarData(inputCar, engineData, tiresData);
            foreach (var car in carData)
            {
                if (car.Year >= 2017 && car.Engine.HorsePower > 330)
                {
                    double sumTirePresure = 0;
                    for (int i = 0; i < car.Tires.Length; i++)
                    {
                        sumTirePresure += car.Tires[i].Pressure;
                    }

                    if (sumTirePresure >= 9 && sumTirePresure <= 10)
                    {
                        if (car.FuelQuantity >= car.FuelConsumption / 100 * 20)
                        {
                            car.FuelQuantity -= car.FuelConsumption / 100 * 20;
                            Console.WriteLine($"Make: {car.Make}");
                            Console.WriteLine($"Model: {car.Model}");
                            Console.WriteLine($"Year: {car.Year}");
                            Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                            Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                        }
                    }
                }
            }

        }

        static List<Tire[]> GetTiresData(string inputTires)
        {
            List<Tire[]> tiresData = new List<Tire[]>();

            while (inputTires != "No more tires")
            {
                string[] inputEngineSplit = inputTires.Split(" ").ToArray();

                Tire[] currentTires = new Tire[4];
                int count = 0;
                for (int i = 0; i < inputEngineSplit.Length - 1; i += 2)
                {
                    currentTires[count] = new Tire(int.Parse(inputEngineSplit[i]), double.Parse(inputEngineSplit[i + 1]));
                    //currentTires[count].Year = int.Parse(inputEngineSplit[i]);
                    //currentTires[count].Pressure = double.Parse(inputEngineSplit[i + 1]);
                    count++;
                }

                tiresData.Add(currentTires);
                inputTires = Console.ReadLine();
            }

            return tiresData;
        }

        static List<Engine> GetEngineData(string inputEngine)
        {
            List<Engine> engineData = new List<Engine>();

            while (inputEngine != "Engines done")
            {
                string[] inputEngineSplit = inputEngine.Split(" ").ToArray();
                Engine currentEngine = new Engine(int.Parse(inputEngineSplit[0]), double.Parse(inputEngineSplit[1]));
                //currentEngine.HorsePower = int.Parse(inputEngineSplit[0]);
                //currentEngine.CubicCapacity = double.Parse(inputEngineSplit[1]);
                engineData.Add(currentEngine);

                inputEngine = Console.ReadLine();
            }

            return engineData;
        }

        static List<Car> GetCarData(string inputCar, List<Engine> engineData, List<Tire[]> tiresData)
        {
            List<Car> carData = new List<Car>();

            while (inputCar != "Show special")
            {
                string[] inputCarSplit = inputCar.Split(" ").ToArray();
                Car currentCar = new Car();
                currentCar.Make = inputCarSplit[0];
                currentCar.Model = inputCarSplit[1];
                currentCar.Year = int.Parse(inputCarSplit[2]);
                currentCar.FuelQuantity = double.Parse(inputCarSplit[3]);
                currentCar.FuelConsumption = double.Parse(inputCarSplit[4]);

                int engineIndex = int.Parse(inputCarSplit[5]);
                currentCar.Engine = new Engine(engineData[engineIndex].HorsePower, engineData[engineIndex].CubicCapacity);
                //currentCar.Engine.HorsePower = engineData[engineIndex].HorsePower;
                //currentCar.Engine.CubicCapacity = engineData[engineIndex].CubicCapacity;

                currentCar.Tires = new Tire[4];
                int tiresIndex = int.Parse(inputCarSplit[6]);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = i; j < i + 1; j++)
                    {
                        currentCar.Tires[i] = new Tire(tiresData[tiresIndex][j].Year, tiresData[tiresIndex][j].Pressure);
                        //currentCar.Tires[i].Year = tiresData[tiresIndex][j].Year;
                        //currentCar.Tires[i].Pressure = tiresData[tiresIndex][j].Pressure;

                    }
                }

                carData.Add(currentCar);
                inputCar = Console.ReadLine();
            }

            return carData;
        }
    }
}
