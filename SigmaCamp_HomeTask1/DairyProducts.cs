using System;

namespace SigmaCamp_HomeTask1
{
    internal class DairyProducts:Product
    {
        private int _shelfLife;
        public DairyProducts(string name, decimal price, double weight, int shelfLife):base(name, price, weight)
        {
            ShelfLife = shelfLife;
        }
        public int ShelfLife
        {
            get => _shelfLife;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("There is an incorrect value for product`s shelf life");
                }
                else
                {
                    _shelfLife = value;
                }
            }
        }

    }
}
