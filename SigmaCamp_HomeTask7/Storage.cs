using System;
using System.Collections;

namespace SigmaCamp_HomeTask1
{
    internal class Storage:IEnumerable<Product>
    {
        int place = 0;
        private Product[] _allProducts;

        #region Constructors
        public Storage()
        {
            _allProducts = new Product[100];
        }
        public Storage(int size)
        {           
            _allProducts = new Product[size];
        }
        public Storage(int size, params Product[] products):this(size)
        {
            if (products == null)
            {
                throw new ArgumentNullException("You pass on no products");
            }
            if (products.Length > size)
            {
                throw new ArgumentOutOfRangeException("There is not space in storage for all products");
            }
            for (int i = 0; i < products.Length; i++)
            {
                _allProducts[i] = products[i];
            }
        }
        public Storage(int size, string fileName):this(size)
        {
            ReadProductsFromFile(fileName); 
        }
        #endregion
        public Product this[int index]
        {
            get
            {
                if (index<0 || index > _allProducts.Length)
                {
                    throw new ArgumentOutOfRangeException("You cant specify such index for storage");
                }
                return _allProducts[index];
            }
        }
        private bool CheckFileExistence(string fileName, out string path)
        {
            path = "../../../" + fileName;
            if (!File.Exists(path))
            {
                int i = 1;
                Console.WriteLine($"File {fileName} doesn't exist.");
                Console.WriteLine("You have 2 attempts to input correct file name");
                while (i < 3)
                {
                    Console.Write($"Attempt {i}: ");
                    path = "../../../" + Console.ReadLine();
                    if (File.Exists(path))
                    {
                        return true;
                    }
                    Console.WriteLine($"Attempt {i} failed");
                    i++;
                }
                return false;
            }
            return true;
        }
        private void ReadProductsFromFile(string fileName)
        {
            string inputFilePath;
            if (CheckFileExistence(fileName, out inputFilePath))
            {
                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    using (StreamWriter sw = new StreamWriter("../../../ErrorReport.txt", true))
                    {
                        int place = 0;
                        while (!sr.EndOfStream && place < _allProducts.Length)
                        {
                            string line = sr.ReadLine();
                            try
                            {
                                ParseProduct(line, place);
                                place++;
                            }
                            catch (ArgumentException ex)
                            {
                                sw.WriteLine($"Error:\n\tLine: {line}\n\t" + ex.Message);
                            }
                            catch(FormatException ex)
                            {
                                sw.WriteLine($"Error:\n\tLine: {line}\n\t" + ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("All attempts failed");
            }
        }
        private void ParseProduct(string line, int place)
        {
            Product product;
            if (ProductParsing.TryParseProduct(line, out product))
            {
                _allProducts[place] = product;
            }     
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
