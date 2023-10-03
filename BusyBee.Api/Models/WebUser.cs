using BusyBee.Core.Interfaces;

namespace BusyBee.Api.Models;

/// <summary>
///     Represents a user that came from API.
/// </summary>
public class WebUser : IUser
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="WebUser" /> class.
    ///     Represents a user that came from API.
    /// </summary>
    /// <param name="userId">An id of the user.</param>
    /// <param name="displayName">A name of the user.</param>
    /// <param name="claims">A user claims.</param>
    public WebUser(Guid userId, Dictionary<string, string> claims)
    {
        UserId = userId;
        Claims = claims;
    }

    /// <summary>An id of the user in form of string.</summary>
    public Guid UserId { get; }

    /// <summary>A name of the user.</summary>
    // public string DisplayName { get; }

    /// <summary>A user claims.</summary>
    public Dictionary<string, string> Claims { get; }
}