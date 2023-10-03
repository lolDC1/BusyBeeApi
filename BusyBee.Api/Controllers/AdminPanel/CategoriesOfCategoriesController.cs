using BusyBee.Api.Authorization;
using BusyBee.Api.Controllers.CrudBase;
using BusyBee.Api.Models.CategoryOfCategories;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.CategoryOfCategories;
using BusyBee.Core.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusyBee.Api.Controllers.AdminPanel;

[Authorize(Roles = UserRoles.Admin)]
[ApiController]
[Route("admin/[controller]")]
public class CategoriesOfCategoriesController : CategoryEntityCrudControllerBase<
    Guid,
    CategoryOfCategoriesCreateCommand,
    CategoryOfCategoriesCreateCommandDto,
    CategoryOfCategoriesUpdateCommand,
    CategoryOfCategoriesUpdateCommandDto,
    CategoryOfCategoriesResponse,
    CategoryOfCategoriesResponse,
    ListItem<Guid>,
    CategoryOfCategoriesQueryParams>
{
    public CategoriesOfCategoriesController(ICategoryOfCategoriesService service, ControllerCommonDependencies dependencies)
        : base(service, dependencies)
    {
    }
}