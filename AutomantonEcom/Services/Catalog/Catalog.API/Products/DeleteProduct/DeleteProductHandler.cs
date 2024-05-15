
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid ID) : ICommand<Unit>;
    public class DeleteProductHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand>
    {
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            //var product = await session.Query<Product>().Where(x => x.ID == request.ID).FirstOrDefaultAsync();            
            session.Delete<Product>(request.ID);
            await session.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
