using System;

namespace SigmaCamp_HomeTask14
{
    internal class Check
    {
        public Check() { }
        public void PrintCheck(Buy productsToBuy)
        {
            foreach (var purchase in productsToBuy.ProductsAndNumber)
            {
                Console.WriteLine($"{purchase.Key}, Quantity: {purchase.Value}, " +
                    $"TotalPrice: {productsToBuy.GetTotalPrice(purchase.Key)}, TotalWeight: {productsToBuy.GetTotalWeight(purchase.Key)}");
            }
        }
    }
}
