
namespace Basket.API.Basket.DeleteBasket
{

    public record DeleteBasketQuery(Guid id) : IQuery<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);
    //public class ValidateDeleteQuery : AbstractValidator<DeleteBasketQuery>
    //{
    //    public ValidateDeleteQuery()
    //    {
    //        RuleFor(x => x.id).NotNull().WithMessage("ID should not be null for delete.");
    //    }
    //}
    public class DeleteBasketHandler(IBasketRepository basketRepository) : IQueryHandler<DeleteBasketQuery, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketQuery request, CancellationToken cancellationToken)
        {
            var response = await basketRepository.DeleteBasket(request.id,cancellationToken);
            return new DeleteBasketResult(response);
        }
    }
}
