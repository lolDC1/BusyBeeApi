using BusyBee.Api.Controllers.CrudBase;
using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Review;
using BusyBee.Core.Models.Task;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace BusyBee.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class TasksController : EntityCrudControllerBase<
    Guid,
    TaskCreateCommand,
    TaskUpdateCommand,
    TaskResponse,
    TaskResponse,
    ListItem<Guid>,
    TaskQueryParams>
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service, ControllerCommonDependencies dependencies) : base(service, dependencies)
    {
        _service = service;
    }

    [HttpGet]
    [Route("me")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<PagedResult<TaskResponse>> GetMeAsync([FromQuery] TaskQueryParams request, CancellationToken token = default)
    {
        return _service.GetMeAsync(request, token);
    }

    [HttpPost]
    [Route("assign/{id:Guid}")]
    public Task Assign([FromRoute] Guid id, CancellationToken token = default)
    {
        return _service.AssignAsync(id, token);
    }

    [HttpPost]
    [Route("deassign/{id:Guid}")]
    public Task Deassign([FromRoute] Guid id, CancellationToken token = default)
    {
        return _service.DeassignAsync(id, token);
    }

    [HttpPost]
    [Route("close/{id:Guid}")]
    public Task Close([FromRoute] Guid id, CancellationToken token = default)
    {
        return _service.CloseAsync(id, token);
    }

    [HttpPost]
    [Route("do")]
    public Task Do([FromBody] ReviewCommand reviewCommand, CancellationToken token = default)
    {
        return _service.DoAsync(reviewCommand, token);
    }
}