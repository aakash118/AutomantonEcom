namespace Catalog.API.Products.DeleteProduct
{
    public class DeleteValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("Product ID cannot be null");
        }
    }
}
