
namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart ShoppingCart)
        : ICommand<StoreBasketResult>;
    public record StoreBasketResult(ShoppingCart ShoppingCart);
    public class StoreBasketHandler(IBasketRepository basketRepository) : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            var result = await basketRepository.StoreBasket(request.ShoppingCart);
            return new StoreBasketResult(result);
        }
    }
}
