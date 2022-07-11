using SigmaCamp_HomeTask13.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask13
{
    static public class Handlers
    {
        public static void ServePersonHandler(object obj, CheckoutEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(args.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void AddPersonHandler(object obj, CheckoutEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(args.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void ClosePersonHandler(object obj, CheckoutEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(args.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void OvercrowdFirstHandler(object obj, CheckoutCoordEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(args.Message);
            Console.ForegroundColor = ConsoleColor.White;
            if (obj is CheckoutsCoordinator coordinator)
            {
                coordinator.Controller.AddOvercrowdedCheckout(args.Checkout);
                Console.WriteLine("What status do you want to open new checkout? ");
                coordinator.Controller.RedirectPersons(Console.ReadLine());
            }
        }
        public static void OvercrowdManyHandler(object obj, CheckoutCoordEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(args.Message);
            Console.ForegroundColor = ConsoleColor.White;
            if (obj is CheckoutsCoordinator coordinator)
            {
                bool isAllCut = false;
                while (!isAllCut)
                {
                    foreach (Checkout checkout in coordinator.Controller.GetCheckoutsForServe())
                    {
                        if (checkout.GetQueueLength() > Checkout.MaxQueueNumber)
                        {
                            checkout.Dequeue();
                        }
                    }
                }
            }
        }
    }
}
