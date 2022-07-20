using System;
using System.Globalization;

namespace SigmaCamp_HomeTask14
{
    static internal class ProductParsing
    {
        public static bool TryParseProduct(string line, out Product product)
        {
            string[] parts = line.Split(", ");
            switch (parts.Length)
            {
                case 3:
                    product = Parse(parts);
                    return true;
                case 4 when Char.IsDigit(parts[0][0]):
                    product = ParseMeatProduct(parts);
                    return true;
                case 4:
                    product = ParseDairyProduct(parts);
                    return true;
                default:
                    product = null;
                    return false;
            }
        }
        private static Product Parse(string[] parts)
        {
            decimal price;
            double weight;
            if (decimal.TryParse(parts[1], out price) && double.TryParse(parts[2], out weight))
            {
                return new Product(parts[0], price, weight);
            }
            throw new ArgumentException("Type of error: couldn't parse to product\n\tTime:" + DateTime.Now.ToString("r", CultureInfo.GetCultureInfo("en-US")));
        }
        public static Product ParseDairyProduct(string[] parts)
        {
            decimal price;
            double weight;
            int shelfLife;
            if (decimal.TryParse(parts[1], out price) && double.TryParse(parts[2], out weight) && int.TryParse(parts[3], out shelfLife))
            {
                return new DairyProducts(parts[0], price, weight, shelfLife);
            }
            throw new ArgumentException("Type of error:  couldn't parse to dairy product\n\tTime:" + DateTime.Now.ToString("r", CultureInfo.GetCultureInfo("en-US")));
        }
        public static Product ParseMeatProduct(string[] parts)
        {
            decimal price;
            double weight;
            if (decimal.TryParse(parts[0], out price) && double.TryParse(parts[1], out weight))
            {
                return new Meat(price, weight, parts[2], parts[3]);
            }
            throw new ArgumentException("Type of error:  couldn't parse to meat\n\tTime:" + DateTime.Now.ToString("r", CultureInfo.GetCultureInfo("en-US")));
        }
    }
}
