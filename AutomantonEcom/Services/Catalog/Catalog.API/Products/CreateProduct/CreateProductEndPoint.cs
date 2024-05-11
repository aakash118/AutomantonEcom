using Microsoft.AspNetCore.Http;
using System.Net;

namespace Catalog.API.Products.CreateProduct
{
    public class CreateProductEndPoint : ICarterModule
    {
        public record CreateProductRequest(Guid ID,
        string Name,
        List<string> Categories,
        string Description,
        string ImageFile,
        decimal Price);

        public record CreateProductResponse(Guid ID);

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();
                var result = await sender.Send(command);
                
                CreateProductResponse response = new(result.ID);
                return Results.Created($"/products/{response.ID}", response);

            })
            .WithName("CreateProducts")
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create product")
            .WithDescription("Create product");
        }
    }
}
