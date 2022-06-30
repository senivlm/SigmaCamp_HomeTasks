using System;
using SigmaCamp_HomeTask11.Services;
namespace SigmaCamp_HomeTask11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(65001);
            Storage<Product> myStorage = new Storage<Product>();
            FileOperations.ReadProductsFromFile("MyProducts1.txt", myStorage);
            Console.WriteLine(myStorage.PrintFullDescription());
            Console.WriteLine();    
            foreach (var item in myStorage.GetItems("DairyProducts"))
            {
                Console.WriteLine(item.GetDescription());
            }
        }
    }
}
