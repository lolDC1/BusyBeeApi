using BusyBee.Core.Models.Common;

namespace BusyBee.Api.Interfaces;

public interface IEntityCrudController<TPrimaryKey, TCreateCommandDto, TUpdateCommandDto, TListResponseDto, TDetailedResponseDto,
    TAutocomplete, TQueryParams> where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    ///     Retrieves an entry by id.
    /// </summary>
    /// <param name="id">An entity id.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A detailed view of entity with provided id.</returns>
    Task<TDetailedResponseDto> GetByIdAsync(TPrimaryKey id, CancellationToken token = default);

    /// <summary>
    ///     Preforms search, sorting and pagination.
    /// </summary>
    /// <param name="request">A request that represents pagination, sorting and searching.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A paginated list of results by provided request.</returns>
    Task<PagedResult<TListResponseDto>> QueryAsync(TQueryParams request, CancellationToken token = default);

    /// <summary>
    ///     Gets a collection in lightweight format used for autocomplete.
    /// </summary>
    /// <param name="request">A request that represents pagination, sorting and searching.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A paginated list of lightweight results by provided request.</returns>
    Task<PagedResult<TAutocomplete>> AutocompleteAsync(TQueryParams request, CancellationToken token = default);

    /// <summary>
    ///     Gets a collection in lightweight format used for autocomplete. Returns all available data at once.
    /// </summary>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A paginated list of lightweight results by provided request.</returns>
    Task<List<TAutocomplete>> AutocompleteAllAsync(CancellationToken token = default);

    /// <summary>
    ///     Creates new entry.
    /// </summary>
    /// <param name="commandDto">An entry creation command model.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A detailed view of created object.</returns>
    Task<TDetailedResponseDto> CreateAsync(TCreateCommandDto commandDto, CancellationToken token = default);

    /// <summary>
    ///     Updates an entity.
    /// </summary>
    /// <param name="id">An entry id.</param>
    /// <param name="commandDto">An entry creation command model.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A detailed view of updated entry.</returns>
    Task<TDetailedResponseDto> UpdateAsync(TPrimaryKey id, TUpdateCommandDto commandDto, CancellationToken token = default);

    /// <summary>
    ///     Deletes an entity.
    /// </summary>
    /// <param name="id">An id of entity.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>No Content (204).</returns>
    Task DeleteAsync(TPrimaryKey id, CancellationToken token = default);
}