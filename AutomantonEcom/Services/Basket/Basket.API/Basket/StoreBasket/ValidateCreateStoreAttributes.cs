
namespace Basket.API.Basket.StoreBasket
{
    public class ValidateCreateStoreAttributes : AbstractValidator<StoreBasketCommand>
    {
        public ValidateCreateStoreAttributes()
        {
            RuleFor(x => x.ShoppingCart.UserName).NotEmpty().WithMessage("Name should not be empty.");
            //RuleFor(x => x.ShoppingCart.items).NotEmpty().WithMessage("Cart should not be empty.");
        }
    }
}
