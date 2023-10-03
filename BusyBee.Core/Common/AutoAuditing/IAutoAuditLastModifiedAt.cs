namespace BusyBee.Core.Common.AutoAuditing;

/// <summary>
///     Gets or sets last entity modification timestamp.
/// </summary>
public interface IAutoAuditLastModifiedAt
{
    /// <summary>
    ///     Gets or sets last entity modification timestamp.
    /// </summary>
    DateTime? LastModifiedAt { get; set; }
}