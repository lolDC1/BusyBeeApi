using System.Linq.Expressions;

namespace BusyBee.Core.Common;

/// <summary>
///     An interface for entity composite key model.
/// </summary>
/// <typeparam name="TEntity">A type of the entity.</typeparam>
public interface IEntityCompositePrimaryKey<TEntity>
{
    /// <summary>
    ///     Gets an expression that performs a filtering by id of this entity.
    /// </summary>
    /// <returns>An expression for filtering.</returns>
    Expression<Func<TEntity, bool>> GetFilterById();
}