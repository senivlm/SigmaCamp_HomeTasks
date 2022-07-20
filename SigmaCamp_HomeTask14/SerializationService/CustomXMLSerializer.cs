using SigmaCamp_HomeTask14.ProductInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask14.SerializationService
{
    internal class CustomXMLSerializer:CustomSerializer
    {
        public CustomXMLSerializer(string FilePath) : base(FilePath)
        {

        }
        public override List<IProduct> Deserialize()
        {
            throw new NotImplementedException();
        }

        public override void Serialize(List<IProduct> products)
        {
            throw new NotImplementedException();
        }
    }
}
