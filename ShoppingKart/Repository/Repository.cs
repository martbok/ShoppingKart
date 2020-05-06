using System.Collections.Generic;

namespace ShoppingKart.Repository
{
    public class Repository : IRepository
    {
        private Dictionary<string, StockItem> _stock;

        private Discount _discount;

        public Repository(Dictionary<string, StockItem> stock)
        {
            _stock = stock;
        }

        public Repository()
        {
            _stock = new Dictionary<string, StockItem>()
            {
                { "A", new StockItem() { Sku = "A", Price = 5m } },
                { "B", new StockItem() { Sku = "B", Price = 3m  } },
                { "C", new StockItem() { Sku = "C", Price = 2m } },
                { "D", new StockItem() { Sku = "D", Price = 1.5m } }
            };

            _discount = new Discount()
            {
                Discounts = new List<ItemDiscount>()
                {
                    new ItemDiscount()
                    {
                        DiscountId = 0,
                        Discounts = new Dictionary<string, int>()
                        {
                            {"A", 2},
                            {"B", 1}
                        },
                        TotalPrice = 11m

                    },
                    new ItemDiscount()
                    {
                        DiscountId = 1,
                        Discounts = new Dictionary<string, int>()
                        {
                            {"A", 3}
                        },
                        TotalPrice = 13m

                    },
                    new ItemDiscount()
                    {
                        DiscountId = 2,
                        Discounts = new Dictionary<string, int>()
                        {
                            {"B", 2}
                        },
                        TotalPrice = 4.5m

                    }
                }
            };
        }

        public Dictionary<string, StockItem> GetItems()
        {
            return _stock;
        }

        public Discount GetDiscount()
        {
            return _discount;
        }
    }
}