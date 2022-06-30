using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask12_1.CustomInterfaces;
namespace SigmaCamp_HomeTask12_1.SearchServices
{
    internal class LINQcompareService<T> where T : IPrinter, IPriceChanger, IStorageItem
    {
        public static List<T> CompareWeight(Storage<T> storage, double value, SearchNumberFilter comparer)
        {
            switch (comparer)
            {
                case SearchNumberFilter.Equal:
                    return storage.Where(item => item.Weight == value).ToList();
                case SearchNumberFilter.Less:
                    return storage.Where(item => item.Weight <= value).ToList();
                case SearchNumberFilter.More:
                    return storage.Where(item => item.Weight >= value).ToList();
                default:
                    return null;
            }
        }
        public static List<T> ComparePrice(Storage<T> storage, decimal value, SearchNumberFilter comparer)
        {
            switch (comparer)
            {
                case SearchNumberFilter.Equal:
                    return storage.Where(item => item.Price == value).ToList();
                case SearchNumberFilter.Less:
                    return storage.Where(item => item.Price <= value).ToList();
                case SearchNumberFilter.More:
                    return storage.Where(item => item.Price >= value).ToList();
                default:
                    return null;
            }
        }
        public static List<T> CompareShelfLife(Storage<T> storage, int value, SearchNumberFilter comparer)
        {
            switch (comparer)
            {
                case SearchNumberFilter.Equal:
                    return storage.Where(item => item is DairyProducts).Where(item => (item as DairyProducts).ShelfLife == value).ToList();
                case SearchNumberFilter.Less:
                    return storage.Where(item => item is DairyProducts).Where(item => (item as DairyProducts).ShelfLife <= value).ToList();
                case SearchNumberFilter.More:
                    return storage.Where(item => item is DairyProducts).Where(item => (item as DairyProducts).ShelfLife >= value).ToList();
                default:
                    return null;
            }
        }
    }
}
