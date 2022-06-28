using System;
using System.Collections.Generic;
using System.IO;

namespace SigmaCamp_HomeTask9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(65001);
            try
            {
                //RestaurantService забагато на себе взяв. Не відповідає принципу Solid. 
                Menu myMenu = RestaurantService.GetMenuFromFile("Menu.txt");
                PriceList myPriceList = RestaurantService.GetPriceListFromFile("Prices.txt");
                RestaurantService.GetCurRatesFromFile("Course.txt");
                RestaurantService.GetFullProductsPrice(myMenu, myPriceList);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static bool TryAddPrice(string productName, out decimal price)
        {
            int attempts = 2;
            int counter = 1;
            Console.WriteLine($"You have {attempts} attempts to add price for {productName}");
            while (attempts > 0)
            {
                Console.Write($"\t Attempt {counter}: ");
                if (decimal.TryParse(Console.ReadLine(), out price))
                {
                    return true;
                }
                attempts--;
            }
            price = 0;
            return false;
        }
        public static (string, decimal) ChooseCurrency()
        {
            Console.Write("Choose currency for calculation EUR or USD. If none of them, price will be displayed in UAH: ");
            string currency = Console.ReadLine();
            if (PriceList.GetCurrencyRates().ContainsKey(currency))
            {
                return (currency, PriceList.GetCurrencyRates()[currency]);
            }
            return ("UAH", 1);
        }
    }
}
