using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviour
{
    public class CustomValidationPipelineBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var content = new ValidationContext<TRequest>(request);
            var validationresults =
                await Task.WhenAll(validators.Select(x => x.ValidateAsync(content, cancellationToken)));
            var validationerrors = validationresults.Where(x => x.Errors.Any()).SelectMany(x => x.Errors).ToList();
            if (validationerrors.Count > 0)
            {
                throw new ValidationException(validationerrors);
            }
            return await next();
        }
    }
}
