using BusyBee.Api.Authorization;
using BusyBee.Api.Controllers.CrudBase;
using BusyBee.Api.Models.CategoryOfTasks;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.CategoryOfTasks;
using BusyBee.Core.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusyBee.Api.Controllers.AdminPanel;

[Authorize(Roles = UserRoles.Admin)]
[ApiController]
[Route("admin/[controller]")]
public class CategoriesOfTasksController : CategoryEntityCrudControllerBase<
    Guid,
    CategoryOfTasksCreateCommand,
    CategoryOfTasksCreateCommandDto,
    CategoryOfTasksUpdateCommand,
    CategoryOfTasksUpdateCommandDto,
    CategoryOfTasksResponse,
    CategoryOfTasksResponse,
    ListItem<Guid>,
    CategoryOfTasksQueryParams>
{
    public CategoriesOfTasksController(ICategoryOfTasksService service, ControllerCommonDependencies dependencies)
        : base(service, dependencies)
    {
    }
}