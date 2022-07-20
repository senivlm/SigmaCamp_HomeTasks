using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask14.ProductInterfaces
{
    internal interface IProduct
    {
        public Guid Id { get; set; }
        public  string Name { get; set; }
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public void ChangePrice(int percentToChange);
        public string GetShortDescription();
    }
}
