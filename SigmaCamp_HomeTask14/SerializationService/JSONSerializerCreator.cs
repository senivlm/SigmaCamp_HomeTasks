using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask14.SerializationService
{
    internal class JSONSerializerCreator:SerializerCreator
    {
        public override CustomSerializer CreateSerializer(string FilePath)
        {
            return new CustomJSONSerializer(FilePath);
        }
    }
}
