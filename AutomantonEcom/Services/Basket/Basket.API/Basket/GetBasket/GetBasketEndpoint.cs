
namespace Basket.API.Basket.GetBasket
{
    public class GetBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{username:alpha}", GetBasket);
        }

        //public record GetBasketRequest(string username);
        public record GetBasketResponse(IEnumerable<ShoppingCart> Cart);
        private async Task<GetBasketResponse> GetBasket(string username, ISender sender)
        {
            var result = await sender.Send(new GetBasketCartQuery(username));
            GetBasketResponse getBasketResponse = new(result.shoppingcart);
            return getBasketResponse;
        }
    }
}
