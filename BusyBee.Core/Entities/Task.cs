using BusyBee.Core.Common;
using BusyBee.Core.Enums;
using TaskStatus = BusyBee.Core.Enums.TaskStatus;

namespace BusyBee.Core.Entities;

public class Task : BaseAuditableEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? ConfidentialInfo { get; set; }
    public TaskStatus Status { get; set; }
    public Guid CategoryId { get; set; }
    public Guid CityId { get; set; }
    public Guid? AssignToId { get; set; }
    public DateOnly Date { get; set; }
    public TaskTime? Time { get; set; }
    public double Cost { get; set; }

    public CategoryOfTasks CategoryOfTasks { get; set; } = null!;
    public City City { get; set; } = null!;
    public User User { get; set; } = null!;
    public Review? Review { get; set; }
    public User? AssignTo { get; set; }
    public List<TaskDataTemplateItemValue> TaskDataTemplateItemValues { get; set; } = null!;
    public List<TaskDataValue> TaskDataValues { get; set; } = null!;
}