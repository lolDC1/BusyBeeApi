using AutoMapper;
using BusyBee.Core.Interfaces;
using BusyBee.Core.Interfaces.ExceptionFactories;

namespace BusyBee.Api.Controllers.CrudBase;

/// <summary>
///     An aggregated container to carry all necessary dependencies for
///     <see cref="DtoEntityCrudControllerBase{TPrimaryKey,TDto,TMapped}" />.
/// </summary>
/// <param name="Mapper">The automapper used to convert types.</param>
/// <param name="LoggerFactory">The logger factory.</param>
/// <param name="ExceptionFactory">The exception factory.</param>
/// <param name="UnitOfWork">The unit of work.</param>
public record ControllerCommonDependencies(
    IMapper Mapper,
    ILoggerFactory LoggerFactory,
    IExceptionFactory ExceptionFactory,
    IUnitOfWork UnitOfWork);