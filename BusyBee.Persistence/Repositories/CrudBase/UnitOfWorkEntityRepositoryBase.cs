using System.Linq.Expressions;
using BusyBee.Core.Common;
using BusyBee.Core.Interfaces.QueryParams;
using BusyBee.Core.Interfaces.Repositories.Base;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Common.Repositories;
using BusyBee.Core.Models.Common.Repositories.Result;
using BusyBee.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

#pragma warning disable SA1402

namespace BusyBee.Persistence.Repositories.CrudBase;

/// <inheritdoc />
public abstract class UnitOfWorkEntityRepositoryBase<TEntity> : UnitOfWorkEntityRepositoryBase<TEntity, Guid>
    where TEntity : class, IEntity<Guid>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOfWorkEntityRepositoryBase{TEntity}" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    protected UnitOfWorkEntityRepositoryBase(DatabaseContext context, RepositoryCommonDependencies dependencies) :
        base(context, dependencies)
    {
    }
}

/// <inheritdoc />
public class
    UnitOfWorkEntityRepositoryBase<TEntity, TPrimaryKey> : UnitOfWorkEntityRepositoryBase<TEntity, TPrimaryKey, DatabaseContext>
    where TEntity : class, IEntity<TPrimaryKey> where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOfWorkEntityRepositoryBase{TEntity,TPrimaryKey}" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    protected UnitOfWorkEntityRepositoryBase(DatabaseContext context, RepositoryCommonDependencies dependencies) :
        base(context, dependencies)
    {
    }
}

/// <summary>
///     Provides overridable CRUD actions for entity.
/// </summary>
/// <typeparam name="TEntity">The type of data to work with.</typeparam>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TContext">The context type.</typeparam>
public class
    UnitOfWorkEntityRepositoryBase<TEntity, TPrimaryKey, TContext> : UnitOfWorkEntityRepositoryBase<TEntity, TPrimaryKey, TContext,
        IListItem<TPrimaryKey>> where TEntity : class, IEntity<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TContext : DbContext
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOfWorkEntityRepositoryBase{TEntity, TPrimaryKey, TContext}" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    protected UnitOfWorkEntityRepositoryBase(TContext context, RepositoryCommonDependencies dependencies) : base(
        context,
        dependencies)
    {
    }
}

/// <summary>
///     Provides overridable CRUD actions for entity.
/// </summary>
/// <typeparam name="TEntity">The type of data to work with.</typeparam>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TContext">The context type.</typeparam>
/// <typeparam name="TAutocomplete">The type used for autocomplete.</typeparam>
public class UnitOfWorkEntityRepositoryBase<TEntity, TPrimaryKey, TContext, TAutocomplete> :
    UnitOfWorkEntityRepositoryBase<TEntity, TPrimaryKey, TContext, TAutocomplete, IQueryParams<TPrimaryKey>>
    where TEntity : class, IEntity<TPrimaryKey> where TPrimaryKey : IEquatable<TPrimaryKey> where TContext : DbContext
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOfWorkEntityRepositoryBase{TEntity, TPrimaryKey, TContext}" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    protected UnitOfWorkEntityRepositoryBase(TContext context, RepositoryCommonDependencies dependencies) : base(
        context,
        dependencies)
    {
    }
}

/// <summary>
///     Provides overridable CRUD actions for entity.
/// </summary>
/// <typeparam name="TEntity">The type of data to work with.</typeparam>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TContext">The context type.</typeparam>
/// <typeparam name="TQueryParams">A model used to specify custom filters or other criteria for querying.</typeparam>
/// <typeparam name="TAutocomplete">The type used for autocomplete.</typeparam>
public class UnitOfWorkEntityRepositoryBase<TEntity, TPrimaryKey, TContext, TAutocomplete, TQueryParams> :
    UnitOfWorkEntityRepositoryBase<TEntity, TPrimaryKey, TContext, TAutocomplete, TQueryParams, AccessRightsPolicyParams>
    where TEntity : class, IEntity<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TContext : DbContext
    where TQueryParams : IQueryParams<TPrimaryKey>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOfWorkEntityRepositoryBase{TEntity, TPrimaryKey, TContext}" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    protected UnitOfWorkEntityRepositoryBase(TContext context, RepositoryCommonDependencies dependencies) : base(
        context,
        dependencies)
    {
    }
}

