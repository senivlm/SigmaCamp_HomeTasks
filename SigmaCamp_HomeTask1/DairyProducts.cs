using System;

namespace SigmaCamp_HomeTask1
{
    internal class DairyProducts:Product
    {
        const double rate1 = 0.05;
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
        public override void ChangePrice(int percentToIncrease)
        {
            base.ChangePrice(percentToIncrease);
            if (ShelfLife > 1 && ShelfLife <= 5)
            {
                Price = Price * (decimal)(rate1*4 + 1);
            }
            else if (ShelfLife > 5 && ShelfLife <= 15)
            {
                Price = Price * (decimal)(rate1*3 + 1);
            }
            else if (ShelfLife > 15 && ShelfLife <= 25)
            {
                Price = Price * (decimal)(rate1*2 + 1);
            }
            else
            {
                Price = Price * (decimal)(rate1 + 1);
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
