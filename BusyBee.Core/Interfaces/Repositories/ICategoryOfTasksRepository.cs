using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories.Base;
using BusyBee.Core.Models.CategoryOfTasks;
using BusyBee.Core.Models.Common;

namespace BusyBee.Core.Interfaces.Repositories;

public interface
    ICategoryOfTasksRepository : IEntityRepository<CategoryOfTasks, Guid, ListItem<Guid>, CategoryOfTasksQueryParams>
{
}