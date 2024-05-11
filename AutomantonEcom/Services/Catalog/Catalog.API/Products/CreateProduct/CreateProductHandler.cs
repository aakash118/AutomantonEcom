﻿using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Products.CreateProduct
{

    public record CreateProductCommand(Guid ID,
        string Name,
        List<string> Categories,
        string Description,
        string ImageFile,
        decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid ID);
    public class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Categories = command.Categories,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            //DB operations

            session.Store(product);
            await session.SaveChangesAsync();
           
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
