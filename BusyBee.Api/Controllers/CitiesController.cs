using BusyBee.Api.Controllers.CrudBase;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.City;
using BusyBee.Core.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace BusyBee.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CitiesController : EntityCrudControllerBase<
    Guid,
    CityCommand,
    CityCommand,
    CityResponse,
    CityResponse,
    ListItem<Guid>,
    CityQueryParams>
{
    public CitiesController(ICityService service, ControllerCommonDependencies dependencies)
        : base(service, dependencies)
    {
    }

    [NonAction]
    public override Task<PagedResult<CityResponse>> QueryAsync(CityQueryParams request, CancellationToken token = default)
    {
        return base.QueryAsync(request, token);
    }

    [NonAction]
    public override Task<CityResponse> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return base.GetByIdAsync(id, token);
    }

    [NonAction]
    public override Task<CityResponse> CreateAsync(CityCommand commandDto, CancellationToken token = default)
    {
        return base.CreateAsync(commandDto, token);
    }

    [NonAction]
    public override Task<CityResponse> UpdateAsync(Guid id, CityCommand commandDto, CancellationToken token = default)
    {
        return base.UpdateAsync(id, commandDto, token);
    }

    [NonAction]
    public override Task DeleteAsync(Guid id, CancellationToken token = default)
    {
        return base.DeleteAsync(id, token);
    }
}