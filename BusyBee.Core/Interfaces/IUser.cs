namespace BusyBee.Core.Interfaces;

/// <summary>
///     Represents a base information about current user.
/// </summary>
public interface IUser
{
    /// <summary>A user claims.</summary>
    Dictionary<string, string> Claims { get; }

    /// <summary>
    /// Gets a name of current user.
    /// </summary>
    // string DisplayName { get; }

    /// <summary>
    ///     Gets an id of current user.
    /// </summary>
    Guid UserId { get; }
}