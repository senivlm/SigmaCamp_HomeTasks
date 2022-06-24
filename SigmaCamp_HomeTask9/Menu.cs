using System;
using System.Collections.Generic;
using System.Linq;

namespace lesson14_06
{
    internal class Menu
    {
        private List<Dish> _dishes;
        public Menu()
        {
            _dishes = new List<Dish>();
        }
        public Menu(List<Dish> dishes) : this()
        {
            _dishes = dishes;
        }
        public Dish this[int index]
        {
            get => _dishes[index];  
        }
        public int Length => _dishes.Count;
        public void AddDish(Dish dish)
        {
            if (dish == null) throw new ArgumentNullException("Dish can't be null");
            _dishes.Add(dish);
        }
        public decimal? GetMenuTotalSum(PriceList priceKurant)
        {
            decimal? menuTotalSum = default;
            for (int i = 0; i < _dishes.Count; i++)
            {
                menuTotalSum += GetDishPrice(_dishes[i], priceKurant);
            }
            return menuTotalSum;
        }
        public decimal? GetDishPrice(Dish dish, PriceList priceKurant)
        {
            decimal? sumPrice = default;
            foreach (string key in dish.Keys)
            {
                sumPrice += priceKurant?.GetProductPrice(key) * (decimal)dish[key];
            }
            return sumPrice;
        }
    }
}
