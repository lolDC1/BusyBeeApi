using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.DataTemplate;
using BusyBee.Core.Services.Domain.CrudBase;
using BusyBee.Core.Validators.Base;
using FluentValidation;

namespace BusyBee.Core.Services.Domain;

public class DataTemplateService : EntityCrudService<DataTemplate, Guid, DataTemplateCreateCommand,
        DataTemplateUpdateCommand,
        DataTemplateResponse, DataTemplateResponse, ListItem<Guid>, DataTemplateQueryParams>,
    IDataTemplateService
{
    public DataTemplateService(
        IDataTemplateRepository repository,
        EntityCrudServiceCommonDependencies dependencies,
        IValidator<DataTemplateCreateCommand>? createValidator = default,
        IValidator<UpdateValidationModel<Guid, DataTemplateUpdateCommand>>? updateValidator = default)
        : base(repository, dependencies, createValidator, updateValidator)
    {
    }
}