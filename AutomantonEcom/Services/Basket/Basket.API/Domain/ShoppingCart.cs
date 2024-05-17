namespace Basket.API.Domain
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = default!;
        public List<ShoppingCartItem> items { get; set; } = new();
        public decimal Price => items.Sum(i => i.Price);//Need to rebuild this logic
        private ShoppingCart(string username)
        {
            UserName = username;
        }
        public ShoppingCart()
        {
        }
    }
}
