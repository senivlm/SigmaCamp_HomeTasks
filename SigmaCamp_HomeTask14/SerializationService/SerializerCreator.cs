using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask14.SerializationService
{
    internal abstract class SerializerCreator
    {
        abstract public CustomSerializer CreateSerializer(string FilePath);
    }
}
