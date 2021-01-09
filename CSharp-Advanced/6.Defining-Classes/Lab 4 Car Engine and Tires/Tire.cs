using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        private int year;
        private double pressure;

        public Tire(int year, double pressure)
            //The class should also have a constructor, which accepts year and pressure upon initialization:
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        public int Year { get; set; }
        public double Pressure { get; set; }
    }
}
