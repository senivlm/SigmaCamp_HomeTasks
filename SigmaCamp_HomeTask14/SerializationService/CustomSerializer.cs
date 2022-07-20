using SigmaCamp_HomeTask14.ProductInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask14.SerializationService
{
    internal abstract class CustomSerializer:ICustomSerializer
    {
        public string FilePath { get; init; }
        public CustomSerializer(string outputFilePath)
        {
            FilePath = outputFilePath;
        }
        abstract public void Serialize(List<IProduct> products);
        abstract public List<IProduct> Deserialize();
    }
}
