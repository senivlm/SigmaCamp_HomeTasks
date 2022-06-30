using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask12_1.CustomInterfaces;
namespace SigmaCamp_HomeTask12_1.Services
{
    static internal class CustomCompareService<T> where T : IPrinter, IPriceChanger, IStorageItem
    {
        public static bool CompareWeight(T item, double value, SearchNumberFilter comparer)
        {
            switch (comparer)
            {
                case SearchNumberFilter.Equal:
                    return item.Weight == value;
                case SearchNumberFilter.Less:
                    return item.Weight <= value;
                case SearchNumberFilter.More:
                    return item.Weight >= value;
                default:
                    return false;
            }
        }
        public static bool ComparePrice(T item, decimal value, SearchNumberFilter comparer)
        {
            switch (comparer)
            {
                case SearchNumberFilter.Equal:
                    return item.Price == value;
                case SearchNumberFilter.Less:
                    return item.Price <= value;
                case SearchNumberFilter.More:
                    return item.Price >= value;
                default:
                    return false;
            }
        }
        public static bool CompareShelfLife(T item, int value, SearchNumberFilter comparer)
        {
            switch (comparer)
            {
                case SearchNumberFilter.Equal when item is DairyProducts:
                    return (item as DairyProducts).ShelfLife == value;
                case SearchNumberFilter.Less when item is DairyProducts:
                    return (item as DairyProducts).ShelfLife <= value;
                case SearchNumberFilter.More when item is DairyProducts:
                    return (item as DairyProducts).ShelfLife >= value;
                default:
                    return false;
            }
        }
    }
}
