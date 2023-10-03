using System.Net;
using BusyBee.Core.Interfaces.Exceptions;
using BusyBee.Core.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BusyBee.Api.Middleware;

/// <summary>
///     Error handling middleware.
/// </summary>
public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ErrorHandlingMiddleware" /> class.
    /// </summary>
    /// <param name="next">Request delegate.</param>
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    ///     Invoked when received an http request.
    /// </summary>
    /// <param name="context">Current HTTP context.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var problemDetailsFactory = context.RequestServices.GetRequiredService<ProblemDetailsFactory>();
        var env = context.RequestServices.GetRequiredService<IWebHostEnvironment>();

        var statusCode = HttpStatusCode.InternalServerError;

        if (exception is IHttpStatusCodeSource statusCodeException)
            statusCode = statusCodeException.StatusCode;

        var modelStateDictionary = exception is IModelStateSource modelStateSource
            ? modelStateSource.ModelState
            : null;

        var title = exception is IErrorTitleSource titleSource
            ? titleSource.Title ?? ErrorMessages.ErrorOccured
            : ErrorMessages.ErrorOccured;

        var message = exception is IErrorMessageSource || env.IsDevelopment()
            ? exception.Message
            : null;

        ProblemDetails problemDetails;

        if (modelStateDictionary?.Any() == true)
        {
            var modelState = new ModelStateDictionary();
            foreach (var (propertyName, propertyErrorMessages) in modelStateDictionary)
            foreach (var errorMessage in propertyErrorMessages)
                modelState.AddModelError(propertyName, errorMessage);

            problemDetails =
                problemDetailsFactory.CreateValidationProblemDetails(context, modelState, (int?)statusCode, title, null, message);
        }
        else
        {
            problemDetails = problemDetailsFactory.CreateProblemDetails(context, (int?)statusCode, title, null, message);
        }


        var isUserFriendly = exception is IUserFriendlinessSource { IsUserFriendly: true };

        problemDetails.Extensions.Add("isUserFriendly", isUserFriendly);

        if (!isUserFriendly)
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<ErrorHandlingMiddleware>>();
            logger.LogError(exception, exception.Message);
        }

        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsJsonAsync((object)problemDetails, context.RequestAborted);
    }
}