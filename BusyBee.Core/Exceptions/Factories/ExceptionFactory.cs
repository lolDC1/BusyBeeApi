using System.Diagnostics.Contracts;
using System.Net;
using BusyBee.Core.Extensions;
using BusyBee.Core.Interfaces.ExceptionFactories;
using BusyBee.Core.Localization;
using BusyBee.Core.Models.Common.Exceptions;
using FluentValidation.Results;

namespace BusyBee.Core.Exceptions.Factories;

/// <summary>
///     Used to produce exceptions.
/// </summary>
public class ExceptionFactory : IExceptionFactory
{
    /// <inheritdoc />
    public DomainException FromLocalized(string localizedMessage,
        string? localizedTitle = null,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        bool isUserFriendly = true)
    {
        if (localizedMessage == null) throw new ArgumentNullException(nameof(localizedMessage));
        localizedTitle ??= ErrorMessages.ErrorOccured;
        return new DomainException(localizedMessage, localizedTitle, statusCode, isUserFriendly);
    }

    /// <inheritdoc />
    [Pure]
    public NotFoundDomainException EntityNotFound<T>(bool isUserFriendly = true)
    {
        var localizedEntityName = nameof(T);
        var message = ErrorMessages.EntityNotFound.Format(localizedEntityName);
        var title = ErrorMessages.NotFound;
        return new NotFoundDomainException(message, title, isUserFriendly);
    }

    /// <inheritdoc />
    [Pure]
    public NotFoundDomainException EntityNotFound<T>(object id, bool isUserFriendly = true)
    {
        var localizedEntityName = EntityNames.ResourceManager.GetStringOrFallback(typeof(T).Name);
        var message = string.Format(localizedEntityName, id);
        var title = ErrorMessages.NotFound;
        return new NotFoundDomainException(message, title, isUserFriendly);
    }

    /// <inheritdoc />
    [Pure]
    public DomainException FromTemplate(TemplateString? message,
        TemplateString? title,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        bool isUserFriendly = true)
    {
        if (message == null || string.IsNullOrEmpty(message.Template)) throw new ArgumentNullException(nameof(message));
        if (title == null) throw new ArgumentNullException(nameof(title));

        var localizedMessage = EntityNames.ResourceManager.GetStringOrFallback(message.Template).Format(message.Args);
        var localizedTitle = EntityNames.ResourceManager.GetStringOrFallback(title.Template).Format(title.Args);
        return new DomainException(localizedMessage, localizedTitle, statusCode, isUserFriendly);
    }

    /// <inheritdoc />
    [Pure]
    public DomainConflictException Conflict(string? localizedMessage, string? localizedTitle = null, bool isUserFriendly = true)
    {
        localizedTitle ??= ErrorMessages.ConflictOccured;
        return new DomainConflictException(localizedMessage, localizedTitle, isUserFriendly);
    }

    /// <inheritdoc />
    [Pure]
    public NotImplementedDomainException NotImplemented(string? localizedMessage = null,
        string? localizedTitle = null,
        bool isUserFriendly = true)
    {
        localizedTitle ??= ErrorMessages.NotImplemented;
        return new NotImplementedDomainException(localizedMessage, localizedTitle, isUserFriendly);
    }

    /// <inheritdoc />
    public ValidationDomainException ValidationProblem(IDictionary<string, string[]> modelStateDictionary,
        string? localizedMessage = null,
        string? localizedTitle = null,
        bool isUserFriendly = true)
    {
        localizedMessage ??= ErrorMessages.ValidationErrorOccured;
        localizedTitle ??= ErrorMessages.ErrorOccured;
        return new ValidationDomainException(localizedMessage, localizedTitle, modelStateDictionary, isUserFriendly);
    }


    public ValidationDomainException ValidationProblem(ValidationResult validationResult,
        string? localizedMessage = null,
        string? localizedTitle = null,
        bool isUserFriendly = true)
    {
        var modelStateDictionary = validationResult.Errors.GroupBy(x => x.PropertyName, x => x.ErrorMessage)
            .ToDictionary(x => x.Key, x => x.ToArray());

        return ValidationProblem(modelStateDictionary, localizedMessage, localizedTitle, isUserFriendly);
    }
}