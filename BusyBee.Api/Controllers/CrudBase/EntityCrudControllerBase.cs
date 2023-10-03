using BusyBee.Core.Interfaces.Services.Domain.Base;

#pragma warning disable SA1402

namespace BusyBee.Api.Controllers.CrudBase;

/// <summary>
///     Represents a base class for controller with full set of CRUD operations supported.
///     This class has simplified model. In difference to
///     <see
///         cref="DtoEntityCrudControllerBase{TPrimaryKey,TCreateCommandDto,TUpdateCommandDto,TListResponseDto,TDetailedResponseDto,TCreateCommand,TUpdateCommand,TListResponse,TDetailedResponse}" />
///     it uses the same model for data transfer over network and for service layer interactions.
/// </summary>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TCreateCommand">A model used for creating new entities in default methods.</typeparam>
/// <typeparam name="TUpdateCommand">A model used for updating exising entities in default methods.</typeparam>
/// <typeparam name="TListResponse">A model that returned from methods returning a list of entities.</typeparam>
/// <typeparam name="TDetailedResponse">A model that returned from methods returning a single, more detailed entity.</typeparam>
/// <typeparam name="TAutocomplete">The type used for autocomplete.</typeparam>
/// <typeparam name="TQueryParams">A model used to specify custom filters or other criteria for querying.</typeparam>
public class EntityCrudControllerBase<TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse,
    TAutocomplete, TQueryParams> : DtoEntityCrudControllerBase<TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse,
    TDetailedResponse, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete, TQueryParams>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    ///     Initializes a new instance of the
    ///     <see
    ///         cref="EntityCrudControllerBase{TPrimaryKey,TCreateCommand,TUpdateCommand,TListResponse,TDetailedResponse,TAutocomplete,TQueryParams}" />
    ///     class.
    /// </summary>
    /// <param name="crudService">A service capable to perform CRUD operations.</param>
    /// <param name="dependencies">The automapper used to convert types.</param>
    protected EntityCrudControllerBase(
        IEntityCrudService<TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete,
            TQueryParams> crudService, ControllerCommonDependencies dependencies) : base(crudService, dependencies)
    {
    }
}