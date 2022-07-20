using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask14.ProductInterfaces;

namespace SigmaCamp_HomeTask14.Services
{
    static internal class FileOperations
    {
        private static string productsFilePath = string.Empty;
        public static bool CheckFileExistence(string filePath)
        {
            if (!File.Exists(filePath))
            {
                int i = 1;
                Console.WriteLine($"File {filePath} doesn't exist.");
                Console.WriteLine("You have 2 attempts to input correct file name");
                while (i < 3)
                {
                    Console.Write($"Attempt {i}: ");
                    filePath = "../../../" + Console.ReadLine();
                    if (File.Exists(filePath))
                    {
                        return true;
                    }
                    Console.WriteLine($"Attempt {i} failed");
                    i++;
                }
                return false;
            }
            return true;
        }
        static public void AddToUtilized(string line)
        {
            using (StreamWriter writer = new StreamWriter("../../../UtilizedProducts.txt"))
            {
                writer.WriteLine(line);
            }
        }
        static public void RemoveUtilizedLines(List<string> lines)
        {
            string[] currentProducts;
            using (StreamReader reader = new(productsFilePath))
            {
                string allText = reader.ReadToEnd();
                currentProducts = allText.Split("\r");
            }
            using (StreamWriter writer = new StreamWriter(productsFilePath))
            {
                foreach (string product in currentProducts)
                {
                    if (!lines.Contains(product))
                    {
                        writer.WriteLine(product);
                    }
                }
            }
        }
    }
}
