using BusyBee.Core.Common;
using BusyBee.Core.Interfaces.QueryParams;
using BusyBee.Core.Interfaces.Repositories.Base;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Common.Repositories;
using BusyBee.Core.Validators.Base;
using FluentValidation;

#pragma warning disable SA1402

namespace BusyBee.Core.Services.Domain.CrudBase;

/// <summary>
///     A service capable to perform full set of CRUD operation with given <typeparamref name="TEntity" />.
/// </summary>
/// <typeparam name="TEntity">Type of the entity.</typeparam>
public class EntityCrudService<TEntity> : EntityCrudService<TEntity, Guid>
    where TEntity : class, IEntity<Guid>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="EntityCrudService{TEntity}" /> class.
    /// </summary>
    /// <param name="repository">An underlying repository.</param>
    /// <param name="dependencies">The common dependencies.</param>
    /// <param name="entityValidator">A validator used to validate entity.</param>
    public EntityCrudService(
        IEntityRepository<TEntity, Guid, IListItem<Guid>> repository,
        EntityCrudServiceCommonDependencies dependencies,
        IValidator<UpdateValidationModel<Guid, TEntity>> entityValidator)
        : base(repository, dependencies, entityValidator)
    {
    }
}

/// <summary>
///     A service capable to perform full set of CRUD operation with given <typeparamref name="TEntity" />.
/// </summary>
/// <typeparam name="TEntity">Type of the entity.</typeparam>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
public class EntityCrudService<TEntity, TPrimaryKey> : EntityCrudService<TEntity, TPrimaryKey, TEntity>
    where TEntity : class, IEntity<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="EntityCrudService{TEntity, TPrimaryKey}" /> class.
    /// </summary>
    /// <param name="repository">An underlying repository.</param>
    /// <param name="dependencies">The common dependencies.</param>
    /// <param name="entityValidator">A validator used to validate entity.</param>
    public EntityCrudService(
        IEntityRepository<TEntity, TPrimaryKey, IListItem<TPrimaryKey>> repository,
        EntityCrudServiceCommonDependencies dependencies,
        IValidator<UpdateValidationModel<TPrimaryKey, TEntity>> entityValidator)
        : base(repository, dependencies, entityValidator)
    {
    }
}

/// <summary>
///     A service capable to perform full set of CRUD operation with given <typeparamref name="TEntity" />.
/// </summary>
/// <typeparam name="TEntity">Type of the entity.</typeparam>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TMapped">A model used for proxying <typeparamref name="TEntity" /> in default methods.</typeparam>
public class EntityCrudService<TEntity, TPrimaryKey, TMapped> : EntityCrudService<TEntity, TPrimaryKey, TMapped, TMapped>
    where TEntity : class, IEntity<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TMapped : class
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="EntityCrudService{TEntity, TPrimaryKey, TMapped}" /> class.
    /// </summary>
    /// <param name="repository">An underlying repository.</param>
    /// <param name="dependencies">The common dependencies.</param>
    /// <param name="modelValidator">A validator used to validate model.</param>
    public EntityCrudService(
        IEntityRepository<TEntity, TPrimaryKey, IListItem<TPrimaryKey>> repository,
        EntityCrudServiceCommonDependencies dependencies,
        IValidator<UpdateValidationModel<TPrimaryKey, TMapped>> modelValidator)
        : base(repository, dependencies, modelValidator)
    {
    }
}

