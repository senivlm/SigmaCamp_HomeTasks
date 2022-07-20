using SigmaCamp_HomeTask14.ProductInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask14.SerializationService
{
    internal interface ICustomSerializer
    {
        public void Serialize(List<IProduct> products);
        public List<IProduct> Deserialize();
    }
}
