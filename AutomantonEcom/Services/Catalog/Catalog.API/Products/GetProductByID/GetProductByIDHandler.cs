﻿using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Catalog.API.Products.GetProduct;
using Marten;

namespace Catalog.API.Products.GetProductByID
{
    public record GetPoductIDByQuery(Guid ID) : IQuery<GetProductResult>;
    public record GetProductResult(Product Product);
    public class GetProductByIDHandler(IDocumentSession session) : IQueryHandler<GetPoductIDByQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetPoductIDByQuery request, CancellationToken cancellationToken)
        {
            var product = await session.Query<Product>().Where(x => x.ID == request.ID).FirstOrDefaultAsync();
            return new GetProductResult(product!);
        }
    }
}