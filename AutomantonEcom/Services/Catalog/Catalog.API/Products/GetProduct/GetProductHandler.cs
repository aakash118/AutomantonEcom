
namespace Catalog.API.Products.GetProduct
{
    public record GetProductQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductQueryResult>;
    public record GetProductQueryResult(IPagedList<Product> Products);

    public class GetProductHandler(IDocumentSession session) : IQueryHandler<GetProductQuery, GetProductQueryResult>
    {
        public async Task<GetProductQueryResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            //marten db operations
            var products = await session.Query<Product>().ToPagedListAsync(request.PageNumber ?? 1, request.PageSize ?? 10, cancellationToken);
            return new GetProductQueryResult(products);
        }
    }
}
