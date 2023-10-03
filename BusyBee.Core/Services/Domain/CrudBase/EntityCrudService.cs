using AutoMapper;
using BusyBee.Core.Common;
using BusyBee.Core.Exceptions;
using BusyBee.Core.Extensions;
using BusyBee.Core.Interfaces.ExceptionFactories;
using BusyBee.Core.Interfaces.QueryParams;
using BusyBee.Core.Interfaces.Repositories.Base;
using BusyBee.Core.Interfaces.Services.Domain.Base;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Common.Repositories;
using BusyBee.Core.Validators.Base;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace BusyBee.Core.Services.Domain.CrudBase;

/// <inheritdoc />
public abstract class EntityCrudService<TEntity, TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse,
    TAutocomplete,
    TQueryParams, TAccessRightsPolicyParams> : IEntityCrudService<TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse,
    TDetailedResponse, TAutocomplete, TQueryParams, TAccessRightsPolicyParams>
    where TEntity : class, IEntity<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TCreateCommand : class
    where TUpdateCommand : class
    where TQueryParams : IQueryParams<TPrimaryKey>
    where TAccessRightsPolicyParams : AccessRightsPolicyParams
{
    /// <summary>
    ///     Initializes a new instance of the
    ///     <see
    ///         cref="EntityCrudService{TEntity,TPrimaryKey,TCreateCommand,TUpdateCommand,TListResponse,TDetailedResponse,TAutocomplete,TQueryParams}" />
    ///     class.
    /// </summary>
    /// <param name="repository">An underlying repository.</param>
    /// <param name="dependencies">The common dependencies.</param>
    /// <param name="createValidator">A validator used to validate create command.</param>
    /// <param name="updateValidator">A validator used to validate update command.</param>
    protected EntityCrudService(
        IEntityRepository<TEntity, TPrimaryKey, TAutocomplete, TQueryParams, TAccessRightsPolicyParams> repository,
        EntityCrudServiceCommonDependencies dependencies,
        IValidator<TCreateCommand>? createValidator,
        IValidator<UpdateValidationModel<TPrimaryKey, TUpdateCommand>>? updateValidator)
    {
        Repository = repository;
        CreateValidator = createValidator;
        UpdateValidator = updateValidator;
        (Mapper, LoggerFactory, ExceptionFactory) = dependencies;
        Logger = dependencies.LoggerFactory.CreateLogger(GetType());
    }

    /// <summary>
    ///     Gets the exception factory.
    /// </summary>
    protected virtual IExceptionFactory ExceptionFactory { get; }

    /// <summary>
    ///     Gets the logger.
    /// </summary>
    protected virtual ILogger Logger { get; }

    /// <summary>
    ///     Gets the logger factory.
    /// </summary>
    protected virtual ILoggerFactory LoggerFactory { get; }

    /// <summary>
    ///     Gets the automapper used to convert types.
    /// </summary>
    protected virtual IMapper Mapper { get; }

    /// <summary>
    ///     Gets an underlying repository.
    /// </summary>
    protected virtual IEntityRepository<TEntity, TPrimaryKey, TAutocomplete, TQueryParams, TAccessRightsPolicyParams> Repository { get; }

    protected virtual IValidator<TCreateCommand>? CreateValidator { get; }

    protected virtual IValidator<UpdateValidationModel<TPrimaryKey, TUpdateCommand>> UpdateValidator { get; }

    /// <inheritdoc />
    public virtual async Task<PagedResult<TListResponse>> GetAsync(TQueryParams? queryParams = default, CancellationToken token = default)
    {
        var result = await Repository.GetProjectedAsync<TListResponse>(queryParams, token: token);
        return result;
    }

    public virtual async Task<PagedResult<T>> GetProjectedAsync<T>(TQueryParams? queryParams = default, CancellationToken token = default)
    {
        var result = await Repository.GetProjectedAsync<T>(queryParams, token: token);
        return result;
    }

    /// <inheritdoc />
    public virtual async Task<TDetailedResponse?> GetByIdAsync(TPrimaryKey id, bool isRequired,
        TAccessRightsPolicyParams? accessRightsPolicyParams = default, CancellationToken token = default)
    {
        var result = await Repository.GetByIdProjectedAsync<TDetailedResponse>(id,
            RepositoryQueryOptions<TAccessRightsPolicyParams>.DetailedView
                .SetRequired(isRequired)
                .SetAccessRightsPolicyParams(accessRightsPolicyParams), token);

        return result;
    }

    public virtual async Task<T?> GetProjectedByIdAsync<T>(TPrimaryKey id, bool isRequired,
        TAccessRightsPolicyParams? accessRightsPolicyParams = default, CancellationToken token = default)
    {
        var result = await Repository.GetByIdProjectedAsync<T>(id,
            RepositoryQueryOptions<TAccessRightsPolicyParams>.DetailedView
                .SetRequired(isRequired)
                .SetAccessRightsPolicyParams(accessRightsPolicyParams),
            token);

        return result;
    }

    /// <inheritdoc />
    public virtual async Task<ValueAccessor<TPrimaryKey>> CreateAsync(TCreateCommand createCommand, CancellationToken token = default)
    {
        await ThrowIfCommandNotValid(createCommand, CreateValidator, token);
        var entityToCreate = Mapper.MapSelfIgnored<TEntity>(createCommand);
        var created = await Repository.CreateAsync(entityToCreate, token);
        return created.ValueAccessor;
    }

    /// <inheritdoc />
    public virtual async Task UpdateAsync(TPrimaryKey id, TUpdateCommand updateCommand, CancellationToken token = default)
    {
        await ThrowIfCommandNotValid(new UpdateValidationModel<TPrimaryKey, TUpdateCommand>(id, updateCommand), UpdateValidator, token);
        var entity = await Repository.GetByIdAsync(id, RepositoryQueryOptions<TAccessRightsPolicyParams>.Default.SetRequired(), token);
        Mapper.Map(updateCommand, entity);
        await Repository.UpdateAsync(entity!, token);
    }

    /// <inheritdoc />
    public virtual async Task DeleteByIdAsync(TPrimaryKey id, CancellationToken token = default)
    {
        var entity = await Repository.GetByIdAsync(id, RepositoryQueryOptions<TAccessRightsPolicyParams>.BareView.SetRequired(), token);
        EnsureFound(id, entity);
        await Repository.DeleteAsync(entity!, token);
    }

    /// <inheritdoc />
    public virtual Task<bool> ExistsAsync(TPrimaryKey id, CancellationToken token = default)
    {
        return Repository.ExistsAsync(id, token);
    }

    /// <inheritdoc />
    public virtual Task MustExistsAsync(TPrimaryKey id, CancellationToken token = default)
    {
        return Repository.MustExistsAsync(id, token);
    }

    /// <inheritdoc />
    public virtual Task<PagedResult<TAutocomplete>> AutocompleteAsync(TQueryParams? queryParams = default,
        CancellationToken token = default)
    {
        return Repository.AutocompleteAsync(queryParams, token);
    }

    /// <summary>
    ///     Ensures an <paramref name="entity" /> that with provided <paramref name="id" /> was found.
    ///     Otherwise throws an <see cref="NotFoundDomainException" />.
    /// </summary>
    /// <param name="id">An entity id.</param>
    /// <param name="entity">An entity to check.</param>
    protected virtual void EnsureFound(TPrimaryKey id, TEntity? entity)
    {
        if (entity != null)
            return;

        throw ExceptionFactory.EntityNotFound<TEntity>(id);
    }

    /// <summary>
    ///     Throws a localized exception <see cref="ValidationDomainException" /> if a command is not valid.
    /// </summary>
    /// <param name="command">A command to validate.</param>
    /// <param name="validator">A command validator.</param>
    /// <param name="token">A cancellation token.</param>
    /// <typeparam name="T">A command type.</typeparam>
    /// <exception cref="ValidationDomainException">A validation exception.</exception>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    protected virtual async Task ThrowIfCommandNotValid<T>(T command, IValidator<T>? validator, CancellationToken token)
    {
        if (validator == null)
            return;

        var validationResult = await validator.ValidateAsync(command, token);
        if (!validationResult.IsValid) throw ExceptionFactory.ValidationProblem(validationResult);
    }
}