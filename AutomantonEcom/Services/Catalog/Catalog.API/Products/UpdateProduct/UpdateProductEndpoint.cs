



namespace Catalog.API.Products.UpdateProduct
{
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", Update)
                .WithDescription("Update product")
                .WithDisplayName("Update product")
                .Produces(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithName("updateproduct");
        }

        public record UpdateProductRequest(Guid ID,
        string Name,
        List<string> Categories,
        string Description,
        string ImageFile,
        decimal Price);




        private async Task Update(UpdateProductRequest request, ISender sender)
        {
            //var command = request.Adapt<UpdateProductRequest, UpdateProductCommand>();
            var command = new UpdateProductCommand(request.ID,
                request.Name,
                request.Categories,
                request.Description,
                request.ImageFile,
                request.Price);

            await sender.Send(command);
        }
    }
}
