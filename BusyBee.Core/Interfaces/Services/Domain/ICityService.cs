using BusyBee.Core.Interfaces.Services.Domain.Base;
using BusyBee.Core.Models.City;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Task;

namespace BusyBee.Core.Interfaces.Services.Domain;

public interface ICityService : IEntityCrudService<
    Guid,
    CityCommand,
    CityCommand,
    CityResponse,
    CityResponse,
    ListItem<Guid>,
    CityQueryParams>
{
}