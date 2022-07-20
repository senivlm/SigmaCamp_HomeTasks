using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask14.ProductTypes;
using SigmaCamp_HomeTask14.ProductInterfaces;
namespace SigmaCamp_HomeTask14.ProductFactories
{
    internal abstract class ProductFactory
    {
        public abstract IProduct CreateProduct1();
        public abstract IProduct CreateProduct2();
        public abstract IProduct CreateProduct3();
    }
}
