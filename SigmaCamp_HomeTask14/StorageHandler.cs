using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask14
{
    public delegate void StorageHandler(object sender, StorageEventArgs e);
    public class StorageEventArgs
    {
        public string Message { get; private set; }
        public string ProductDescription { get; private set; }
        public StorageEventArgs(string someMessage, string decscription)
        {
            Message = someMessage;
            ProductDescription = decscription;
        }
    }
}
