using BusyBee.Core.Enums;
using BusyBee.Core.Models.DataTemplate.DataTemplateItem.DataTemplateItemValue;

namespace BusyBee.Core.Models.DataTemplate.DataTemplateItem;

public class DataTemplateItemCreateCommand
{
    public string? Title { get; set; }
    public DataTemplateType Type { get; set; }
    public DataTemplateItemValueCreateCommand[]? Selection { get; set; }
}