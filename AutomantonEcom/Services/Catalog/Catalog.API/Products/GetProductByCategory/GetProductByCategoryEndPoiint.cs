

using Catalog.API.Models;

namespace Catalog.API.Products.GetProductByCategory
{
    public class GetProductByCategoryEndPoiint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{category:alpha}", GetProductsByCategory)
                .WithDescription("Get product by category")
                .WithDisplayName("Get product by category")
                .Produces(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithName("getproductbycategory"); 
        }
        public record GetProductresultCategory(IReadOnlyList<Product> Product);
        private async Task<GetProductresultCategory> GetProductsByCategory(HttpContext context, ISender sender, string category)
        {
            var result = await sender.Send(new GetProductCategoryQuery(category));
            var response = result.Adapt<GetProductresultCategory>();
            return response;
        }
    }
}
