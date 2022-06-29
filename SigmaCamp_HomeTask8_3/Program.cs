using System;
using System.IO;
namespace SigmaCamp_HomeTask8_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Storage myStorage1 = new Storage(100, "MyProducts1.txt");
                Storage myStorage2 = new Storage(100, "MyProducts2.txt");
                Console.WriteLine("All products in myStorage1:");
                myStorage1.PrintFullDescription();

                Console.WriteLine("\nAll products in myStorage2:");
                myStorage2.PrintFullDescription();
                Console.WriteLine();

                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unique products in myStorage1:");
                Console.ForegroundColor = currentColor;
                foreach (Product item in myStorage1.GetUniqueProducts(myStorage2))
                {
                    Console.WriteLine("\t" + item.GetDescription());
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Common products in myStorage1 and myStorage2:");
                Console.ForegroundColor = currentColor;
                foreach (Product item in myStorage1.GetCommonProducts(myStorage2))
                {
                    Console.WriteLine("\t" + item.GetDescription());
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unique common products in myStorage1 and myStorage2:");
                Console.ForegroundColor = currentColor;
                foreach (Product item in myStorage1.GetCommonUniqueProducts(myStorage2))
                {
                    Console.WriteLine("\t" + item.GetDescription());
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

