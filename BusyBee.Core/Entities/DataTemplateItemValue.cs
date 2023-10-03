using BusyBee.Core.Common;

namespace BusyBee.Core.Entities;

public class DataTemplateItemValue : BaseEntity
{
    public Guid DataTemplateItemId { get; set; }
    public string Value { get; set; } = null!;
    public int? AddedMoney { get; set; }

    public DataTemplateItem DataTemplateItem { get; set; } = null!;
}