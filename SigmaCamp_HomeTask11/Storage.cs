using System;
using SigmaCamp_HomeTask11.Services;
using System.Linq;
using System.Collections;
using SigmaCamp_HomeTask11.CustomInterfaces;
using System.Collections.Generic;

namespace SigmaCamp_HomeTask11
{
    internal class Storage<T>:IEnumerable<T> where T : IPrinter, IPriceChanger, IStorageItem
    {
        private List<T> _allItems;

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
        public Storage(string fileName, int size = 100) :this(size)
        {
            FileOperations.ReadProductsFromFile(fileName, this);
        }
        #endregion
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
        public void AddItem(T item)
        {
            _allItems.Add(item);
        }

        public void ChangeAllProductsPrice(int percentToChange)
        {
            foreach (T product in _allItems)
            {
                product.ChangePrice(percentToChange);
            }
        }
        public List<Meat> GetMeatProducts()
        {
            List<Meat> meatProducts = new List<Meat>();
            foreach (T product in _allItems)
            {
                if (product is Meat meatProduct)
                {
                    meatProducts.Add(meatProduct);
                }
            }
            return meatProducts;
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
