using Basket.API.Domain;

namespace Basket.API.Data
{
    public interface IBasketRepository
    {
        Task<IEnumerable<ShoppingCart>> GetBasket(string UserName, CancellationToken cancellationToken = default);
        Task<ShoppingCart> StoreBasket(ShoppingCart shoppingCart, CancellationToken cancellationToken = default);
        Task<bool> DeleteBasket(Guid guid, CancellationToken cancellationToken = default);
    }
}
