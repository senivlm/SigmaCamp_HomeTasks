using System;
using SigmaCamp_HomeTask12_1.Services;
namespace SigmaCamp_HomeTask12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(65001);
            Storage<Product> myStorage = new();
            myStorage.OverDated += Handlers.AddItemHandler;
            FileOperations.ReadProductsFromFile("MyProducts1.txt", myStorage);
            //var foundItems = myStorage.SearchByName("Напій");
            var foundItems = myStorage.SearchByPrice(180, SearchNumberFilter.Equal);
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nFound items:");
            Console.ForegroundColor = currentColor;
            foreach (var item in foundItems)
            {
                Console.WriteLine("\t" + item.GetDescription());
            }
        }
    }
}
