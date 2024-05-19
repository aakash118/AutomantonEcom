﻿

namespace Basket.API.Basket.DeleteBasket
{
    public class DeleteBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{id:guid}", DeleteBasket);
        }

       
        public record DeleteBasketResponse(bool IsSuccess);

        private async Task<DeleteBasketResponse> DeleteBasket(Guid id, ISender sender)
        {
            var result = await sender.Send(new DeleteBasketQuery(id));
            DeleteBasketResponse response = new(result.IsSuccess);
            return response;
        }
    }
}
