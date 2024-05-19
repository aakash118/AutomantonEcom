namespace Basket.API.Domain
{
    public class ShoppingCart
    {
        public Guid ID { get; set; }
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> items { get; set; } = new();
        public decimal Price => items.Sum(i => i.Price * i.Quantity);
        private ShoppingCart(string username)
        {
            UserName = username;
        }
        public ShoppingCart()
        {
        }
    }
}
