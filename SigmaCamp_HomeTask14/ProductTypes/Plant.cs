using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask14.ProductInterfaces;

namespace SigmaCamp_HomeTask14.ProductTypes
{
    internal class Plant:Product, IPlant
    {
        private string _originCountry;
        public Plant():base() { }
        public Plant(string name, decimal price, double weight, string originCountry): base(name, price, weight)
        {
            OriginCountry = originCountry;
        }
        public string OriginCountry
        {
            get { return _originCountry; }
            set
            {
                if(value == null) throw new ArgumentNullException();
                _originCountry = value;
            }
        }
    }
}
