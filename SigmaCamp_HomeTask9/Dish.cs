using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson14_06
{
    internal class Dish
    {
        private Dictionary<string, double> _ingridients;
        public int Length => _ingridients.Count;
        private string _name;
        public IEnumerable<string> Keys => _ingridients.Keys;
        public Dish(string dishName = "Unknown dish")
        {
            _name = dishName;
            _ingridients = new();
        }
        public Dish(string dishName, Dictionary<string, double> ingridients) : this()
        {
            _ingridients = ingridients;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("Name of dish can't be null");
                if (!char.IsUpper(value[0])) _name = char.ToUpper(value[0]) + value.Substring(1);
                else _name = value;
            }
        }
        public double this[string key]
        {
            get
            {
                return _ingridients[key];
            }
        }
        public void AddIngridient(string name, double weight)
        {
            if (name == null) throw new ArgumentNullException("Name of ingridient can't be null");
            if (weight <= 0) throw new ArgumentException("Weight of ingridient can't be less or equal zero");
            _ingridients.Add(name, weight);
        }
        public static (string, double) ParseIngridient(string ingLine)
        {
            string[] parts = ingLine.Split(", ");
            double weight = 0;
            if (parts.Length != 2 || !double.TryParse(parts[1], out weight)) throw new FormatException($"{ingLine} doesn't match format of ingridient: name, weight");
            return (parts[0], weight);
        }
    }
}
