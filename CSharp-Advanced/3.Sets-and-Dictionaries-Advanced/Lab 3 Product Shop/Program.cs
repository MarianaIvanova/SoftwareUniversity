using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_3_Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> allShopsProducts = 
                new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] infoProducts = input.Split(", ").ToArray();
                string shop = infoProducts[0];
                string product = infoProducts[1];
                double price = double.Parse(infoProducts[2]);

                if(!allShopsProducts.ContainsKey(shop))
                {
                    allShopsProducts.Add(shop, new Dictionary<string, double>());
                }
                if(!allShopsProducts[shop].ContainsKey(product))
                {
                    allShopsProducts[shop].Add(product, price);
                }
                else

                input = Console.ReadLine();
            }

            //1 Sorting by the key int the first dictionary
            allShopsProducts = allShopsProducts.OrderBy(x => x.Key).ToDictionary(s => s.Key, s => s.Value);

            //2 Sorting by the key int the second dictionary
            //var keys = allShopsProducts.Select(x => x.Key).ToList();

            //for (int i = 0; i < keys.Count; i++)
            //{
            //    allShopsProducts[keys[i]] =
            //        allShopsProducts[keys[i]].OrderBy(x => x.Key).ToDictionary(s => s.Key, s => s.Value);
            //}

            foreach (var shop in allShopsProducts)
            {
                Console.WriteLine($"{shop.Key}->");

                var productPrice= shop.Value;
                foreach (var product in productPrice)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
