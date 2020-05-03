using System;
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

        public decimal GetTotalPrice(IEnumerable<string> shoppingItems)
        {
            var items = shoppingItems.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            var totalPrice = 0m;
            foreach (var item in items)
            {
                var stockItem = _repository.GetItem(item.Key);
                ValidateSku(stockItem, item);
                totalPrice += CalculateItemPrice(stockItem, item);
            }

            return totalPrice;
        }

        private static decimal CalculateItemPrice(StockItem stockItem, KeyValuePair<string, int> item)
        {
            var totalPrice = 0m;
            if (stockItem.ItemDiscount != null)
            {
                totalPrice += item.Value / stockItem.ItemDiscount.Quantity * stockItem.ItemDiscount.TotalPrice +
                              item.Value % stockItem.ItemDiscount.Quantity * stockItem.Price;
            }
            else
            {
                totalPrice += item.Value * stockItem.Price;
            }

            return totalPrice;
        }

        private static void ValidateSku(StockItem stockItem, KeyValuePair<string, int> item)
        {
            if (stockItem == null)
            {
                throw new Exception($"Sku {item.Key} does not exit.");
            }
        }
    }
}
