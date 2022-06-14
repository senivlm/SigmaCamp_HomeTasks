using System;

namespace SigmaCamp_HomeTask3
{
    internal class Pair
    {
        private int _number;
        private int _frequency;
        public Pair()
        {
            
        }
        public Pair(int number, int frequency)
        {
            Number = number;
            Frequency = frequency;
        }
        public int Number { get => _number; set => _number = value; }
        public int Frequency { get => _frequency; set => _frequency = value; }
        public override string ToString()
        {
            return $"{_number} - {_frequency}";
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Pair pair2)
            {
                return this.Number == pair2.Number && this.Frequency == pair2.Frequency;
            }
            else
            {
                return false;
            }
        }
    }
}
