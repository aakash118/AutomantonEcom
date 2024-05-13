

using Catalog.API.Models;

namespace Catalog.API.Products.GetProductByID
{
    public class GetProductByIDEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id:guid}", GetProductByID)
                .WithDescription("Get product")
                .WithDisplayName("Get product")
                .Produces(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)               
                .WithName("getproduct");
        }
        public record PoductIDByQuery(Guid ID);
        public record GetProductResponse(Product Product);
        private async Task<GetProductResponse> GetProductByID(HttpContext context, ISender sender, Guid id)
        {
            var result = await sender.Send(new GetPoductIDByQuery(id));
            var response = result.Adapt<GetProductResponse>();
            return response;
        }


    }
}
