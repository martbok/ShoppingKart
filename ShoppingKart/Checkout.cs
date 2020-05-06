using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ShoppingKart.Repository;

namespace ShoppingKart
{
    public class Checkout
    {
        private readonly IRepository _repository;

        public Checkout(IRepository repository)
        {
            _repository = repository;
        }

        public decimal GetTotalPrice(IEnumerable<string> items)
        {
            Dictionary<string, int> basketItems = items.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            Discount discounts = _repository.GetDiscount();
            Dictionary<string, StockItem> itemPrices = _repository.GetItems();
            ValidateSkus(basketItems.Keys, new HashSet<string>(itemPrices.Keys));
            return discounts.ApplyDiscounts(basketItems) + basketItems.Sum(basketItem => basketItem.Value * itemPrices[basketItem.Key].Price);
        }

        private static void ValidateSkus(IEnumerable<string> basketItems, HashSet<string> allowedItems)
        {
            foreach (var basketItem in basketItems)
            {

                if (!allowedItems.Contains(basketItem))
                {
                    throw new Exception($"Sku {basketItem} does not exit.");
                }
            }
        }
    }
}
