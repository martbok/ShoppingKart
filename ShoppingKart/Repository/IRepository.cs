using System.Collections.Generic;

namespace ShoppingKart.Repository
{
    public interface IRepository
    {
        public Dictionary<string, StockItem> GetItems();
        public Discount GetDiscount();
    }
}