using ApplicationLayer.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var (statusCode, title) = context.Exception switch
        {
            KeyNotFoundException => (StatusCodes.Status404NotFound, "Resource not found"),
            DuplicateHolidayNameException => (StatusCodes.Status409Conflict, "Conflict"),
            ArgumentException => (StatusCodes.Status400BadRequest, "Bad request"),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
        };

        context.Result = new ObjectResult(new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = context.Exception.Message,
            Instance = context.HttpContext.Request.Path
        })
        {
            StatusCode = statusCode
        };

        context.ExceptionHandled = true;
    }
}
