namespace BusyBee.Core.Interfaces.Services;

/// <summary>
///     Represents a main way in the app to access Date and Time.
///     Can be mocked for unit tests.
/// </summary>
public interface IDateTimeService
{
    /// <summary>
    ///     Gets current date and time.
    /// </summary>
    DateTime Now { get; }

    /// <summary>
    ///     Gets current date and time in UTC timezone.
    /// </summary>
    DateTime NowUtc { get; }

    /// <summary>
    ///     Gets current timestamp.
    /// </summary>
    long Timestamp { get; }

    /// <summary>
    ///     Gets current date.
    /// </summary>
    DateTime Today => Now.Date;

    /// <summary>
    ///     Gets current date in UTC timezone.
    /// </summary>
    DateTime TodayUtc => NowUtc.Date;
}