using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaCamp_HomeTask8_3
{
    internal class ProductEqualityComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product product1, Product product2)
        {
            if (product1 == null && product2 == null)
            {
                return true;
            }
            if (product1 == null)
            {
                return false;
            }
            if (product1 is Meat)
            {
                return ((Meat)product1).Equals(product2);
            }
            if (product1 is DairyProducts)
            {
                return ((DairyProducts)product1).Equals(product2);
            }
            return product1.Equals(product2);
        }

        public int GetHashCode(Product product)
        {
            return product.GetHashCode();
        }
    }
}
