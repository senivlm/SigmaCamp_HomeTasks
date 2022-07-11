using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask13
{
    internal class WrongStatusException:Exception
    {
        public WrongStatusException(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
}
