using System.Globalization;
using System.Resources;

namespace BusyBee.Core.Extensions;

public static class LocalizationExtensions
{
    /// <summary>
    ///     Returns a localized resource if it is found. Otherwise returns fallback value. If fallback value is null returns a key.
    /// </summary>
    /// <param name="resourceManager">The resource manager to get string from.</param>
    /// <param name="key">A key of needed string.</param>
    /// <param name="fallback">
    ///     The value that will be returned if resource is not found.
    ///     If this value is not provided the key value is returned.
    /// </param>
    /// <param name="cultureInfo">The culture.</param>
    /// <returns>A localized string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="key" /> is null.</exception>
    public static string GetStringOrFallback(this ResourceManager resourceManager, string key, string? fallback = null,
        CultureInfo? cultureInfo = null)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentException(@"Value cannot be null or empty.", nameof(key));

        return resourceManager.GetString(key, cultureInfo) ?? fallback ?? key;
    }
}