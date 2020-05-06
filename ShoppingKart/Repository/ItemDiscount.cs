using System.Collections.Generic;
using System.Linq;

namespace ShoppingKart.Repository
{
    public class ItemDiscount
    {
        public int DiscountId;

        public Dictionary<string, int> Discounts { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal CalculateMaximumDiscount(Dictionary<string, int> items)
        {
            return CalculateDiscountableItems(items) * TotalPrice;
        }

        public decimal ApplyMaximumDiscount(Dictionary<string, int> items)
        {
            var availableDiscountCount = CalculateDiscountableItems(items);

            var discountableSkus = items.Keys.Where(item => Discounts.ContainsKey(item)).ToList();
            foreach (var item in discountableSkus)
            {
                items[item] -= Discounts[item] * availableDiscountCount;
            }

            return availableDiscountCount * TotalPrice;
        }

        private int CalculateDiscountableItems(Dictionary<string, int> items)
        {
            var availableDiscountCount = int.MaxValue;
            foreach (var discountItem in Discounts)
            {
                if (items.ContainsKey(discountItem.Key))
                {
                    var discountCount = items[discountItem.Key] / discountItem.Value;
                    if (availableDiscountCount > discountCount)
                    {
                        availableDiscountCount = discountCount;
                    }
                }
                else
                {
                    availableDiscountCount = 0;
                }
            }

            return availableDiscountCount;
        }
    }
}
