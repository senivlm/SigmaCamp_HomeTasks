using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask14.ProductInterfaces;
using SigmaCamp_HomeTask14.ProductTypes;
namespace SigmaCamp_HomeTask14.ProductFactories
{
    internal class IndustrialGoodsFactory : ProductFactory
    {
        public override IProduct CreateProduct1()
        {
            return new Plant();
        }

        public override IProduct CreateProduct2()
        {
            return new ElectricalDevice();
        }

        public override IProduct CreateProduct3()
        {
            return new Crop();
        }
    }
}
