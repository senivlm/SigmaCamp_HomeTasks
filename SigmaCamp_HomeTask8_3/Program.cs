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
                Storage mySrorage1 = new Storage(100, "MyProducts1.txt");
                Storage mySrorage2 = new Storage(100, "MyProducts2.txt");
                foreach (Product item in mySrorage1.GetUniqueProducts(mySrorage2))
                {
                    Console.WriteLine(item.GetDescription());
                }
                
                //Product product1 = new Product("Картопля", 7.4m, 1);
                //Product product2 = new Product("Шампунь", 72m, 0.2);
                //Product product3 = new Product("Батон", 20.75m, 0.5);
                //Product product4 = new Meat(120m, 1, "Extra class 1", "veal");
                //Product product5 = new DairyProducts("Молоко", 30m, 0.9, 10);

                //Console.WriteLine(product4);

                //Buy myProducts = new Buy();
                //myProducts.AddProduct(product1);
                //myProducts.AddProduct(product2, 8);
                //myProducts.AddProduct(product4, 3);
                //myProducts.AddProduct(product5, 5);

                //Check myCheck = new Check();
                //myCheck.PrintCheck(myProducts);
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

