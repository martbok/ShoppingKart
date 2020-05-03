namespace ShoppingKart.Repository
{
    public interface IRepository
    {
        public StockItem GetItem(string sku);
    }
}