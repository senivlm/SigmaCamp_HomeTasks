using System;
using System.Globalization;
using SigmaCamp_HomeTask14.ProductInterfaces;
namespace SigmaCamp_HomeTask14
{
    internal class Meat:Product, IMeatProduct
    {
        const double rateCategory1 = 0.1;
        const double rateCategory2 = 0.15;
        public override string Type => typeof(Meat).FullName;
        private MeatCategory _category;
        private MeatKind _kind;
        public Meat():base() { }
        public Meat(decimal price, double weight, string category, string kind):base("Meat", price, weight)
        {
            Category = category;
            Kind = kind;
        }
        public string Category
        {
            get => _category.ToString();
            set
            {
                if (!Enum.TryParse(value.Replace(" ", ""), true, out _category))
                {
                    throw new ArgumentException("There is no such kind or category of meat");
                }
            }
        }
        public string Kind
        {
            get => _kind.ToString();
            set
            {
                if (value != null && Char.IsLower(value[0]))
                {
                    value = Char.ToUpper(value[0]) + value.Substring(1);
                }
                if (!Enum.TryParse(value, true, out _kind))
                {
                    throw new ArgumentException("Type of error: There is no such kind or category of meat\n\tTime:" + DateTime.Now.ToString("r", CultureInfo.GetCultureInfo("en-US")));
                }
            }
        }
        public override void ChangePrice(int percentToChange)
        {
            base.ChangePrice(percentToChange);
            switch (_category)
            {
                case MeatCategory.ExtraClass1:
                    Price = Price * (decimal)(rateCategory1+1);
                    break;
                case MeatCategory.ExtraClass2:
                    Price = Price * (decimal)(rateCategory2 + 1);
                    break;
                default:
                    break;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Meat anotherMeat)
            {
                return base.Equals(anotherMeat) && this.Category == anotherMeat.Category && this.Kind == this.Kind;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return $"Kind: {Kind}, Category: {Category}, Price: {Price}, Weight: {Weight}";
        }
        public override string GetShortDescription()
        {
            return base.GetShortDescription() + $", {Category}, {Kind}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
