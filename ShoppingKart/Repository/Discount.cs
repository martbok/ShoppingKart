using System.Collections.Generic;
using System.Linq;

namespace ShoppingKart.Repository
{
    public class Discount
    {
        public List<ItemDiscount> Discounts { get; set; }

        private int FindBiggestDiscount(Dictionary<string, int> items, IEnumerable<ItemDiscount> availableDiscounts)
        {
            var maxDiscount = 0m;
            var discountId = -1;
            foreach (var discount in availableDiscounts)
            {
                var discountValue = discount.CalculateMaximumDiscount(items);
                if (discountValue > maxDiscount)
                {
                    maxDiscount = discountValue;
                    discountId = discount.DiscountId;
                }
            }

            return discountId;
        }

        public decimal ApplyDiscounts(Dictionary<string, int> items)
        {
            HashSet<int> availableDiscounts = new HashSet<int>(Discounts.Select(x => x.DiscountId));;
            var totalPrice = 0m;

            while (availableDiscounts.Count > 0)
            {
                var discountId = FindBiggestDiscount(items, Discounts.Where(x => availableDiscounts.Contains(x.DiscountId)));
                if (discountId == -1)
                {
                    break;
                }

                totalPrice += Discounts.Single(x =>x.DiscountId == discountId).ApplyMaximumDiscount(items);
                availableDiscounts.Remove(discountId);
            }

            return totalPrice;
        }
    }
}
