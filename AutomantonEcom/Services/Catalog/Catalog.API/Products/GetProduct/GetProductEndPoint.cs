

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

        public record GetProductRequest(int? PageNumber = 1, int? PageSize = 10);
        public record GetAllProductQueryResult(IEnumerable<Product> Products);

        private async Task<GetAllProductQueryResult> GetAllProducts([AsParameters] GetProductRequest request, ISender sender)
        {
            var query = request.Adapt<GetProductQuery>();
            var result = await sender.Send(query);
            var response = result.Adapt<GetAllProductQueryResult>();
            return response;
        }
    }
}
