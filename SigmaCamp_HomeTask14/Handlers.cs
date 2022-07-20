using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using SigmaCamp_HomeTask14.Services;

namespace SigmaCamp_HomeTask14
{
    static class Handlers
    {
        public static void AddItemHandler(object obj, StorageEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(args.Message);
            Console.ForegroundColor = ConsoleColor.White;
            FileOperations.AddToUtilized(args.ProductDescription);
        }
    }
}
