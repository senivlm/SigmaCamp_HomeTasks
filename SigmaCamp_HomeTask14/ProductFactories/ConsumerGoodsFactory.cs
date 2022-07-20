using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask14.ProductTypes;
using SigmaCamp_HomeTask14.ProductInterfaces;

namespace SigmaCamp_HomeTask14.ProductFactories
{
    internal class ConsumerGoodsFactory : ProductFactory
    {
        public override IProduct CreateProduct1()
        {
            return new Product();
        }

        public override IProduct CreateProduct2()
        {
            return new Meat();
        }
        public override IProduct CreateProduct3()
        {
            return new DairyProducts();
        }
    }
}
