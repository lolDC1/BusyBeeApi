using BusyBee.Core.Interfaces.Services.Domain.Base;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.DataTemplate;

namespace BusyBee.Core.Interfaces.Services.Domain;

public interface IDataTemplateService : IEntityCrudService<
    Guid,
    DataTemplateCreateCommand,
    DataTemplateUpdateCommand,
    DataTemplateResponse,
    DataTemplateResponse,
    ListItem<Guid>,
    DataTemplateQueryParams>
{
}