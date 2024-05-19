﻿



using static Basket.API.Basket.StoreBasket.StoreBasketEndpoint;

namespace Basket.API.Basket.StoreBasket
{
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", StoreBasket);
        }
        public record StoreBasketRequest(string username, List<ShoppingCartItem> items);

        public record StoreBasketResponse(ShoppingCart Cart);
        private async Task<StoreBasketResponse> StoreBasket(StoreBasketRequest cart, ISender sender)
        {
            var genratedcart = new ShoppingCart
            {
                UserName = cart.username,
                items = cart.items,
            };
            var request = new StoreBasketCommand(genratedcart);
            var response = await sender.Send(request);
            StoreBasketResponse storeBasketResponse = new(response.ShoppingCart);
            return storeBasketResponse;
        }
    }
}
