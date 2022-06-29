using System;
using System.Collections.Generic;
namespace SigmaCamp_HomeTask12_1
{
    internal class Buy
    {
        public Dictionary<Product, int> ProductsAndNumber { get; private set; }
        public Buy() 
        {
            ProductsAndNumber = new Dictionary<Product, int>();
        }
        public Buy(Product product, int quantity):base()
        {
            AddProduct(product, quantity);
        }
        public void AddProduct(Product product, int quantity = 1)
        {
            if (product == null || quantity <= 0)
            {
                throw new ArgumentException("Something wrong with your product or its quantity");
            }
            ProductsAndNumber.Add(product, quantity);
        }
        public decimal GetTotalPrice(Product product)
        {
            if (product == null )
            {
                throw new ArgumentException("Something wrong with your product");
            }
            if (ProductsAndNumber.ContainsKey(product))
            {
                return product.Price * ProductsAndNumber[product];
            }
            else
            {
                throw new ArgumentException("You don't add this product in shopping cart");
            }
        }
        public double GetTotalWeight(Product product)
        {
            if (product == null)
            {
                throw new ArgumentException("Something wrong with your product");
            }
            if (ProductsAndNumber.ContainsKey(product))
            {
                return product.Weight * ProductsAndNumber[product];
            }
            else
            {
                throw new ArgumentException("You don't add this product in shopping cart");
            }
        }
    }
}
