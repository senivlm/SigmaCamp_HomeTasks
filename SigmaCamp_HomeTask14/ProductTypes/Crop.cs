using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask14.ProductInterfaces;
namespace SigmaCamp_HomeTask14.ProductTypes
{
    internal class Crop:Plant, ICrop
    {
        private string _kind;
        private string _sort;
        public Crop() : base() { }
        public Crop(string name, decimal price, double weight, string originCountry, string kind, string sort) : base(name, price, weight, originCountry)
        {
            Kind = kind;
            Sort = sort;
        }
        public string Kind
        {
            get { return _kind; }
            set
            {
                if (value == null) throw new ArgumentNullException();
                _kind = value;
            }
        }
        public string Sort
        {
            get { return _sort; }
            set
            {
                if (value == null) throw new ArgumentNullException();
                _sort = value;
            }
        }
    }
}
