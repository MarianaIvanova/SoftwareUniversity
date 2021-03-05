using System;
using System.Collections.Generic;
using System.Text;

namespace Y_Ex_8_Car_Salesman
{
    public class Engine
    {
        public Engine()
        {
            Displacement = 0;
            Efficiency = null;
        }
        public Engine(string model, int power): this()
        {
            Model = model;
            Power = power;
        }
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
