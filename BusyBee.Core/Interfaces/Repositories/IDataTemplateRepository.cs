using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories.Base;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.DataTemplate;

namespace BusyBee.Core.Interfaces.Repositories;

public interface
    IDataTemplateRepository : IEntityRepository<DataTemplate, Guid, ListItem<Guid>, DataTemplateQueryParams>
{
}