using System;
using System.Collections.Generic;
using System.Text;

namespace Y_Ex_7_Raw_Data
{
    public class Cargo
    {
        public Cargo(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }
        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
