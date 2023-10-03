using BusyBee.Core.Enums;
using BusyBee.Core.Models.Task.TaskData;

namespace BusyBee.Core.Models.Task;

public class TaskUpdateCommand
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? ConfidentialInfo { get; set; }
    public Guid CityId { get; set; }
    public DateTime Date { get; set; }
    public TaskTime? Time { get; set; }
    public double Cost { get; set; }

    public TaskStringDataValueCommand[] Strings { get; set; } = null!;
    public TaskSelectionDataValueCommand[] Selections { get; set; } = null!;
}