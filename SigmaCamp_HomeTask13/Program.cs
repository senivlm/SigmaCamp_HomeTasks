using SigmaCamp_HomeTask13.Data;
using SigmaCamp_HomeTask13.Services;
using System;
using System.IO;
using System.Collections.Generic;

namespace SigmaCamp_HomeTask13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PersonService.WriteRandomGenerate("../../../Persons.txt", 50, 70);
                List<Checkout> checkouts = new List<Checkout>()
                {
                    (new Checkout (22.0)),
                    (new Checkout (11.0)),
                    (new Checkout (7.0)),
                    (new Checkout (40.0))
                };
                foreach (Checkout checkout in checkouts)
                {
                    checkout.Added += Handlers.AddPersonHandler;
                    checkout.Served += Handlers.ServePersonHandler;
                    checkout.Closed += Handlers.ClosePersonHandler;
                }
                CheckoutsController controller = new(checkouts);
                CheckoutsCoordinator coordinator = new(controller, 1);
                coordinator.OvercrowdedFirstTime += Handlers.OvercrowdFirstHandler;
                coordinator.OvercrowdedManyTimes += Handlers.OvercrowdManyHandler;
                coordinator.CoordinatePersons("../../../Persons.txt");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}