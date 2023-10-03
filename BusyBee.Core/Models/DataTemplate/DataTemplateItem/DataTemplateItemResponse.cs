using BusyBee.Core.Common;
using BusyBee.Core.Enums;
using BusyBee.Core.Models.DataTemplate.DataTemplateItem.DataTemplateItemValue;

namespace BusyBee.Core.Models.DataTemplate.DataTemplateItem;

public class DataTemplateItemResponse : IEntity
{
    public string? Title { get; set; }
    public DataTemplateType Type { get; set; }
    public DataTemplateItemValueResponse[]? Selection { get; set; }
    public Guid Id { get; set; }
}