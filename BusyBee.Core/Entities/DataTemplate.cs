using BusyBee.Core.Common;

namespace BusyBee.Core.Entities;

public class DataTemplate : BaseEntity
{
    public List<DataTemplateItem> DataTemplateItems { get; set; } = null!;
    public double EstimatedCost { get; set; }
}