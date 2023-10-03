using BusyBee.Core.Interfaces.Services;

namespace BusyBee.Persistence;

/// <summary>
///     An implementation for <see cref="IDateTimeService" /> that works with local machine date and time.
/// </summary>
public class DateTimeService : IDateTimeService
{
    /// <inheritdoc />
    public long Timestamp => new DateTimeOffset(NowUtc).ToUnixTimeSeconds();

    /// <inheritdoc />
    public DateTime Now => DateTime.Now;

    /// <inheritdoc />
    public DateTime NowUtc => DateTime.UtcNow;
}