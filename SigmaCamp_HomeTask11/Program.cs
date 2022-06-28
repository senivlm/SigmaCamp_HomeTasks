using System;

namespace SigmaCamp_HomeTask11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage<Product> myStorage = new ("MyProducts1.txt");
            Console.WriteLine(myStorage.PrintFullDescription());
        }
    }
}
