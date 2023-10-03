using BusyBee.Api.Common;
using BusyBee.Core.Models.CategoryOfTasks;

namespace BusyBee.Api.Models.CategoryOfTasks;

public class CategoryOfTasksUpdateCommandDto : CategoryOfTasksUpdateCommand, IFormFileDto
{
    public IFormFile? File { get; set; }
}