using BusyBee.Core.Interfaces.Repositories.Base;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Task;
using Task = BusyBee.Core.Entities.Task;

namespace BusyBee.Core.Interfaces.Repositories;

public interface ITaskRepository : IEntityRepository<Task, Guid, ListItem<Guid>, TaskQueryParams>
{
}