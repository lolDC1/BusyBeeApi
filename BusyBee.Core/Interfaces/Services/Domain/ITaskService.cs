using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Services.Domain.Base;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Review;
using BusyBee.Core.Models.Task;
using Task = System.Threading.Tasks.Task;

namespace BusyBee.Core.Interfaces.Services.Domain;

public interface ITaskService : IEntityCrudService<
    Guid,
    TaskCreateCommand,
    TaskUpdateCommand,
    TaskResponse,
    TaskResponse,
    ListItem<Guid>,
    TaskQueryParams>
{
    public Task<PagedResult<TaskResponse>> GetMeAsync(TaskQueryParams? queryParams = default, CancellationToken token = default);

    public Task CloseAsync(Guid id, CancellationToken token = default);

    public Task DoAsync(ReviewCommand reviewCommand, CancellationToken token = default);

    public Task AssignAsync(Guid taskId, CancellationToken token = default);

    public Task DeassignAsync(Guid taskId, CancellationToken token = default);
}