/// <summary>
///     A service capable to perform full set of CRUD operation with given <typeparamref name="TEntity" />.
/// </summary>
/// <typeparam name="TEntity">Type of the entity.</typeparam>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TCommand">A model used for creating and updating entities in default methods.</typeparam>
/// <typeparam name="TResponse">A model that returned from query methods.</typeparam>
public class EntityCrudService<TEntity, TPrimaryKey, TCommand, TResponse> :
    EntityCrudService<TEntity, TPrimaryKey, TCommand, TCommand, TResponse, TResponse>
    where TEntity : class, IEntity<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TCommand : class
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="EntityCrudService{TEntity, TPrimaryKey, TCommand, TResponse}" /> class.
    /// </summary>
    /// <param name="repository">An underlying repository.</param>
    /// <param name="dependencies">The common dependencies.</param>
    /// <param name="commandValidator">A validator used to validate command.</param>
    public EntityCrudService(
        IEntityRepository<TEntity, TPrimaryKey, IListItem<TPrimaryKey>> repository,
        EntityCrudServiceCommonDependencies dependencies,
        IValidator<UpdateValidationModel<TPrimaryKey, TCommand>> commandValidator)
        : base(repository, dependencies, null!, commandValidator)
    {
    }
}

/// <inheritdoc />
public class EntityCrudService<TEntity, TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse> :
    EntityCrudService<TEntity, TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, IListItem<TPrimaryKey>>
    where TEntity : class, IEntity<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TCreateCommand : class
    where TUpdateCommand : class
{
    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="EntityCrudService{TEntity, TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse}" /> class.
    /// </summary>
    /// <param name="repository">An underlying repository.</param>
    /// <param name="dependencies">The common dependencies.</param>
    /// <param name="createValidator">A validator used to validate create command.</param>
    /// <param name="updateValidator">A validator used to validate update command.</param>
    public EntityCrudService(
        IEntityRepository<TEntity, TPrimaryKey, IListItem<TPrimaryKey>> repository,
        EntityCrudServiceCommonDependencies dependencies,
        IValidator<TCreateCommand>? createValidator,
        IValidator<UpdateValidationModel<TPrimaryKey, TUpdateCommand>> updateValidator)
        : base(repository, dependencies, createValidator, updateValidator)
    {
    }
}

/// <inheritdoc />
public class EntityCrudService<TEntity, TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete> :
    EntityCrudService<TEntity, TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete,
        IQueryParams<TPrimaryKey>>
    where TEntity : class, IEntity<TPrimaryKey>
    where TCreateCommand : class
    where TUpdateCommand : class
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="EntityCrudService{TEntity, TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse,TAutocomplete}" />
    ///     class.
    /// </summary>
    /// <param name="repository">An underlying repository.</param>
    /// <param name="dependencies">The common dependencies.</param>
    /// <param name="createValidator">A validator used to validate create command.</param>
    /// <param name="updateValidator">A validator used to validate update command.</param>
    public EntityCrudService(
        IEntityRepository<TEntity, TPrimaryKey, TAutocomplete, IQueryParams<TPrimaryKey>> repository,
        EntityCrudServiceCommonDependencies dependencies,
        IValidator<TCreateCommand>? createValidator,
        IValidator<UpdateValidationModel<TPrimaryKey, TUpdateCommand>> updateValidator)
        : base(repository, dependencies, createValidator, updateValidator)
    {
    }
}

public class EntityCrudService<TEntity, TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete,
    TQueryParams> :
    EntityCrudService<TEntity, TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete,
        TQueryParams, AccessRightsPolicyParams>
    where TEntity : class, IEntity<TPrimaryKey>
    where TCreateCommand : class
    where TUpdateCommand : class
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TQueryParams : IQueryParams<TPrimaryKey>
{
    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="EntityCrudService{TEntity, TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse,TAutocomplete}" />
    ///     class.
    /// </summary>
    /// <param name="repository">An underlying repository.</param>
    /// <param name="dependencies">The common dependencies.</param>
    /// <param name="createValidator">A validator used to validate create command.</param>
    /// <param name="updateValidator">A validator used to validate update command.</param>
    public EntityCrudService(
        IEntityRepository<TEntity, TPrimaryKey, TAutocomplete, TQueryParams> repository,
        EntityCrudServiceCommonDependencies dependencies,
        IValidator<TCreateCommand>? createValidator,
        IValidator<UpdateValidationModel<TPrimaryKey, TUpdateCommand>>? updateValidator)
        : base(repository, dependencies, createValidator, updateValidator)
    {
    }
}