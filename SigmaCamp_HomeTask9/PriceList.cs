using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson14_06
{
    internal class PriceList
    {
        private static Dictionary<string, decimal> _currencyRates = new Dictionary<string, decimal>();
        private Dictionary<string, decimal> _productPrices;
        public PriceList()
        {
            _productPrices = new();
        }
        public PriceList(Dictionary<string, decimal> productPrice) : this()
        {
            _productPrices = productPrice;
        }
        public void AddPricedProduct(string name, decimal price)
        {
            if (name == null) throw new ArgumentNullException("Name of product can't be null");
            if (price <= 0) throw new ArgumentException("Price of ingridient can't be less or equal zero");
            _productPrices.Add(name, price);
        }
        public decimal? GetProductPrice(string productName)
        {
            if (!_productPrices.TryGetValue(productName, out decimal result))
            { 
                return null;
            }
            return result;
        }
        public static void AddCurrencyRate(string currencyName, decimal rate)
        {
            if (currencyName == null) throw new ArgumentNullException("Currency name can't be null");
            if (rate <= 0) throw new ArgumentException("Rate of currency can't be less or equal zero");
            _currencyRates.Add(currencyName, rate);
        }
        public static (string, decimal) ParseCurrencyRate(string line)
        {
            string[] parts = line.Split(" - ");
            decimal rate = 0;
            if (parts.Length != 2 || !decimal.TryParse(parts[1], out rate)) throw new FormatException($"{line} doesn't match format of currency rate: nameOfCurrency - price");
            return (parts[0], rate);
        }
        public static (string, decimal) ParsePrice(string line)
        {
            string[] parts = line.Split(" - ");
            decimal price = 0;
            if (parts.Length != 2 || !decimal.TryParse(parts[1], out price)) throw new FormatException($"{line} doesn't match format of product's price: nameOfProduct - price");
            return (parts[0], price);
        }
    }
}
