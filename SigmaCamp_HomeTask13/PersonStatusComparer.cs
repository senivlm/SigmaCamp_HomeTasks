using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask13
{
    internal class PersonStatusComparer : IComparer<PersonStatus>
    {
        public int Compare(PersonStatus x, PersonStatus y)
        {
            if((int)x == (int)y)
            {
                return 0;
            }
            else if((int)x < (int)y)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
