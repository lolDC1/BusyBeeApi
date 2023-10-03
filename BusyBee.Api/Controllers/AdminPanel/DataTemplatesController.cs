using BusyBee.Api.Authorization;
using BusyBee.Api.Controllers.CrudBase;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.DataTemplate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusyBee.Api.Controllers.AdminPanel;

[Authorize(Roles = UserRoles.Admin)]
[ApiController]
[Route("admin/[controller]")]
public class DataTemplatesController : EntityCrudControllerBase<
    Guid,
    DataTemplateCreateCommand,
    DataTemplateUpdateCommand,
    DataTemplateResponse,
    DataTemplateResponse,
    ListItem<Guid>,
    DataTemplateQueryParams>
{
    public DataTemplatesController(IDataTemplateService dataTemplateService, ControllerCommonDependencies dependencies)
        : base(dataTemplateService, dependencies)
    {
    }
}