using System;
using System.Globalization;

namespace SigmaCamp_HomeTask6
{
    internal class ConsumptionRecord
    {
        DateTime _date = new DateTime();
        int _startCounterValue;
        int _endCounterValue;
        public ConsumptionRecord(string date, int startCounterValue, int endCounterValue)
        {

            StartCounterValue = startCounterValue;
            EndCounterValue = endCounterValue;
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
        public string GetMonthName()
        {
            string monthName = string.Empty;
            if (_date.Day >= 1 && _date.Day <= 3)
            {
                monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(_date.Month - 1);
            }
            else
            {
                monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(_date.Month);
            }
            monthName = char.ToUpper(monthName[0]) + monthName.Substring(1);
            return monthName;
        }
        public override string ToString()
        {
            return $"Used electricity on {GetMonthName()}: {EndCounterValue - StartCounterValue}";
        }
    }
}
