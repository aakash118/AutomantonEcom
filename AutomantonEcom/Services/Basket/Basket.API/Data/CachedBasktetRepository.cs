
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Data
{
    public class CachedBasktetRepository(IBasketRepository repository, IDistributedCache cache)
        : IBasketRepository
    {
        public async Task<bool> DeleteBasket(Guid guid, CancellationToken cancellationToken = default)
        {
            var result = await repository.DeleteBasket(guid, cancellationToken);
            await cache.RemoveAsync(guid.ToString(), cancellationToken);
            return result;
        }

        public async Task<IEnumerable<ShoppingCart>> GetBasket(string UserName, CancellationToken cancellationToken = default)
        {
            var cachedBasket = await cache.GetStringAsync(UserName, cancellationToken);
            if (cachedBasket is not null)
            {
                var basket = JsonConvert.DeserializeObject<IEnumerable<ShoppingCart>>(cachedBasket);               
                return basket!;
            }
            else
            {
                var result = await repository.GetBasket(UserName, cancellationToken);
                if (result is null)
                {
                    throw new BasketNotFoundException(UserName);
                }
                else
                {
                    await cache.SetStringAsync(UserName, JsonConvert.SerializeObject(result), cancellationToken);
                }
                return result;
            }
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart shoppingCart, CancellationToken cancellationToken = default)
        {
            var result = await repository.StoreBasket(shoppingCart, cancellationToken);
            await cache.SetStringAsync(shoppingCart.ID.ToString(), JsonConvert.SerializeObject(shoppingCart));
            return result;
        }
    }
}
