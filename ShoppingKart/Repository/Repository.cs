using System.Collections.Generic;

namespace ShoppingKart.Repository
{
    public class Repository : IRepository
    {
        private Dictionary<string, StockItem> _stock;

        public Repository(Dictionary<string, StockItem> stock)
        {
            _stock = stock;
        }

        public Repository()
        {
            _stock = new Dictionary<string, StockItem>()
            {
                { "A", new StockItem() { Sku = "A", Price = 5m , ItemDiscount = new ItemDiscount() { Quantity = 3, TotalPrice = 13m  } } },
                { "B", new StockItem() { Sku = "A", Price = 3m , ItemDiscount = new ItemDiscount() { Quantity = 2, TotalPrice = 4.5m } } },
                { "C", new StockItem() { Sku = "A", Price = 2m } },
                { "D", new StockItem() { Sku = "A", Price = 1.5m } }
            };
        }

        public StockItem GetItem(string sku)
        {
            return _stock.ContainsKey(sku) ? _stock[sku] : null;
        }
    }
}
