using System.Diagnostics.Contracts;
using System.Net;
using BusyBee.Core.Exceptions;
using BusyBee.Core.Models.Common.Exceptions;
using FluentValidation.Results;

namespace BusyBee.Core.Interfaces.ExceptionFactories;

/// <summary>
///     Used to produce exceptions.
/// </summary>
public interface IExceptionFactory
{
    /// <summary>
    ///     Creates an exception from localized error message.
    /// </summary>
    /// <param name="localizedMessage">A localized exception message string.</param>
    /// <param name="localizedTitle">The localized exception title.</param>
    /// <param name="statusCode">The http status code of the exception.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    /// <returns>Created exception.</returns>
    [Pure]
    DomainException FromLocalized(
        string localizedMessage,
        string? localizedTitle = null,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        bool isUserFriendly = true);

    /// <summary>
    ///     Creates an exception from template message.
    /// </summary>
    /// <param name="message">A localized exception message string.</param>
    /// <param name="title">The localized exception title.</param>
    /// <param name="statusCode">The http status code of the exception.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    /// <returns>Created exception.</returns>
    [Pure]
    DomainException FromTemplate(
        TemplateString message,
        TemplateString title,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        bool isUserFriendly = true);

    /// <summary>
    ///     Creates an exception from localized error message.
    /// </summary>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <returns>Created exception.</returns>
    [Pure]
    NotFoundDomainException EntityNotFound<T>(bool isUserFriendly = true);

    /// <summary>
    ///     Creates an exception from localized error message.
    /// </summary>
    /// <param name="id">The entity id.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <returns>Created exception.</returns>
    [Pure]
    NotFoundDomainException EntityNotFound<T>(object id, bool isUserFriendly = true);

    /// <summary>
    ///     Creates an exception from localized error message.
    /// </summary>
    /// <param name="localizedMessage">A localized exception message string.</param>
    /// <param name="localizedTitle">The localized exception title.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    /// <returns>Created exception.</returns>
    [Pure]
    DomainConflictException Conflict(string localizedMessage, string? localizedTitle = null, bool isUserFriendly = true);

    /// <summary>
    ///     Creates an exception from localized error message.
    /// </summary>
    /// <param name="localizedMessage">A localized exception message string.</param>
    /// <param name="localizedTitle">The localized exception title.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    /// <returns>Created exception.</returns>
    [Pure]
    NotImplementedDomainException NotImplemented(string? localizedMessage = null, string? localizedTitle = null,
        bool isUserFriendly = true);

    /// <summary>
    ///     Creates an exception from localized error message.
    /// </summary>
    /// <param name="modelStateDictionary">
    ///     The model state dictionary containing validation errors. Keys are property names and values are error
    ///     messages.
    /// </param>
    /// <param name="localizedMessage">A localized exception message string.</param>
    /// <param name="localizedTitle">The localized exception title.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    /// <returns>Created exception.</returns>
    ValidationDomainException ValidationProblem(IDictionary<string, string[]> modelStateDictionary,
        string? localizedMessage = null,
        string? localizedTitle = null,
        bool isUserFriendly = true);

    /// <summary>
    ///     Creates an exception from localized error message.
    /// </summary>
    /// <param name="validationResult">
    ///     The result of validation.
    /// </param>
    /// <param name="localizedMessage">A localized exception message string.</param>
    /// <param name="localizedTitle">The localized exception title.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    /// <returns>Created exception.</returns>
    ValidationDomainException ValidationProblem(ValidationResult validationResult,
        string? localizedMessage = null,
        string? localizedTitle = null,
        bool isUserFriendly = true);

    /// <summary>
    ///     Creates an exception from localized error message.
    /// </summary>
    /// <param name="localizedMessage">A localized exception message string.</param>
    /// <param name="localizedTitle">The localized exception title.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    /// <returns>Created exception.</returns>
    ValidationDomainException ValidationProblem(
        string? localizedMessage = null,
        string? localizedTitle = null,
        bool isUserFriendly = true)
    {
        return ValidationProblem(new Dictionary<string, string[]>(), localizedMessage, localizedTitle, isUserFriendly);
    }
}