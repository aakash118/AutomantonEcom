namespace Catalog.API.Products.GetProduct
{
    public record GetProductQuery() : IQuery<GetProductQueryResult>;
    public record GetProductQueryResult(IReadOnlyList<Product> Products);

    public class GetProductHandler(IDocumentSession session) : IQueryHandler<GetProductQuery, GetProductQueryResult>
    {
        public async Task<GetProductQueryResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            //marten db operations
            var products = await session.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductQueryResult(products);
        }
    }


}
