using System;
using System.Collections.Generic;
using System.Text;

namespace Y_Ex_8_Car_Salesman
{
    public class Car
    {
        public Car()
        {
            Weight = 0;
            Color = null;
        }
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
    }
}
