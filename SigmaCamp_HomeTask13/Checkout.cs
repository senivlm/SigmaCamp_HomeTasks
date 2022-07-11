using SigmaCamp_HomeTask13.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask13
{
    public class Checkout
    {
        public const int MaxQueueNumber = 5; 
        private static int _counter = 0;
        private double _coordinate = default;
        private PriorityQueue<Person, PersonStatus> _queuePersons;
        public event CheckoutHandler Served;
        public event CheckoutHandler Added;
        public event CheckoutHandler Closed;
        public CheckoutStatus Status { get; private set; }
        public int Number { get; private set; }
        public double Coordinate
        {
            get { return _coordinate; }
            set { _coordinate = value; }
        }
        public Checkout()
        {
            Number = ++_counter;
            _queuePersons = new(new PersonStatusComparer());
        }

        public Checkout(double coordinate, CheckoutStatus status = CheckoutStatus.Any):this()
        {
            this._coordinate = coordinate;
            Status = status;
        }
        public void OnServed(CheckoutEventArgs args)
        {
            Served?.Invoke(this, args);
        }
        public void OnAdded(CheckoutEventArgs args)
        {
            Added?.Invoke(this, args);
        }
        public void OnClosed(CheckoutEventArgs args)
        {
            Closed?.Invoke(this, args);
        }
        public bool IsEmpty()
        {
            return _queuePersons.Count == 0;
        }

        public bool TryEnqueue(Person person)
        {
            if (person.GetStatus().ToString() == Status.ToString().Substring(3)) 
                throw new WrongStatusException($"{person} can't be added to checkot with status {Status}");
            if (_queuePersons.Count < MaxQueueNumber)
            {
                _queuePersons.Enqueue(person, person.GetStatus());
                OnAdded(new CheckoutEventArgs($"{person} was added to checkout{Number}"));
                return true;
            }
            return false;
        }

        public Person Dequeue()
        {
            Person servedPerson = _queuePersons.Dequeue();
            OnServed(new CheckoutEventArgs($"\nCheckout_{Number}: {servedPerson} has been served\n"));
            return servedPerson;
        }

        public Person Peek()
        {
            return _queuePersons.Peek();
        }
        public int GetQueueLength()
        {
            return _queuePersons.Count;
        }

    }
}
