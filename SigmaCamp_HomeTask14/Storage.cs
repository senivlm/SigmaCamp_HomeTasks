using System;
using SigmaCamp_HomeTask14.Services;
using System.Linq;
using System.Collections;
using SigmaCamp_HomeTask14.ProductInterfaces;
using System.Diagnostics;
using System.Collections.Generic;

namespace SigmaCamp_HomeTask14
{
    internal class Storage<T>:IEnumerable<T> where T : IProduct
    {
        private List<T> _allItems;
        public event StorageHandler OverDated;
        static Storage<T> _instance;
        public static Storage<T> Instance
        {
            get
            {
                if (_instance == null) throw new ArgumentNullException("Storage instance hasn`t been created yet");
                return _instance;
            }
        }
        #region Constructors
        private Storage()
        {
            _allItems = new List<T>(100);
        }
        private Storage(int size)
        {           
            _allItems = new List<T>(size);
        }
        private Storage(int size, params T[] products):this(size)
        {
            if (products == null)
            {
                throw new ArgumentNullException("You pass on no products");
            }
            if (products.Length > size)
            {
                throw new ArgumentOutOfRangeException("There is not space in storage for all products");
            }
            AddProducts(_allItems.ToList());
        }
        #endregion
        private void OnOverDated(StorageEventArgs args)
        {
            OverDated?.Invoke(this, args);
        }
        #region Static Methods
        static public void CreateStorage()
        {
            if (_instance != null) throw new ArgumentException("Instance of storage is already created");
            _instance = new Storage<T>(); 
        }
        static public void CreateStorage(int size)
        {
            if (_instance != null) throw new ArgumentException("Instance of storage is already created");
            _instance = new Storage<T>(size);
        }
        static public void CreateStorage(int size, T[] products)
        {
            if (_instance != null) throw new ArgumentException("Instance of storage is already created");
            _instance = new Storage<T>(size, products);
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
        public List<T> GetAllItems()
        {
            return _allItems;
        }
        public void AddProducts(List<T> products)
        {
            List<string> productsForUtil = new();
            if (_allItems.Count + products.Count <= _allItems.Capacity)
            {
                foreach (T product in products)
                {
                    if (!TryAddItem(product))
                    {
                        productsForUtil.Add(product.GetShortDescription());
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            if (productsForUtil.Count > 0)
            {
                FileOperations.RemoveUtilizedLines(productsForUtil);
            }
        }
        public bool TryAddItem(T item)
        {
            if (item is DairyProducts dairyProduct)
            {
                if (dairyProduct.ShelfLife > 30)
                {
                    OnOverDated(new StorageEventArgs("You can't add product with shelf life more than 30 days", dairyProduct.ToString()));
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
        public List<K> FindProducts<K>(Predicate<K> predicate) where K:T
        {
            List<K> found = new List<K>();
            foreach (T item in _allItems)
            {
                if (item is K Kitem && predicate(Kitem))
                {
                    found.Add(Kitem);
                }
            }
            return found;
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
                result+=item.ToString() + "\n";
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
