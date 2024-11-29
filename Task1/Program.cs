using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Unicode;
using System.IO;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Product[] product = new Product[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара:");
                int productCode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара:");
                string productName = Console.ReadLine();
                Console.WriteLine("Введите стоимость товара:");
                double productPrice = Convert.ToDouble(Console.ReadLine());
                product[i] = new Product() { ProductCode = productCode, ProductName = productName, ProductPrice = productPrice };
            }

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(product, options);

            using (StreamWriter sw = new StreamWriter("../../../Product.json"))
            { 
            sw.WriteLine(jsonString);
            }



        }
    }
}
