using BusyBee.Core.Common;
using BusyBee.Core.Models.DataTemplate;

namespace BusyBee.Core.Models.CategoryOfTasks;

public class CategoryOfTasksResponse : IEntity, IIconFilename
{
    public string Title { get; set; } = null!;
    public Guid? ParentId { get; set; }
    public int CountOfTasks { get; set; }

    public DataTemplateResponse? OrderAddressDataTemplate { get; set; }
    public DataTemplateResponse? PaymentDataTemplate { get; set; }
    public Guid Id { get; set; }
    public string? IconFilename { get; set; }
}