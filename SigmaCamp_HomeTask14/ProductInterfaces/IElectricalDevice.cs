using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask14.ProductInterfaces
{
    internal interface IElectricalDevice:IProduct
    {
        public int GuaranteePeriod { get; set; }
    }
}
