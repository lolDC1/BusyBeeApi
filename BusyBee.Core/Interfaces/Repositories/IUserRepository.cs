using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories.Base;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Task;
using BusyBee.Core.Models.User;

namespace BusyBee.Core.Interfaces.Repositories;

public interface IUserRepository : IEntityRepository<User, Guid, ListItem<Guid>, UserQueryParams>
{
}