/// <summary>
///     Provides overridable CRUD actions for entity.
/// </summary>
/// <typeparam name="TEntity">The type of data to work with.</typeparam>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TContext">The context type.</typeparam>
/// <typeparam name="TAutocomplete">The type used for autocomplete.</typeparam>
/// <typeparam name="TQueryParams">A model used to specify custom filters or other criteria for querying.</typeparam>
/// <typeparam name="TAccessRightsPolicyParams"></typeparam>
public class UnitOfWorkEntityRepositoryBase<TEntity, TPrimaryKey, TContext, TAutocomplete, TQueryParams, TAccessRightsPolicyParams> :
    UnitOfWorkRepositoryBase<TEntity, TContext, TQueryParams, TAccessRightsPolicyParams>,
    IEntityRepository<TEntity, TPrimaryKey, TAutocomplete, TQueryParams, TAccessRightsPolicyParams>
    where TEntity : class, IEntity<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TContext : DbContext
    where TQueryParams : IQueryParams<TPrimaryKey>
    where TAccessRightsPolicyParams : AccessRightsPolicyParams
{
    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="UnitOfWorkEntityRepositoryBase{TEntity, TPrimaryKey, TContext, TAutocomplete,TQueryParams}" />
    ///     class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    protected UnitOfWorkEntityRepositoryBase(TContext context, RepositoryCommonDependencies dependencies) : base(
        context,
        dependencies)
    {
    }

    /// <inheritdoc />
    protected override Expression<Func<TEntity, object?>> DefaultSortingSelector { get; } = x => x.Id;

    /// <inheritdoc />
    /// <returns>A tuple with two values - entity and primary key accessor.</returns>
    public new async Task<CreateEntityResult<TEntity, TPrimaryKey>> CreateAsync(TEntity entity,
        CancellationToken token = default)
    {
        var entityEntry = await base.CreateAsync(entity, token);

        var idProperty = Context.Entry(entityEntry).Property(x => x.Id);
        var valueAccessor = new ValueAccessor<TPrimaryKey>(() => idProperty.CurrentValue);

        return new CreateEntityResult<TEntity, TPrimaryKey>(entityEntry, valueAccessor);
    }

    /// <inheritdoc />
    public virtual async Task<TEntity?> GetByIdAsync(TPrimaryKey id, RepositoryQueryOptions<TAccessRightsPolicyParams>? options = null,
        CancellationToken token = default)
    {
        var queryById = await QueryByIdAsync(id, options);
        var result = await queryById.SingleOrDefaultAsync(token);

        if (options?.Required is true && result is null)
            throw ExceptionFactory.EntityNotFound<TEntity>(id);

        return result;
    }

    /// <inheritdoc />
    public virtual async Task<T?> GetByIdProjectedAsync<T>(TPrimaryKey id,
        RepositoryQueryOptions<TAccessRightsPolicyParams>? options = null,
        CancellationToken token = default)
    {
        var queryById = await QueryByIdAsync(id, options);

        var projectedQuery = await HandleProjectionAsync<T>(queryById);
        var result = await projectedQuery.SingleOrDefaultAsync(token);

        if (options?.Required == true && result == null)
            throw ExceptionFactory.EntityNotFound<TEntity>(id);

        return result;
    }

    /// <inheritdoc />
    public virtual async Task<bool> ExistsAsync(TPrimaryKey id, CancellationToken token = default)
    {
        var queryById = await QueryByIdAsync(id);
        return await queryById.AnyAsync(token);
    }

    public async Task<List<TPrimaryKey>> ExistsManyAsync(ICollection<TPrimaryKey> ids,
        CancellationToken token = default)
    {
        if (ids == null) throw new ArgumentNullException(nameof(ids));

        var query = await GetBaseQueryAsync(token: token);
        query = await ApplyFilterByIdAsync(query, ids as TPrimaryKey[] ?? ids.ToArray());
        var existingIds = await query.Select(x => x.Id).ToListAsync(token);
        return existingIds;
    }

    /// <inheritdoc />
    public async Task MustExistsAsync(TPrimaryKey id, CancellationToken token = default)
    {
        if (!await ExistsAsync(id, token)) throw ExceptionFactory.EntityNotFound<TEntity>(id);
    }

    /// <inheritdoc />
    public Task<PagedResult<TAutocomplete>> AutocompleteAsync(TQueryParams? request, CancellationToken token = default)
    {
        return GetProjectedAsync<TAutocomplete>(request, token: token);
    }

    protected override async Task<IQueryable<TEntity>> ApplyFilteringAsync(IQueryable<TEntity> query,
        TQueryParams? request,
        CancellationToken token = default)
    {
        if (request?.Ids?.Any() == true)
            query = await ApplyFilterByIdAsync(query, request.Ids);

        return await base.ApplyFilteringAsync(query, request, token);
    }

    /// <summary>
    ///     Applies filtering by id of provided query.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="ids">An id of the desired entity.</param>
    /// <returns>A new query with applied filter by id.</returns>
    /// <exception cref="ArgumentNullException">Some of provided parameter was null or default.</exception>
    protected virtual ValueTask<IQueryable<TEntity>> ApplyFilterByIdAsync(IQueryable<TEntity> query, params TPrimaryKey[] ids)
    {
        if (query == null)
            throw new ArgumentNullException(nameof(query));

        return new ValueTask<IQueryable<TEntity>>(query.FilterById(ids));
    }

    /// <summary>
    ///     Returns a query with applied filtering by provided id.
    /// </summary>
    /// <param name="id">The id of requested entity.</param>
    /// <param name="options">An options for the query.</param>
    /// <returns>An query for the entity with specified id.</returns>
    protected virtual async Task<IQueryable<TEntity>> QueryByIdAsync(TPrimaryKey id,
        RepositoryQueryOptions<TAccessRightsPolicyParams>? options = null)
    {
        options = (options ?? RepositoryQueryOptions<TAccessRightsPolicyParams>.DetailedView) with
        {
            LoadDetailedViewIncludes = options?.LoadDetailedViewIncludes ?? true
        };

        var query = await GetBaseQueryAsync(options);

        return await ApplyFilterByIdAsync(query, id);
    }
}