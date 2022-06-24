using System;
using System.Collections.Generic;

namespace SigmaCamp_HomeTask9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(65001);
            Menu myMenu = RestaurantService.GetMenuFromFile("Menu.txt");
            PriceList myPriceList = RestaurantService.GetPriceListFromFile("Prices.txt");
            RestaurantService.GetCurRatesFromFile("Course.txt");
            RestaurantService.GetFullProductsPrice(myMenu, myPriceList);
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
