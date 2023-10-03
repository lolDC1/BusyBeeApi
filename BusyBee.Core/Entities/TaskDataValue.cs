namespace BusyBee.Core.Entities;

public class TaskDataValue
{
    public Guid TaskId { get; set; }
    public Guid DataTemplateItemId { get; set; }
    public string Value { get; set; } = null!;

    public Task Task { get; set; } = null!;
    public DataTemplateItem DataTemplateItem { get; set; } = null!;
}