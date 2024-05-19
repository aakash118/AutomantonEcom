using Basket.API.Domain;
using BuildingBlocks.CQRS;
using MediatR;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketCartQuery(string username)
        : IQuery<GetBasketCartResult>;
    public record GetBasketCartResult(IEnumerable<ShoppingCart> shoppingcart);
    public class GetBasketHandler(IBasketRepository basketRepository) : IQueryHandler<GetBasketCartQuery, GetBasketCartResult>
    {
        public async Task<GetBasketCartResult> Handle(GetBasketCartQuery request, CancellationToken cancellationToken)
        {
            var result = await basketRepository.GetBasket(request.username);
            return new GetBasketCartResult(result);
        }
    }
}
