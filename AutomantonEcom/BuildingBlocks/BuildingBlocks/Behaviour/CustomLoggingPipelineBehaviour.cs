using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Behaviour
{
    public class CustomLoggingPipelineBehaviour<TRequest, TResponse>
        (ILogger<CustomLoggingPipelineBehaviour<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Need to make it pretty
            logger.LogInformation($"Request logged for {typeof(TRequest).GetType().Name}");            
            var response = await next();
            logger.LogInformation($"Response logged for {typeof(TResponse).GetType().Name} - {response}");
            return response;
        }
    }
}
