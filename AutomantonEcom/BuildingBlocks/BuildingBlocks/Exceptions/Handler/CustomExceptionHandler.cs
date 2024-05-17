using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace BuildingBlocks.Exceptions.Handler
{
    public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            logger.LogInformation($"Exception type - {exception.GetType().Name} and error is{exception.Message}, error occured at {DateTime.UtcNow}");
            (string Detail, string Title, int StatusCode) details = exception switch
            {

                NotFoundException =>
                (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound
                ),
                ValidationException =>
                (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode
                ),
                _ =>
                (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError
                )
            };
            //var problemdetails = ProblemDetails{

            //}

            var exceptionDetails = new ExceptionDetails
            {
                Detail = details.Detail,
                StatusCode = details.StatusCode,
                Title = details.Title,
                Instance = httpContext.Request.Path
            };

            exceptionDetails.Extensions!.Add("traceid", httpContext.TraceIdentifier);
            if (exception is ValidationException validationException)
            {
                exceptionDetails.Extensions.Add("validationErrors", validationException.Errors);
            }
            await httpContext.Response.WriteAsJsonAsync(exceptionDetails, cancellationToken);
            return true;
        }
    }
}
