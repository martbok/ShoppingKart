namespace ShoppingKart.Repository
{
    public class StockItem
    {
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public ItemDiscount ItemDiscount { get; set; }
    }
}
