using System;
using SigmaCamp_HomeTask12_1.Services;
namespace SigmaCamp_HomeTask12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage<Product> myStorage = new ();
            myStorage.OverDated += Handlers.AddItemHandler;
            FileOperations.ReadProductsFromFile("MyProducts1.txt", myStorage);
            Console.WriteLine(myStorage.PrintFullDescription());
        }
    }
}
