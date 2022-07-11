using SigmaCamp_HomeTask13.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask13.Services
{
    public class CheckoutsController
    {
        private List<Checkout> _availableCheckouts;
        private List<Checkout> _checkoutsOnBreak;
        private List<Checkout> _overcrowdedCheckouts;
        private int _workTime;
        
        public int WorkTime 
        {
            get { return _workTime; }
            set
            {
                if (value >= 0) _workTime = value;
            }
        }

        #region Constructors
        public CheckoutsController()
        {
            WorkTime = 0;
            _availableCheckouts = new List<Checkout>();
            _checkoutsOnBreak = new List<Checkout>();
            _overcrowdedCheckouts = new List<Checkout>();
        }
        public CheckoutsController(List<Checkout> checkouts) : this()
        {
            _availableCheckouts.AddRange(checkouts);
        }
        #endregion
        public List<Checkout> GetCheckoutsForAdd()
        {
            return _availableCheckouts.Except(_overcrowdedCheckouts).ToList();
        }
        public List<Checkout> GetCheckoutsForServe()
        {
            return _availableCheckouts;
        }
        public void OpenNewCheckout(Checkout checkout)
        {
            if (checkout == null) throw new ArgumentNullException();
            _availableCheckouts.Add(checkout);
        }
        public void CloseCheckout(Checkout checkout)
        {
            _availableCheckouts.Remove(checkout);
            checkout.OnClosed(new CheckoutEventArgs($"Checkout{checkout.Number} was closed"));
            _checkoutsOnBreak.Add(checkout);
        }
        public void AddOvercrowdedCheckout(Checkout checkout)
        {
            _overcrowdedCheckouts.Add((checkout));
        }
        public bool CheckFullCheckoutEmptiness()
        {
            foreach (var checkout in _availableCheckouts)
            {
                if (!checkout.IsEmpty())
                {
                    return false;
                }
            }
            return true;
        }
        public void RedirectPersons(string status)
        {
            CheckoutStatus checkoutStatus;
            if (Enum.TryParse(status, true, out checkoutStatus))
            {
                Checkout openedCheckout = new Checkout(_overcrowdedCheckouts[_overcrowdedCheckouts.Count - 1].Coordinate++,
                    checkoutStatus);
                OpenNewCheckout(openedCheckout);
                foreach (Checkout checkout in _availableCheckouts)
                {
                    while (ReferenceEquals(checkout, openedCheckout) && openedCheckout.TryEnqueue(checkout.Dequeue()))
                    {       
                    }
                }
            }
        }
        public bool CheckQueuesEquality()
        {
            for (int i = 0; i < _availableCheckouts.Count - 1; i++)
            {
                if (_availableCheckouts[i].GetQueueLength() != _availableCheckouts[i + 1].GetQueueLength())
                {
                    return false;
                }
            }
            return true;
        }
        public List<Checkout> GetMinQeueCheckouts()
        {
            return GetCheckoutsForAdd().Where(c => c.GetQueueLength().Equals(_availableCheckouts.Min(c => c.GetQueueLength()))).ToList();
        }
    }
}
