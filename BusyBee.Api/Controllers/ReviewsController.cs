using BusyBee.Api.Controllers.CrudBase;
using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.City;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Review;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace BusyBee.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController : EntityCrudControllerBase<
    Guid,
    ReviewCommand,
    ReviewCommand,
    ReviewResponse,
    ReviewResponse,
    ListItem<Guid>,
    ReviewQueryParams>
{
    public ReviewsController(IReviewService service, ControllerCommonDependencies dependencies)
        : base(service, dependencies)
    {
    }

    [NonAction]
    public override Task<ReviewResponse> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return base.GetByIdAsync(id, token);
    }

    [NonAction]
    public override Task<ReviewResponse> CreateAsync(ReviewCommand commandDto, CancellationToken token = default)
    {
        return base.CreateAsync(commandDto, token);
    }

    [NonAction]
    public override Task<ReviewResponse> UpdateAsync(Guid id, ReviewCommand commandDto, CancellationToken token = default)
    {
        return base.UpdateAsync(id, commandDto, token);
    }

    [NonAction]
    public override Task DeleteAsync(Guid id, CancellationToken token = default)
    {
        return base.DeleteAsync(id, token);
    }
}