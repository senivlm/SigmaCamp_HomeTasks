using System;
using SigmaCamp_HomeTask12_1.Services;
using System.Linq;
using System.Collections;
using SigmaCamp_HomeTask12_1.CustomInterfaces;
using System.Diagnostics;
using System.Collections.Generic;

namespace SigmaCamp_HomeTask12_1
{
    internal class Storage<T>:IEnumerable<T> where T : IPrinter, IPriceChanger, IStorageItem
    {
        private List<T> _allItems;
        public event StorageHandler OverDated;
        #region Constructors
        public Storage()
        {
            _allItems = new List<T>(100);
        }
        public Storage(int size)
        {           
            _allItems = new List<T>(size);
        }
        public Storage(int size, params T[] products):this(size)
        {
            if (products == null)
            {
                throw new ArgumentNullException("You pass on no products");
            }
            if (products.Length > size)
            {
                throw new ArgumentOutOfRangeException("There is not space in storage for all products");
            }
            _allItems.AddRange(products);
        }
        #endregion
        private void OnOverDated(StorageEventArgs args)
        {
            OverDated?.Invoke(this, args);
        }
        public T this[int index]
        {
            get
            {
                if (index<0 || index > _allItems.Count)
                {
                    throw new ArgumentOutOfRangeException("You cant specify such index for storage");
                }
                return _allItems[index];
            }
        }
        public bool TryAddItem(T item)
        {
            if (item is DairyProducts dairyProduct)
            {
                if (dairyProduct.ShelfLife > 30)
                {
                    OnOverDated(new StorageEventArgs("You can't add product with shelf life more than 30 days", dairyProduct.GetDescription()));
                    return false;
                }
                else
                {
                    _allItems.Add(item);
                    return true;
                }
            }
            _allItems.Add(item);
            return true;
        }
        public List<T> SearchByName(string name)
        {
            CustomSearchService<T>.GetItemsByName(this, name);  
            return LINQsearchService<T>.GetItemsByNameLINQ(this, name);
        }
        public List<T> SearchByWeight(double weight, SearchNumberFilter filter = SearchNumberFilter.Equal)
        {
            CustomSearchService<T>.GetItemsByNumeric<double>(this, "weight", weight, filter);
            return LINQsearchService<T>.GetItemsByNumericLINQ<double>(this, "weight", weight, filter);
        }
        public List<T> SearchByPrice(decimal price, SearchNumberFilter filter = SearchNumberFilter.Equal)
        {
            CustomSearchService<T>.GetItemsByNumeric<decimal>(this, "price", price, filter);
            return LINQsearchService<T>.GetItemsByNumericLINQ<decimal>(this, "price", price, filter);
        }
        public List<T> SearchByShelfLife(int shelfLife, SearchNumberFilter filter = SearchNumberFilter.Equal)
        {
            CustomSearchService<T>.GetItemsByNumeric<int>(this, "shelfLife", shelfLife, filter);
            return LINQsearchService<T>.GetItemsByNumericLINQ<int>(this, "shelfLife", shelfLife, filter);
        }
        public void ChangeAllProductsPrice(int percentToChange)
        {
            foreach (T product in _allItems)
            {
                product.ChangePrice(percentToChange);
            }
        }
        public List<T> GetItems(string className = "")
        {
            if (className == "")
            {
                className = typeof(T).Name;
            }
            return _allItems.Where(item => item.GetType().Name == className).ToList();
        }
        public string PrintFullDescription()
        {
            string result = string.Empty;
            foreach (T item in _allItems)
            {
                result+=item.GetDescription() + "\n";
            }
            return result;
        }
        public int GetCapacity()
        {
            return _allItems.Capacity;
        }
        public int GetCount()
        {
            return _allItems.Count;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _allItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
