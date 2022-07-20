using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaCamp_HomeTask14.ProductInterfaces;

namespace SigmaCamp_HomeTask14.ProductTypes
{
    internal class ElectricalDevice : Product, IElectricalDevice
    {
        private int _guaranteePeriod;
        public ElectricalDevice() : base() { }
        public ElectricalDevice(string name, decimal price, double weight, int guaranteePeriod) : base(name, price, weight)
        {
            GuaranteePeriod = guaranteePeriod;
        }
        public int GuaranteePeriod
        {
            get
            {
                return _guaranteePeriod;
            }
            set
            {
                if (value <= 0) throw new ArgumentException();
                _guaranteePeriod = value;
            }
        }
    }
}
