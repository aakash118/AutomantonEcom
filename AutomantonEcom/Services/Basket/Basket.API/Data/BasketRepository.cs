
namespace Basket.API.Data
{
    public sealed class BasketRepository(IDocumentSession session) : IBasketRepository
    {

        public async Task<IEnumerable<ShoppingCart>> GetBasket(string UserName, CancellationToken cancellationToken = default)
        {
            var basket = await session.Query<ShoppingCart>().Where(x => x.UserName == UserName).ToListAsync();
            if (basket is null || basket.Count is 0)
            {
                throw new BasketNotFoundException(UserName);
            }
            return basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart shoppingCart, CancellationToken cancellationToken = default)
        {
            session.Store(shoppingCart);
            await session.SaveChangesAsync(cancellationToken);
            return shoppingCart;
        }
        public async Task<bool> DeleteBasket(Guid guid, CancellationToken cancellationToken = default)
        {
            session.Delete<ShoppingCart>(guid);
            await session.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}
