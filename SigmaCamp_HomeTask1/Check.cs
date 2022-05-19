using System;

namespace SigmaCamp_HomeTask1
{
    internal class Check
    {
        public Check() { }
        public void PrintCheck(params Buy[] boughtProducts)
        {
            foreach (var purchase in boughtProducts)
            {
                Console.WriteLine(purchase.ProductQuantity + " " + purchase.ProductToBuy.Name + ", " + purchase.TotalPrice + "UAH;");
            }
        }
    }
}
