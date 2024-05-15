

namespace Catalog.API.Products.DeleteProduct
{
    public class DeleteProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id:guid}", DeleteProduct)
                .WithDescription("Delete product")
                .WithDisplayName("Delete product")
                .Produces(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithName("deleteproduct");
        }

        public record DeleteProductResponse(Guid ID);

        private async Task DeleteProduct(Guid id, ISender sender)
        {
            await sender.Send(new DeleteProductCommand(id));
        }
    }
}
