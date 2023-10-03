using BusyBee.Core.Common;

namespace BusyBee.Core.Models.DataTemplate.DataTemplateItem.DataTemplateItemValue;

public class DataTemplateItemValueResponse : IEntity
{
    public string Value { get; set; } = null!;
    public int? AddedMoney { get; set; }
    public Guid Id { get; set; }
}