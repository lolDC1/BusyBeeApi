using BusyBee.Core.Common;
using BusyBee.Core.Models.DataTemplate.DataTemplateItem;

namespace BusyBee.Core.Models.DataTemplate;

public class DataTemplateResponse : IEntity
{
    public DataTemplateItemResponse[] DataTemplateItems { get; set; } = null!;
    public double EstimatedCost { get; set; }
    public Guid Id { get; set; }
}