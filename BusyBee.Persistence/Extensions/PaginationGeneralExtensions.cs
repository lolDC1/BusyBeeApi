using BusyBee.Core.Interfaces.QueryParams;
using BusyBee.Core.Models.Common;

namespace BusyBee.Persistence.Extensions;

/// <summary>
///     A set of extension methods to work with <see cref="ISortedQueryParams" />.
/// </summary>
public static class PaginationGeneralExtensions
{
    /// <summary>
    ///     Returns a <paramref name="sortingDirection" /> it is determined and <paramref name="defaultSortingDirection" /> otherwise.
    /// </summary>
    /// <param name="sortingDirection">The sorting sortingDirection.</param>
    /// <param name="defaultSortingDirection">The default value of sorting direction.</param>
    /// <returns>Final sorting direction.</returns>
    public static SortingDirectionEnum DefaultIfNotSet(
        this SortingDirectionEnum sortingDirection,
        SortingDirectionEnum defaultSortingDirection = SortingDirectionEnum.NotSet)
    {
        return sortingDirection == SortingDirectionEnum.NotSet
            ? defaultSortingDirection
            : sortingDirection;
    }

    /// <summary>
    ///     Returns a <paramref name="sortingDirection" /> it is determined and <paramref name="defaultSortingDirection" /> otherwise.
    /// </summary>
    /// <param name="sortingDirection">The sorting sortingDirection.</param>
    /// <param name="defaultSortingDirection">The default value of sorting direction.</param>
    /// <returns>Final sorting direction.</returns>
    public static SortingDirectionEnum DefaultIfNotSet(
        this SortingDirectionEnum? sortingDirection,
        SortingDirectionEnum defaultSortingDirection = SortingDirectionEnum.NotSet)
    {
        return sortingDirection?.DefaultIfNotSet(defaultSortingDirection) ?? defaultSortingDirection;
    }
}