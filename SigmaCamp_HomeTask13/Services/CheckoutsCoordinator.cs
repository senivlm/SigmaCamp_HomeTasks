using SigmaCamp_HomeTask13.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
namespace SigmaCamp_HomeTask13.Services
{
    internal class CheckoutsCoordinator
    {
        private int _enterPersonTime;
        private CheckoutsController _checkoutsController;

        //Містить кількість обслужених людей на кожній касі
        private Dictionary<Checkout, int> _checkoutsEfficiency;
        private List<Person> persons;
        public event CheckoutCoordHandler OvercrowdedFirstTime;
        public event CheckoutCoordHandler OvercrowdedManyTimes;
        private int overcrowdedEventNumber = 0;

        public CheckoutsController Controller
        {
            get { return _checkoutsController; }
            set
            {
                if(value == null) throw new ArgumentNullException();
                _checkoutsController = value; 
            }
        }
        public CheckoutsCoordinator(int enterPersonTime = 1)
        {
            _checkoutsEfficiency = new Dictionary<Checkout, int>();
            _enterPersonTime = enterPersonTime;
        }
        public CheckoutsCoordinator(CheckoutsController checkoutsController, int enterPersonTime):this(enterPersonTime)
        {
            if (checkoutsController == null) throw new ArgumentNullException();
            Controller = checkoutsController;
            foreach (Checkout checkout in _checkoutsController.GetCheckoutsForServe())
            {
                _checkoutsEfficiency.Add(checkout, 0);
            }
        }
        private void OnOvercrowdedFirstTime(CheckoutCoordEventArgs args)
        {
            overcrowdedEventNumber++;
            OvercrowdedFirstTime?.Invoke(this, args);
        }
        private void OnOvercrowdedManyTimes(CheckoutCoordEventArgs args)
        {
            overcrowdedEventNumber++;
            OvercrowdedManyTimes?.Invoke(this, args);
        }
        public void CoordinatePersons(string filePath)
        {
            bool isProcess = true;
            persons = PersonService.ReadPersons(filePath);
            while (isProcess)
            {
                if (_checkoutsController.WorkTime % _enterPersonTime == 0 && persons.Count != 0)
                {
                    Person personToAdd = persons[0];
                    if (TryAddToQueue(personToAdd))
                        persons.RemoveAt(0);
                    else
                        persons.Insert(0, personToAdd); 
                }
                Serve();
                if (_checkoutsController.WorkTime == 30)
                {
                    Checkout closingCheckout = ChooseCheckoutForBreak();
                    _checkoutsController.CloseCheckout(closingCheckout);
                    ReformQueues(closingCheckout);
                }
                _checkoutsController.WorkTime++;
                if (_checkoutsController.CheckFullCheckoutEmptiness() && persons.Count==0)
                {
                    isProcess = false;
                }
            }
        }
        private void Serve()
        {
            foreach (var checkout in _checkoutsController.GetCheckoutsForServe())
            {
                if (!checkout.IsEmpty() && --checkout.Peek().TimeServise == 0)
                {
                    checkout.Dequeue();
                    _checkoutsEfficiency[checkout]++;
                }
                Thread.Sleep(1);
            }
        }
        private bool TryAddToQueue(Person person)
        {
            Checkout preferredCheckout = ChooseCheckout(person);
            if (!preferredCheckout.TryEnqueue(person))
            {
                if (overcrowdedEventNumber ==0)
                {
                    OnOvercrowdedFirstTime(new CheckoutCoordEventArgs($"Checkout{preferredCheckout.Number} is overcrowded." +
                        $" {overcrowdedEventNumber+1} overcrowding",
                        preferredCheckout));
                }
                else
                {
                    OnOvercrowdedManyTimes(new CheckoutCoordEventArgs($"Checkout{preferredCheckout.Number} is overcrowded." +
                        $" {overcrowdedEventNumber+1} overcrowding",
                        preferredCheckout));
                }
                return false;
            }
            return true;
        }
        private void ReformQueues(Checkout reformingCheckout)
        {
            while (!reformingCheckout.IsEmpty())
            {
                Person personToAdd = reformingCheckout.Dequeue();
                if (!TryAddToQueue(personToAdd))
                {
                    persons.Insert(0, personToAdd);
                }
            }
        }
        private Checkout ChooseCheckoutForBreak()
        {
            return _checkoutsEfficiency.MinBy(c => c.Value).Key;
        }
        private Checkout ChooseCheckout(Person person)
        {
            if (_checkoutsController.CheckQueuesEquality())
            {
                return GetClosestCheckout(person, _checkoutsController.GetCheckoutsForAdd());
            }
            else
            {
                return GetClosestCheckout(person, _checkoutsController.GetMinQeueCheckouts());
            }
        }
        private Checkout GetClosestCheckout(Person person, List<Checkout> checkouts)
        {
            var chosen = checkouts.Select(c => new { coorDif = Math.Abs(person.Coordinate - c.Coordinate), closestCheckout = c }).OrderBy(dif => dif.coorDif);
            return chosen.FirstOrDefault().closestCheckout;
        }
    }
}
