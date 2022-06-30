using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask12_1.CustomInterfaces;

namespace SigmaCamp_HomeTask12_1.Services
{
    static internal class CustomSearchService<T> where T : IPrinter, IPriceChanger, IStorageItem
    {
        public static List<T> GetItemsByNumeric<K>(Storage<T> storage, string searchFilterName, K value, SearchNumberFilter comparer)
        {
            Console.WriteLine($"Times of executing GetItemsByNumeric method to search items by {searchFilterName}: ");
            int counter = 0;
            double total = 0;
            double time = 0;
            List<T> properItems = new List<T>();
            while (counter < 10)
            {
                Stopwatch sw = Stopwatch.StartNew();
                properItems = new List<T>();
                bool toAdd = false;
                for (int i = 0 ; i < storage.GetCount(); i++)
                {
                    switch (searchFilterName)
                    {
                        case "weight" when value is double dvalue:
                            toAdd = CustomCompareService<T>.CompareWeight(storage[i], dvalue, comparer);
                            break;
                        case "shelfLife" when value is int ivalue:
                            toAdd = CustomCompareService<T>.CompareShelfLife(storage[i], ivalue, comparer);   
                            break;
                        case "price" when value is decimal dvalue:
                            toAdd = CustomCompareService<T>.ComparePrice(storage[i], dvalue, comparer);
                            break;
                        default:
                            throw new ArgumentException($"You can't search items by {searchFilterName}");
                    }
                    if (toAdd)
                    {
                        properItems.Add(storage[i]);
                    }
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
        public static List<T> GetItemsByName(Storage<T> storage, string name)
        {
            Console.WriteLine($"Times of executing GetItemsByNameUsual method to search items by name {name}: ");
            int counter = 0;
            double total = 0;
            double time = 0;
            List<T> properItems = new List<T>();
            while (counter < 10)
            {
                Stopwatch sw = Stopwatch.StartNew();
                properItems = new List<T>();
                for (int i = 0, j = storage.GetCount() - 1; i < j; i++, j--)
                {
                    if (storage[i].Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    {
                        properItems.Add(storage[i]);
                    }
                    if (storage[j].Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                    {
                        properItems.Add(storage[j]);
                    }
                }
                if (counter!=0)
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
