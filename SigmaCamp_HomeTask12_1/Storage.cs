using System;
using SigmaCamp_HomeTask12_1.Services;
using System.Linq;
using System.Collections;
using SigmaCamp_HomeTask12_1.CustomInterfaces;
using System.Collections.Generic;

namespace SigmaCamp_HomeTask12_1
{
    internal class Storage<T>:IEnumerable<T> where T : IPrinter, IPriceChanger
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
