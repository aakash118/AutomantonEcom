

namespace Catalog.API.Products.GetProductByID
{
    public record GetPoductIDByQuery(Guid ID) : IQuery<GetProductResult>;
    public record GetProductResult(Product Product);
    public class GetProductByIDHandler(IDocumentSession session) : IQueryHandler<GetPoductIDByQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetPoductIDByQuery request, CancellationToken cancellationToken)
        {
            var product = await session.Query<Product>().Where(x => x.ID == request.ID).FirstOrDefaultAsync();
            if (product is null)
            {
                throw new ProductNotFoundException();
            }

            return new GetProductResult(product!);
        }
    }
}
