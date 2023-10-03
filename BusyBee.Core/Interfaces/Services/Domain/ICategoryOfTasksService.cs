using BusyBee.Core.Interfaces.Services.Domain.Common;
using BusyBee.Core.Models.Category;
using BusyBee.Core.Models.CategoryOfTasks;
using BusyBee.Core.Models.Common;

namespace BusyBee.Core.Interfaces.Services.Domain;

public interface ICategoryOfTasksService : ICategoryCommonService<
    Guid,
    CategoryOfTasksCreateCommand,
    CategoryOfTasksUpdateCommand,
    CategoryOfTasksResponse,
    CategoryOfTasksResponse,
    ListItem<Guid>,
    CategoryOfTasksQueryParams>
{
    public Task<CategoryDataTemplatesResponse?> GetDataTemplatesAsync(Guid categoryId, CancellationToken token = default);
}