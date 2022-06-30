using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask12_1
{
    static internal class StorageService
    {
        public static void InputProductManully(Storage<Product> storage)
        {
            decimal price;
            double weight;
            int shelfLife;
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter which type of product you want to add: m(Meat), d(Dairy), o(other)? ");
            Console.ForegroundColor = currentColor;
            char typeOfProduct = Console.ReadKey().KeyChar;
            switch (typeOfProduct)
            {
                case 'm':
                    Console.WriteLine("Input price, weight, category and kind of meat separated by comma");
                    string[] meatDescription = Console.ReadLine()?.Split(',');
                    if (meatDescription.Length == 4)
                    {
                        if (decimal.TryParse(meatDescription[0], out price) && double.TryParse(meatDescription[0], out weight))
                        {
                            storage.TryAddItem(new Meat(price, weight, meatDescription[2], meatDescription[3]));
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException("You entered data in incorrect format");
                    }
                    break;
                case 'o':
                    Console.WriteLine("Input name, price, and weight of product separated by comma");
                    string[] productDescription = Console.ReadLine()?.Split(',');
                    if (productDescription.Length == 3)
                    {
                        if (decimal.TryParse(productDescription[1], out price) && double.TryParse(productDescription[2], out weight))
                        {
                            storage.TryAddItem(new Product(productDescription[0], price, weight));
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException("You entered data in incorrect format");
                    }
                    break;
                case 'd':
                    Console.WriteLine("Input name, price, weight and shelf life of dairy product separated by comma");
                    string[] dairyProductDescription = Console.ReadLine()?.Split(',');
                    if (dairyProductDescription.Length == 4)
                    {
                        if (decimal.TryParse(dairyProductDescription[1], out price) && double.TryParse(dairyProductDescription[2], out weight) && int.TryParse(dairyProductDescription[3], out shelfLife))
                        {
                            storage.TryAddItem(new DairyProducts(dairyProductDescription[0], price, weight, shelfLife));
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException("You entered data in incorrect format");
                    }
                    break;
            }
        }
        public static Product ParseProduct(string line)
        {
            Product product;
            if (ProductParsing.TryParseProduct(line, out product))
            {
                return product;
            }
            else
            {
                throw new FormatException("Type of error: couldn't indetify format of product\n\tTime:" + DateTime.Now.ToString("r", CultureInfo.GetCultureInfo("en-US")));
            }
        }
    }
}
