using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask13.Data
{
    public class Person
    {
        private string _name;
        private int _timeServiсe;
        private int _age;
        private double _coordinate;
        private PersonStatus _status;
        public double Coordinate
        {
            get { return _coordinate; }
            set { _coordinate = value; }
        }
        public int TimeServise 
        { 
            get => _timeServiсe;
            set
            {
                _timeServiсe = value;
            }
        }

        public Person() : this("", default, default, default, default) { }

        public Person(string name, string status, int age, double coordinate, int timeServise)
        {
            this._name = name;
            this._age = age;
            this._coordinate = coordinate;
            SetStatus(status);
            this._timeServiсe = timeServise;
        }
        public void SetStatus(string status)
        {
            if (!Enum.TryParse(status, true, out _status))
            {
                throw new ArgumentException($"There is no such status of person: {status}");
            }
        }
        public PersonStatus GetStatus()
        {
            return _status;
        }
        public override string ToString()
        {
            return $"{_name} {_status} {_age} {_coordinate} {_timeServiсe}";
        }
    }
}
