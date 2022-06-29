using System;
using System.Globalization;
namespace SigmaCamp_HomeTask12_1
{
    internal class DairyProducts:Product
    {
        const double rate1 = 0.05;
        private int _shelfLife;
        public DairyProducts() { }
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
                    throw new ArgumentException("Type of error: There is an incorrect value for product`s shelf life\n\tTime:" + DateTime.Now.ToString("r", CultureInfo.GetCultureInfo("en-US")));
                }
                else
                {
                    _shelfLife = value;
                }
            }
        }
        public override void ChangePrice(int percentToChange)
        {
            base.ChangePrice(percentToChange);
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
        public override string GetDescription()
        {
            return base.GetDescription() + $", Shelf Life: {ShelfLife}";
        }
        public override bool Equals(object obj)
        {
            if (obj is DairyProducts anotherDP)
            {
                return base.Equals(anotherDP) && this._shelfLife == anotherDP._shelfLife;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
