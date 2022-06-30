using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask12_1.CustomInterfaces;
using SigmaCamp_HomeTask12_1.SearchServices;
namespace SigmaCamp_HomeTask12_1.Services
{
    static internal class LINQsearchService<T> where T : IPrinter, IPriceChanger, IStorageItem
    {
        public static List<T> GetItemsByNumericLINQ<K>(Storage<T> storage, string searchFilterName, K value, SearchNumberFilter comparer)
        {
            Console.WriteLine($"Times of executing GetItemsByNumericLINQ method to search items by {searchFilterName}: ");
            int counter = 0;
            double total = 0;
            double time = 0;
            List<T> properItems = new List<T>();
            while (counter < 10)
            {
                Stopwatch sw = Stopwatch.StartNew();
                switch (searchFilterName)
                {
                    case "weight" when value is double dvalue:
                        properItems = LINQcompareService<T>.CompareWeight(storage, dvalue, comparer);
                        break;
                    case "shelfLife" when value is int ivalue:
                        properItems = LINQcompareService<T>.CompareShelfLife(storage, ivalue, comparer);
                        break;
                    case "price" when value is decimal dvalue:
                        properItems = LINQcompareService<T>.ComparePrice(storage, dvalue, comparer);
                        break;
                    default:
                        throw new ArgumentException($"You can't search items by {searchFilterName}");
                }
                if (counter != 0)
                {
                    time = sw.Elapsed.TotalMilliseconds;
                    Console.WriteLine($"Execution time {counter}: {time} ms");
                    total += time;
                }
                counter++;
            }
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Average execution time: {total / 9}ms");
            Console.ForegroundColor = currentColor;
            return properItems;
        }
        public static List<T> GetItemsByNameLINQ(Storage<T> storage, string name)
        {
            Console.WriteLine($"Times of executing GetItemsByNameLINQ method to search items by name {name}: ");
            int counter = 0;
            double total = 0;
            double time = 0;
            List<T> properItems = new List<T>();
            while (counter < 10)
            {
                Stopwatch sw = Stopwatch.StartNew();
                properItems = storage.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
                if (counter != 0)
                {
                    time = sw.Elapsed.TotalMilliseconds;
                    Console.WriteLine($"Execution time {counter}: {time} ms");
                    total += time;
                }
                counter++;
            }
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Average execution time: {total / 9}ms");
            Console.ForegroundColor = currentColor;
            return properItems;
        }
    }
}
