using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace lesson14_06
{
    internal static class RestaurantService
    {
        private static string filePath = string.Empty;
        public static Menu GetMenuFromFile(string fileName)
        {
            filePath = "../../../" + fileName;
            if(!File.Exists(filePath)) throw new FileNotFoundException($"File {fileName} hasn't been found");
            Menu menu = new Menu();
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Dish dish = new Dish(line);
                    string nextLine = sr.ReadLine();
                    while (nextLine != null && nextLine != "")
                    {
                        try
                        {
                            (string name, double weight) ingridient = Dish.ParseIngridient(nextLine);
                            dish.AddIngridient(ingridient.name, ingridient.weight);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        nextLine = sr.ReadLine();
                    }
                    menu.AddDish(dish);
                }
            }
            return menu;
        }
        public static PriceList GetPriceListFromFile(string fileName)
        {
            filePath = "../../../" + fileName;
            if (!File.Exists(filePath)) throw new FileNotFoundException($"File {fileName} hasn't been found");
            PriceList priceList = new PriceList();
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    try
                    {
                        (string name, decimal price) pricedProduct = PriceList.ParsePrice(line);
                        priceList.AddPricedProduct(pricedProduct.name, pricedProduct.price);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return priceList;
        }
        public static void GetCurRatesFromFile(string fileName)
        {
            filePath = "../../../" + fileName;
            if (!File.Exists(filePath)) throw new FileNotFoundException($"File {fileName} hasn't been found");
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    try
                    {
                        (string name, decimal price) currencyRate = PriceList.ParseCurrencyRate(line);
                        PriceList.AddCurrencyRate(currencyRate.name, currencyRate.price);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        public static void GetAllProductsAmount(Menu menu)
        {
            

        }
        public static void GetAllProductsPrice(Menu menu)
        {

        }
    }
}
