using System;

namespace SigmaCamp_HomeTask1
{
    internal class Meat:Product
    {
        private string _category;
        private string _kind;
        public Meat(decimal price, double weight, string category, string kind):base("М'ясо", price, weight)
        {
            Category = category;
            Kind = kind;
        }
        public string Category
        {
            get => _category;
            set
            {
                switch (value)
                {
                    case "Extra class 1":
                        _category = value;
                        break;
                    case "Extra class 2":
                        _category = value;
                        break;
                    default:
                        throw new ArgumentException("Category can be only Extra class 1 or 2");
                }
            }
        }
        public string Kind
        {
            get => _kind;
            set
            {
                switch (value)
                {
                    case "mutton":
                        _category = value;
                        break;
                    case "veal":
                        _category = value;
                        break;
                    case "pork":
                        _category = value;
                        break;
                    case "chicken":
                        _category = value;
                        break;
                    default:
                        throw new ArgumentException("Category can be only Extra class 1 or 2");
                }
            }
        }
        public override string ToString()
        {
            return $"{Name} {Kind}, {Category}, {Price} UAH for {Weight} kg";
        }
    }
}
