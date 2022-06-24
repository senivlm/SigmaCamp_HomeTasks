using System;
using System.Collections.Generic;

namespace lesson14_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu myMenu = RestaurantService.GetMenuFromFile("Menu.txt");
            PriceList myPriceList = RestaurantService.GetPriceListFromFile("Prices.txt");
            RestaurantService.GetCurRatesFromFile("Course.txt");
        }
    }
}
