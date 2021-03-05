using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y_Ex_8_Car_Salesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> allEngines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] currentEngineInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string currentEngineModel = currentEngineInfo[0];
                int currentEnginePower = int.Parse(currentEngineInfo[1]);
                Engine currentEngine = new Engine();

                if (currentEngineInfo.Length == 2)
                {
                    currentEngine.Model = currentEngineModel;
                    currentEngine.Power = currentEnginePower;
                }
                else if (currentEngineInfo.Length == 3)
                {
                    currentEngine.Model = currentEngineModel;
                    currentEngine.Power = currentEnginePower;

                    string currentInfo = currentEngineInfo[2];
                    char numberOrSymbol = Char.Parse(currentInfo[0].ToString());
                    if(char.IsDigit(numberOrSymbol))
                    {
                        currentEngine.Displacement = int.Parse(currentInfo);
                    }
                    else if (char.IsLetter(numberOrSymbol))
                    {
                        currentEngine.Efficiency = currentInfo;
                    }

                }
                else if (currentEngineInfo.Length == 4)
                {
                    currentEngine.Model = currentEngineModel;
                    currentEngine.Power = currentEnginePower;
                    currentEngine.Displacement = int.Parse(currentEngineInfo[2]);
                    currentEngine.Efficiency = currentEngineInfo[3];
                }

                allEngines.Add(currentEngine);
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> allCars = new List<Car>();

            for (int j = 0; j < m; j++)
            {
                string[] currentCarInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string currentCarModel = currentCarInfo[0];
                string currentCarEnginModel = currentCarInfo[1];
                Car currentCar = new Car();

                if (currentCarInfo.Length == 2)
                {
                    currentCar.Model = currentCarModel;
                    Engine engineDataFind = allEngines.First(x => x.Model == currentCarEnginModel);
                    currentCar.Engine = engineDataFind;
                }
                else if (currentCarInfo.Length == 3)
                {
                    currentCar.Model = currentCarModel;
                    Engine engineDataFind = allEngines.First(x => x.Model == currentCarEnginModel);
                    currentCar.Engine = engineDataFind;

                    string currentInfo = currentCarInfo[2];
                    char numberOrSymbol = Char.Parse(currentInfo[0].ToString());
                    if (char.IsDigit(numberOrSymbol))
                    {
                        currentCar.Weight = int.Parse(currentInfo);
                    }
                    else if (char.IsLetter(numberOrSymbol))
                    {
                        currentCar.Color = currentInfo;
                    }
                }
                else if (currentCarInfo.Length == 4)
                {
                    currentCar.Model = currentCarModel;
                    Engine engineDataFind = allEngines.First(x => x.Model == currentCarEnginModel);
                    currentCar.Engine = engineDataFind;
                    currentCar.Weight = int.Parse(currentCarInfo[2]);
                    currentCar.Color = currentCarInfo[3];
                }

                allCars.Add(currentCar);
            }

            foreach (var car in allCars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                if(car.Engine.Displacement == 0)
                {
                    Console.WriteLine($"    Displacement: n/a");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }

                if (car.Engine.Efficiency == null)
                {
                    Console.WriteLine($"    Efficiency: n/a");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }

                if (car.Weight == 0)
                {
                    Console.WriteLine($"  Weight: n/a");
                }
                else
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }

                if (car.Color == null)
                {
                    Console.WriteLine($"  Color: n/a");
                }
                else
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }

            }
        }
    }
}
