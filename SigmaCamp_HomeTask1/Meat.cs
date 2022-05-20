using System;

namespace SigmaCamp_HomeTask1
{
    public enum MeatCategory
    {
        ExtraClass1,
        ExtraClass2
    }
    public enum MeatKind
    {
        mutton,
        veal,
        pork,
        chicken
    }
    internal class Meat:Product
    {
        const double rateCategory1 = 0.1;
        const double rateCategory2 = 0.15;
        private MeatCategory _category;
        private MeatKind _kind;
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
                if (!Enum.TryParse(value, true, out _category))
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
                if (!Enum.TryParse(value, true, out _kind))
                {
                    throw new ArgumentException("There is no such kind or category of meat");
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
        public override string ToString()
        {
            return $"{Name} {_kind}, {_category}";
        }
    }
}
