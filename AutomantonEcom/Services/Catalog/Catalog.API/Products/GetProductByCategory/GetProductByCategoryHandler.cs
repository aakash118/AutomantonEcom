using BuildingBlocks.CQRS;
namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductCategoryQuery(string Category) : IQuery<GetProductresultByCategory>;
    public record GetProductresultByCategory(IReadOnlyList<Product> Product);
    public class GetProductByCategoryHandler(IDocumentSession session) : IQueryHandler<GetProductCategoryQuery, GetProductresultByCategory>
    {
        public async Task<GetProductresultByCategory> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().Where(x => x.Categories.Contains(request.Category)).ToListAsync();
            return new GetProductresultByCategory(products);
        }
    }
}
