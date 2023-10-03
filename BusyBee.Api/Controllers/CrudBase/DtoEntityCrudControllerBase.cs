using AutoMapper;
using BusyBee.Api.Interfaces;
using BusyBee.Core.Extensions;
using BusyBee.Core.Interfaces;
using BusyBee.Core.Interfaces.ExceptionFactories;
using BusyBee.Core.Interfaces.Services.Domain.Base;
using BusyBee.Core.Models.Common;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

#pragma warning disable SA1402

namespace BusyBee.Api.Controllers.CrudBase;

/// <summary>
///     Represents a base class for controller with full set of CRUD operations supported.
/// </summary>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TCreateCommandDto">A DTO model used for creating new entities in default methods.</typeparam>
/// <typeparam name="TUpdateCommandDto">A DTO model used for updating exising entities in default methods.</typeparam>
/// <typeparam name="TListResponseDto">A DTO model that returned from methods returning a list of entities.</typeparam>
/// <typeparam name="TDetailedResponseDto">A DTO model that returned from methods returning a single, more detailed entity.</typeparam>
/// <typeparam name="TCreateCommand">A model used for creating new entities in default methods.</typeparam>
/// <typeparam name="TUpdateCommand">A model used for updating exising entities in default methods.</typeparam>
/// <typeparam name="TListResponse">A model that returned from methods returning a list of entities.</typeparam>
/// <typeparam name="TDetailedResponse">A model that returned from methods returning a single, more detailed entity.</typeparam>
/// <typeparam name="TAutocomplete">The type used for autocomplete.</typeparam>
/// <typeparam name="TQueryParams">A model used to specify custom filters or other criteria for querying.</typeparam>
// [SwaggerTag("<<< Please specify a controller description >>>")]
[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class DtoEntityCrudControllerBase<TPrimaryKey, TCreateCommandDto, TUpdateCommandDto, TListResponseDto,
    TDetailedResponseDto, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete, TQueryParams> :
    ControllerBase,
    IEntityCrudController<TPrimaryKey, TCreateCommandDto, TUpdateCommandDto, TListResponseDto, TDetailedResponseDto, TAutocomplete,
        TQueryParams> where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    ///     Initializes a new instance of the
    ///     <see
    ///         cref="DtoEntityCrudControllerBase{TPrimaryKey,TCreateCommandDto,TUpdateCommandDto,TListResponseDto,TDetailedResponseDto,TCreateCommand,TUpdateCommand,TListResponse,TDetailedResponse,TAutocomplete,TQueryParams}" />
    ///     class.
    /// </summary>
    /// <param name="crudService">A service capable to perform CRUD operations.</param>
    /// <param name="dependencies">The automapper used to convert types.</param>
    public DtoEntityCrudControllerBase(
        IEntityCrudService<TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete,
            TQueryParams> crudService,
        ControllerCommonDependencies dependencies)
    {
        CrudService = crudService;
        (Mapper, LoggerFactory, ExceptionFactory, UnitOfWork) = dependencies;
        Logger = dependencies.LoggerFactory.CreateLogger(GetType());
    }

    /// <summary>
    ///     Gets or sets a validator for create command model. Set a value to enable validations.
    /// </summary>
    protected IValidator<TCreateCommandDto> CreateValidator { get; set; }

    /// <summary>
    ///     Gets a service capable to perform CRUD operations.
    /// </summary>
    protected virtual
        IEntityCrudService<TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete,
            TQueryParams> CrudService { get; }

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
    ///     Gets the unit of work for saving changes made by services.
    /// </summary>
    protected virtual IUnitOfWork UnitOfWork { get; }

    /// <summary>
    ///     Gets or sets a validator for update command model. Set a value to enable validations.
    /// </summary>
    protected IValidator<TUpdateCommandDto> UpdateValidator { get; set; }

    /// <summary>
    ///     Retrieves an entry by id.
    /// </summary>
    /// <param name="id">An entity id.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A detailed view of entity with provided id.</returns>
    [HttpGet("{id}")]
    [ActionName(nameof(GetByIdAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public virtual async Task<TDetailedResponseDto> GetByIdAsync(TPrimaryKey id, CancellationToken token = default)
    {
        var result = await CrudService.GetByIdAsync(id, true, token: token);

        var mappedResult = Mapper.MapSelfIgnored<TDetailedResponseDto>(result);

        return mappedResult;
    }

    /// <summary>
    ///     Preforms search, sorting and pagination.
    /// </summary>
    /// <param name="request">A request that represents pagination, sorting and searching.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A paginated list of results by provided request.</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public virtual async Task<PagedResult<TListResponseDto>> QueryAsync([FromQuery] TQueryParams request,
        CancellationToken token = default)
    {
        var result = await CrudService.GetAsync(request, token);
        var mappedResults = Mapper.MapSelfIgnored<List<TListResponseDto>>(result.Results);
        return new PagedResult<TListResponseDto>(result.PageNumber, result.PageSize, mappedResults, result.ItemsCount);
    }

    /// <summary>
    ///     Gets a collection in lightweight format used for autocomplete.
    /// </summary>
    /// <param name="request">A request that represents pagination, sorting and searching.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A paginated list of lightweight results by provided request.</returns>
    [HttpGet("autocomplete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public virtual async Task<PagedResult<TAutocomplete>> AutocompleteAsync([FromQuery] TQueryParams request,
        CancellationToken token = default)
    {
        var result = await CrudService.AutocompleteAsync(request, token);

        return result;
    }

    /// <summary>
    ///     Gets a collection in lightweight format used for autocomplete. Returns all entries.
    /// </summary>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A paginated list of lightweight results by provided request.</returns>
    [HttpGet("autocomplete-all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public virtual async Task<List<TAutocomplete>> AutocompleteAllAsync(CancellationToken token = default)
    {
        var result = await CrudService.AutocompleteAsync(default, token);

        return result.Results;
    }

    /// <summary>
    ///     Creates new entry.
    /// </summary>
    /// <param name="commandDto">An entry creation command model.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A detailed view of created object.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public virtual async Task<TDetailedResponseDto> CreateAsync([FromBody] TCreateCommandDto commandDto,
        CancellationToken token = default)
    {
        var command = Mapper.MapSelfIgnored<TCreateCommand>(commandDto);
        var keyAccessor = await CrudService.CreateAsync(command, token);
        await UnitOfWork.SaveChangesAsync(token);
        var id = keyAccessor.Value;
        var created = await CrudService.GetByIdAsync(id, token);
        var createdDto = Mapper.MapSelfIgnored<TDetailedResponseDto>(created);
        var getUrl = Url.Action(nameof(GetByIdAsync), null, ConvertEntityIdToRouteId(id), Request.Scheme);
        Response.Headers.Location = getUrl;
        Response.StatusCode = StatusCodes.Status201Created;
        return createdDto;
    }

    /// <summary>
    ///     Updates an entity.
    /// </summary>
    /// <param name="id">An entry id.</param>
    /// <param name="commandDto">An entry creation command model.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A detailed view of updated entry.</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public virtual async Task<TDetailedResponseDto> UpdateAsync(TPrimaryKey id,
        [FromBody] TUpdateCommandDto commandDto,
        CancellationToken token = default)
    {
        var command = Mapper.MapSelfIgnored<TUpdateCommand>(commandDto);
        await CrudService.UpdateAsync(id, command, token);
        await UnitOfWork.SaveChangesAsync(token);
        var updated = await CrudService.GetByIdAsync(id, token);
        var updatedDto = Mapper.MapSelfIgnored<TDetailedResponseDto>(updated);
        Response.StatusCode = StatusCodes.Status202Accepted;
        return updatedDto;
    }

    /// <summary>
    ///     Deletes an entity.
    /// </summary>
    /// <param name="id">An id of entity.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>No Content (204).</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public virtual async Task DeleteAsync(TPrimaryKey id, CancellationToken token = default)
    {
        await CrudService.DeleteByIdAsync(id, token);
        await UnitOfWork.SaveChangesAsync(token);
        Response.StatusCode = StatusCodes.Status204NoContent;
    }

    /// <summary>
    ///     Gets an object that represents a route params from entity id.
    /// </summary>
    /// <param name="id">An entity id.</param>
    /// <returns>A route params object.</returns>
    protected virtual object ConvertEntityIdToRouteId(TPrimaryKey id)
    {
        // Wrap all base types into object
        if (id is bool or byte or sbyte or char or decimal or double or float or int or uint or nint or nuint or long or ulong or short
            or ushort or string or Guid)
            return new
            {
                id
            };

        return id;
    }
}