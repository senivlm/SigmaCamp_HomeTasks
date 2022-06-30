using System;
using System.Globalization;
using System.Linq;
using SigmaCamp_HomeTask12_1.CustomInterfaces;
namespace SigmaCamp_HomeTask12_1
{
    internal class Product:IPrinter, IPriceChanger, IStorageItem
    {
        private decimal _price;
        private double _weight;
        private string _name;
        public Product() {}
        public Product(string name, decimal price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == null )
                {
                    throw new ArgumentNullException("You can't assign null to name");
                }
                if (value.Any(char.IsDigit))
                {
                    throw new ArgumentException("Type of error: Name of argument contains digit \n\tTime:" + DateTime.Now.ToString("r", CultureInfo.GetCultureInfo("en-US")));
                }
                if (Char.IsLower(value[0]))
                {
                    value = Char.ToUpper(value[0]) + value.Substring(1);
                }
                _name = value;
            }
        }
        public double Weight
        {
            get { return _weight; }
            set 
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException("Type of error: There is an incorrect value for product`s weight \n\tTime:" + DateTime.Now.ToString("r", CultureInfo.GetCultureInfo("en-US")));
                }
                else
                {
                    _weight = value;
                }
            }
        }
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Type of error: There is an incorrect value for product`s price\n\tTime:" + DateTime.Now.ToString("r", CultureInfo.GetCultureInfo("en-US")));
                }
                else
                {
                    _price = value;
                };
            }
        }
        public virtual string GetDescription()
        {
            return $"Name: {Name}, Price: {Price}, Weight: {Weight}";
        }
        public virtual void ChangePrice(int percentToChange)
        {
            Price = Price * (decimal)((double)percentToChange/100+1);
        }
        public override bool Equals(object obj)
        {
            if (obj is Product anotherProduct)
            {
                return this.Name == anotherProduct.Name && this.Price == anotherProduct.Price && this.Weight == anotherProduct.Weight;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return Price.GetHashCode() ^ Weight.GetHashCode() ^ Name.GetHashCode();  
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
