using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories.Base;
using BusyBee.Core.Models.City;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Task;

namespace BusyBee.Core.Interfaces.Repositories;

public interface ICityRepository : IEntityRepository<City, Guid, ListItem<Guid>, CityQueryParams>
{
}