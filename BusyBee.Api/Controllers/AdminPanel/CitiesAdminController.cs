using BusyBee.Api.Authorization;
using BusyBee.Api.Controllers.CrudBase;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.City;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Task;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusyBee.Api.Controllers.AdminPanel;

[Authorize(Roles = UserRoles.Admin)]
[ApiController]
[Route("admin/[controller]")]
public class CitiesAdminController : EntityCrudControllerBase<
    Guid,
    CityCommand,
    CityCommand,
    CityResponse,
    CityResponse,
    ListItem<Guid>,
    CityQueryParams>
{
    public CitiesAdminController(ICityService service, ControllerCommonDependencies dependencies)
        : base(service, dependencies)
    {
    }
}