using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask12_3
{
    public delegate double Action(double? firstParam, double? secondParam = 0);
    internal class Function
    {
        private int _numofOperators;
        private int _priority;
        private Action _action;
        public string Sign { get; private set; }
        public int Priority
        {
            get { return _priority; }
            set
            {
                if (value < 0) throw new ArgumentException();
                _priority = value;
            }
        }
        public int NumOfOperators
        {
            get { return _numofOperators; }
            set
            {
                if (value == 1 || value == 2 || value == 0)
                {
                    _numofOperators = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public Function(string sign, int numOfOperators, int priority, Action action)
        {
            Sign = sign;
            NumOfOperators = numOfOperators;
            Priority = priority;
            _action = action;
        }
        public double? Calculate(params double?[] operators)
        {
            if (operators.Length != NumOfOperators) throw new ArgumentException($"{Sign} have to take only {NumOfOperators} operators");
            if (NumOfOperators == 1)
            {
                return _action(operators[0]);
            }
            else if (NumOfOperators == 2)
            {
                return _action(operators[0], operators[1]);
            }
            return null;
        }
    }
}
