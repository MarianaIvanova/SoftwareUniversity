﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_1_Count_Same_Values_in_Array_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> data = Console.ReadLine().Split(" ").Select(double.Parse).ToList();
            Dictionary<double, int> counting = new Dictionary<double, int>();

            for (int i = 0; i < data.Count; i++)
            {
                double currentNumber = data[i];
                if (!counting.ContainsKey(currentNumber))
                {
                    counting.Add(currentNumber, 0);
                }

                counting[currentNumber]++;
            }

            foreach (var item in counting)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}

