
namespace Catalog.API.Products.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is empty");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is empty");
            RuleFor(x => x.Categories).NotEmpty().WithMessage("Catergories is empty");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("Imagefile is empty");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price is 0");
        }
    }
}
