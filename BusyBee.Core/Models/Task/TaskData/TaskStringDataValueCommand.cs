namespace BusyBee.Core.Models.Task.TaskData;

public class TaskStringDataValueCommand
{
    public Guid DataTemplateItemId { get; set; }
    public string Value { get; set; } = null!;
}