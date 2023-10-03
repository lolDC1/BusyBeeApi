using BusyBee.Core.Models.DataTemplate.DataTemplateItem;

namespace BusyBee.Core.Models.DataTemplate;

public class DataTemplateUpdateCommand
{
    // TODO: update
    public DataTemplateItemCreateCommand[] DataTemplateItems { get; set; } = null!;
    public double EstimatedCost { get; set; }
}