namespace BusyBee.Core.Models.Task.TaskData;

public class TaskSelectionDataValueCommand
{
    public Guid DataTemplateItemId { get; set; }
    public Guid[] Values { get; set; } = null!;
}