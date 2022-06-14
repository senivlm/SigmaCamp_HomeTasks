using System;
using System.Collections;

namespace SigmaCamp_HomeTask1
{
    internal class Storage:IEnumerable<Product>
    {
        int place = 0;
        private Product[] _allProducts;
        public Storage()
        {
            _allProducts = new Product[100];
        }
        public Storage(int size)
        {           
            _allProducts = new Product[size];
        }
        public Product this[int index]
        {
            get { return _allProducts[index]; }
        }
        public void InputManully()
        {
            decimal price;
            double weight;
            int shelfLife;
            Console.Write("Enter which type of product you want to add: m(Meat), d(Dairy), o(other)? ");
            char typeOfProduct = Console.ReadKey().KeyChar;
            switch (typeOfProduct)
            {
                case 'm':
                    Console.WriteLine("Input price, weight, category and kind of meat separated by comma");
                    string[] meatDescription = Console.ReadLine()?.Split(',');
                    if (meatDescription.Length == 4)
                    {
                        if (decimal.TryParse(meatDescription[0], out price) && double.TryParse(meatDescription[0], out weight))
                        {
                            _allProducts[place] = new Meat(price, weight, meatDescription[2], meatDescription[3]);
                            place++;
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException("You entered data in incorrect format");
                    }
                    break;
                case 'o':
                    Console.WriteLine("Input name, price, and weight of product separated by comma");
                    string[] productDescription = Console.ReadLine()?.Split(',');
                    if (productDescription.Length == 3)
                    {
                        if (decimal.TryParse(productDescription[1], out price) && double.TryParse(productDescription[2], out weight))
                        {
                            _allProducts[place] = new Product(productDescription[0], price, weight);
                            place++;
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException("You entered data in incorrect format");
                    }
                    break;
                case 'd':
                    Console.WriteLine("Input name, price, weight and shelf life of dairy product separated by comma");
                    string[] dairyProductDescription = Console.ReadLine()?.Split(',');
                    if (dairyProductDescription.Length == 4)
                    {
                        if (decimal.TryParse(dairyProductDescription[1], out price) && double.TryParse(dairyProductDescription[2], out weight) && int.TryParse(dairyProductDescription[3], out shelfLife))
                        {
                            _allProducts[place] = new DairyProducts(dairyProductDescription[0], price, weight, shelfLife);
                            place++;
                        }
                    }
                    else
                    {
                        throw new ArgumentNullException("You entered data in incorrect format");
                    }
                    break;
            } 
        }

        public void ChangeAllProductsPrice(int percentToChange)
        {
            foreach (Product product in _allProducts)
            {
                product.ChangePrice(percentToChange);
            }
        }
        public List<Meat> GetMeatProducts()
        {
            List<Meat> meatProducts = new List<Meat>();
            foreach (Product product in _allProducts)
            {
                if (product is Meat meatProduct)
                {
                    meatProducts.Add(meatProduct);
                }
            }
            return meatProducts;
        }
        public void PrintFullDescription()
        {
            foreach (Product item in _allProducts)
            {
                Console.WriteLine(item.GetDescription());
            }
        }
        public IEnumerator<Product> GetEnumerator()
        {
            return ((IEnumerable<Product>)_allProducts).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
