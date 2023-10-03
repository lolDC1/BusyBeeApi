using TaskStatus = BusyBee.Core.Enums.TaskStatus;

namespace BusyBee.Core.Models.Task;

public class TaskFilter
{
    public TaskStatus Status { get; set; }
}