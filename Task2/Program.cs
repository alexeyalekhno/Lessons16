using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = string.Empty;
            using (StreamReader sr = new StreamReader("../../../Product.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product maxPrice = products[0];
            foreach (Product p in products)
            {
                if (p.ProductPrice > maxPrice.ProductPrice)
                {
                    maxPrice = p;
                }
            }
            Console.WriteLine($"{maxPrice.ProductCode} {maxPrice.ProductName} {maxPrice.ProductPrice}");
            Console.ReadKey();
               


        }
    }
}
