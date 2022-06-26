using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask10_1
{
    class WordDoesntFoundExeption : Exception
    {
        public WordDoesntFoundExeption() : base()
        {
        }

        public WordDoesntFoundExeption(string message) : base(message)
        {
        }


    }
}
