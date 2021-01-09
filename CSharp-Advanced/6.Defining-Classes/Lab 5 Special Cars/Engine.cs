using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        public int horsePower;
        public double cubicCapacity;

        public Engine()
        //The class should also have a constructor, which accepts horsepower and cubicCapacity c initialization
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }

    }
}

