


using Discount.gRPC.API;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart ShoppingCart)
        : ICommand<StoreBasketResult>;
    public record StoreBasketResult(ShoppingCart ShoppingCart);
    public class StoreBasketHandler(IBasketRepository basketRepository, DiscountProtoService.DiscountProtoServiceClient ServiceClient)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.ShoppingCart.items)
            {
                var coupon = await ServiceClient.GetDiscountAsync(new GetDiscountRequest { Productname = item.ProductName }, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }
            var result = await basketRepository.StoreBasket(request.ShoppingCart);
            return new StoreBasketResult(result);
        }
    }
}
