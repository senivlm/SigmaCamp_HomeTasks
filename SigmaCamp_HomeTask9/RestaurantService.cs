using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SigmaCamp_HomeTask9
{
    internal static class RestaurantService
    {
        private static string filePath = string.Empty;
        public static Menu GetMenuFromFile(string fileName)
        {
            filePath = "../../../" + fileName;
            if(!File.Exists(filePath)) throw new FileNotFoundException($"File {fileName} hasn't been found");
            FilePaths.menuPath = filePath;
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
            FilePaths.priceListPath = filePath;
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
            FilePaths.currencyRatePath = filePath;
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
        private static Dictionary<string, double> GetProductsAmount(Menu menu)
        {
            IEnumerable<KeyValuePair<string, double>> allProducts = new Dictionary<string, double>();
            
            foreach (Dish dish in menu)
            {
                allProducts = allProducts.Concat(dish.GetIngridients());
            }
            var allProductsAmount = allProducts.GroupBy(ing => ing.Key).Select(groupedIng => new { Name = groupedIng.Key, TotalAmount = groupedIng.Sum(wp => wp.Value) }).ToList();
            Dictionary<string, double> allProductsAmountInDic = new();
            foreach (var product in allProductsAmount)
            {
                allProductsAmountInDic.Add(product.Name, product.TotalAmount);
            }
            return allProductsAmountInDic;
        }
        public static void GetFullProductsPrice(Menu menu, PriceList priceList)
        {
            string resultFilePath = "../../../Result.txt";
            using (StreamWriter sw = new StreamWriter(resultFilePath))
            {
                decimal menuSum = default;
                (string Name, decimal Value) currentCurrency = Program.ChooseCurrency();
                sw.WriteLine("Needs of every product:");
                foreach (var product in GetProductsAmount(menu))
                {
                    try
                    {
                        sw.WriteLine($"\t{product.Key} - {product.Value}g");
                        menuSum += ((decimal)product.Value/1000) * priceList.GetProductPrice(product.Key) * currentCurrency.Value;
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine(ex.Message);  
                        decimal productPrice = default;
                        if (Program.TryAddPrice(product.Key, out productPrice))
                        {
                            priceList.AddPricedProduct(product.Key, productPrice, true);
                            menuSum += ((decimal)product.Value/1000) * priceList.GetProductPrice(product.Key) * currentCurrency.Value;
                        }
                        else throw new ArgumentNullException("All your attempts failed. Program is over");
                    }
                }
                sw.WriteLine($"Total sum needed for all products is {menuSum} {currentCurrency.Name}");
            }
        }
    }
}
