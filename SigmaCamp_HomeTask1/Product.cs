using System;

namespace SigmaCamp_HomeTask1
{
    internal class Product
    {
        private decimal _price;
        private double _weight;
        public string Name { get; private set; }
        public Product() {}
        public Product(string name, decimal price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
        public double Weight
        {
            get { return _weight; }
            set 
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException("There is an incorrect value for product`s weight");
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
                    throw new ArgumentOutOfRangeException("There is an incorrect value for product`s price");
                }
                else
                {
                    _price = value;
                };
            }
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name}, {Price} UAH for {Weight} kg";
        }
    }
}
