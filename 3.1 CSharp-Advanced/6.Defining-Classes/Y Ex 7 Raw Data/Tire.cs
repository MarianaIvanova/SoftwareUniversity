using System;
using System.Collections.Generic;
using System.Text;

namespace Y_Ex_7_Raw_Data
{
    public class Tire
    {
        public Tire()
        {

        }
        public Tire(double pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }
        public double Pressure { get; set; }
        public int Age { get; set; }
    }
}
