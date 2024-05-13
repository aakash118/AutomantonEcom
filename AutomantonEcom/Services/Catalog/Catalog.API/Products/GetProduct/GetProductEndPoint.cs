

using Catalog.API.Models;
using OpenTelemetry.Trace;
using System.Net;

namespace Catalog.API.Products.GetProduct
{
    public class GetProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", GetAllProducts)
                .WithDescription("Get all products")
                .WithDisplayName("Get products")
                .Produces(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithName("getallproducts");         
        }

        public record GetAllProductQueryResult(IReadOnlyList<Product> Products);

        private async Task<GetAllProductQueryResult> GetAllProducts(HttpContext context, ISender sender)
        {
            var result = await sender.Send(new GetProductQuery());
            var response = result.Adapt<GetAllProductQueryResult>();
            return response;
        }
    }
}
