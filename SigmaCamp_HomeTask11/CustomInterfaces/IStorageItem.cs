using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask11.CustomInterfaces
{
    internal interface IStorageItem
    {
        string Name { get; set; }
        double Weight { get; set; } 
        decimal Price { get; set; }
    }
}
