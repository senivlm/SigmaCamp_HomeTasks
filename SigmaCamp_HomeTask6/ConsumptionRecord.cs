using System;

namespace SigmaCamp_HomeTask6
{
    internal class ConsumptionRecord
    {
        DateTime _date = new DateTime();
        int _startCounterValue;
        int _endCounterValue;
        int _quartal;
        public ConsumptionRecord(string date, int startCounterValue, int endCounterValue, int quartal)
        {

            StartCounterValue = startCounterValue;
            EndCounterValue = endCounterValue;
            Quartel = quartal;
            InitDate(date);
        }
        private void InitDate(string date)
        {
            date.Replace('.', '/');
            date.LastIndexOf('/');
            date.Insert(date.LastIndexOf('/') + 1, "20");
            DateTime someDate;
            if (DateTime.TryParse(date, out someDate))
            {
                _date = new DateTime(someDate.Year, someDate.Month, someDate.Day);
            }
        }
        public DateTime Date
        {
            get { return _date; }
        }
        public int StartCounterValue
        {
            get { return _startCounterValue; }
            init
            {
                if (value > 0)
                {
                    _startCounterValue = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public int EndCounterValue
        {
            get { return _endCounterValue; }
            init
            {
                if (value > 0)
                {
                    _endCounterValue = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public int Quartel
        {
            get { return _quartal; }
            init
            {
                if (value > 0 && value < 4)
                {
                    _quartal = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value for quartel");
                }
            }
        }
    }
}
