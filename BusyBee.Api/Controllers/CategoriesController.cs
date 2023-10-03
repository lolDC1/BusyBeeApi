using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace BusyBee.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public Task<IEnumerable<CategoryResponse>> Get(CancellationToken token = default)
    {
        return _service.GetAsync(token);
    }

    [HttpGet]
    [Route("{id:Guid}/datatemplates")]
    public Task<CategoryDataTemplatesResponse?> GetDataTemplates(Guid id, CancellationToken token = default)
    {
        return _service.GetDataTemplatesAsync(id, token);
    }
}