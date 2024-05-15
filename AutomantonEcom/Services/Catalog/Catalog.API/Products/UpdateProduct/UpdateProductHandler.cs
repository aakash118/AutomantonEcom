

namespace Catalog.API.Products.UpdateProduct
{

    public record UpdateProductCommand(Guid ID,
        string Name,
        List<string> Categories,
        string Description,
        string ImageFile,
        decimal Price) : ICommand<Unit>;




    public class UpdateProductHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand>
    {        
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ID = request.ID,
                Name = request.Name,
                Categories = request.Categories,
                Description = request.Description,
                ImageFile = request.ImageFile,
                Price = request.Price,

            };
            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
