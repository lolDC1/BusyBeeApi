using BusyBee.Core.Enums;
using BusyBee.Core.Models.Task.TaskData;
using TaskStatus = BusyBee.Core.Enums.TaskStatus;

namespace BusyBee.Core.Models.Task;

public class TaskResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? ConfidentialInfo { get; set; }
    public TaskStatus Status { get; set; }
    public Guid CategoryId { get; set; }
    public Guid CityId { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? AssignToId { get; set; }
    public DateOnly Date { get; set; }
    public TaskTime? Time { get; set; }
    public double Cost { get; set; }

    public TaskStringDataValueResponse[] Strings { get; set; } = null!;
    public TaskSelectionDataValueResponse[] Selections { get; set; } = null!;
}