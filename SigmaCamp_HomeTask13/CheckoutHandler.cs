using SigmaCamp_HomeTask13.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask13
{
    public delegate void CheckoutHandler(object sender, CheckoutEventArgs e);
    public class CheckoutEventArgs
    {
        public string Message { get; private set; }
        public CheckoutEventArgs(string someMessage)
        {
            Message = someMessage;
        }
    }
}
