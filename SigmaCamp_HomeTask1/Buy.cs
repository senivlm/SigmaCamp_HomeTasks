using System;

namespace SigmaCamp_HomeTask1
{
    internal class Buy
    {
        public static List<Buy> boughtProducts { get; }
        public Product ProductToBuy { get; private set; }
        private int _productQuantity;
        public decimal TotalPrice { get; private set; }
        public double ProductTotalWeight { get; private set; }
        public Buy(Product product, int quantity)
        {
            ProductToBuy = product;
            _productQuantity = quantity;
            TotalPrice = ProductToBuy.Price * quantity;
            ProductTotalWeight = ProductToBuy.Weight * quantity;
            boughtProducts.Add(this);
        }
        public int ProductQuantity
        {
            get { return _productQuantity; }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException("There is an incorrect value for product`s weight");
                }
                else
                {
                    _productQuantity=value;
                }
            }
        }
    }
}
