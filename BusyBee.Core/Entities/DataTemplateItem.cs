using BusyBee.Core.Common;
using BusyBee.Core.Enums;

namespace BusyBee.Core.Entities;

public class DataTemplateItem : BaseEntity
{
    public string? Title { get; set; }
    public DataTemplateType Type { get; set; }
    public Guid DataTemplateId { get; set; }

    public DataTemplate DataTemplate { get; set; } = null!;
    public List<DataTemplateItemValue> DataTemplateAdditional { get; set; } = null!;
}