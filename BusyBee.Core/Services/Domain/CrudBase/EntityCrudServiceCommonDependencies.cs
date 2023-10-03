using AutoMapper;
using BusyBee.Core.Interfaces.ExceptionFactories;
using Microsoft.Extensions.Logging;

namespace BusyBee.Core.Services.Domain.CrudBase;

/// <summary>
///     An aggregated container to carry all necessary dependencies for <see cref="EntityCrudService{TEntity}" />.
/// </summary>
/// <param name="Mapper">The automapper used to convert types.</param>
/// <param name="LoggerFactory">The logger factory.</param>
/// <param name="ExceptionFactory">The exception factory.</param>
public record EntityCrudServiceCommonDependencies(
    IMapper Mapper,
    ILoggerFactory LoggerFactory,
    IExceptionFactory ExceptionFactory);