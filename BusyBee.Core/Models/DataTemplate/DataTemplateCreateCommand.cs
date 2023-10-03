using BusyBee.Core.Models.DataTemplate.DataTemplateItem;

namespace BusyBee.Core.Models.DataTemplate;

public class DataTemplateCreateCommand
{
    public DataTemplateItemCreateCommand[] DataTemplateItems { get; set; } = null!;
    public double EstimatedCost { get; set; }
}