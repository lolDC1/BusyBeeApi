using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.City;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Task;
using BusyBee.Core.Services.Domain.CrudBase;
using BusyBee.Core.Validators.Base;
using FluentValidation;

namespace BusyBee.Core.Services.Domain;

public class CityService : EntityCrudService<City, Guid, CityCommand, CityCommand,
    CityResponse, CityResponse, ListItem<Guid>, CityQueryParams>, ICityService
{
    public CityService(
        ICityRepository repository,
        EntityCrudServiceCommonDependencies dependencies,
        IValidator<CityCommand>? createValidator = default,
        IValidator<UpdateValidationModel<Guid, CityCommand>>? updateValidator = default)
        : base(repository, dependencies, createValidator, updateValidator)
    {
    }
}