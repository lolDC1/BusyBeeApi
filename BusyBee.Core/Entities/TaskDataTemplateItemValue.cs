namespace BusyBee.Core.Entities;

public class TaskDataTemplateItemValue
{
    public Guid TaskId { get; set; }
    public Guid DataTemplateItemId { get; set; }
    public Guid DataTemplateItemValueId { get; set; }

    public Task Task { get; set; } = null!;
    public DataTemplateItem DataTemplateItem { get; set; } = null!;
    public DataTemplateItemValue DataTemplateItemValue { get; set; } = null!;
}