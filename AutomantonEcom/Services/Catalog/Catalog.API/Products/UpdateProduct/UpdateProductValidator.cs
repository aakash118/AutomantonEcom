namespace Catalog.API.Products.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(command => command.ID)
                .NotEmpty()
                .WithMessage("Product ID is required.")
                .WithSeverity(Severity.Error);

            RuleFor(command => command.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(2).WithMessage("Minimum characters required is 2")
                .MaximumLength(150).WithMessage("Exceeding the maximum character length")
                .WithSeverity(Severity.Error);

            RuleFor(command => command.Categories)
                .NotEmpty()
                .WithMessage("Category list is empty");

            RuleFor(command => command.ImageFile)
                .NotNull()
                .NotEmpty()
                .WithMessage("Imagefile cannot be null or empty");

            RuleFor(command => command.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MinimumLength(20).WithMessage("Minimum characters required is 20")
                .MaximumLength(500).WithMessage("Exceeding the maximum character length")
                .WithSeverity(Severity.Error);

            RuleFor(command => command.Price)
                .GreaterThan(0)
                .WithMessage("Price must be grater then 0")
                .WithSeverity(Severity.Info);
        }
    }
}
