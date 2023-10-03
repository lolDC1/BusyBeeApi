using AutoMapper;
using BusyBee.Core.Interfaces.ExceptionFactories;
using Microsoft.Extensions.Logging;

namespace BusyBee.Persistence.Repositories.CrudBase;

/// <summary>
///     An aggregated container to carry all necessary dependencies for EntityCrudService.
/// </summary>
/// <param name="Mapper">The automapper used to convert types.</param>
/// <param name="LoggerFactory">The logger factory.</param>
/// <param name="ExceptionFactory">The exception factory.</param>
public record RepositoryCommonDependencies(
    IMapper Mapper,
    ILoggerFactory LoggerFactory,
    IExceptionFactory ExceptionFactory);