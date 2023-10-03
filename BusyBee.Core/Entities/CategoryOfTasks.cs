using BusyBee.Core.Entities.Base;

namespace BusyBee.Core.Entities;

public class CategoryOfTasks : CategoryBase
{
    public Guid? OrderAddressDataTemplateId { get; set; }
    public Guid? PaymentDataTemplateId { get; set; }

    public List<Task> Tasks { get; set; } = null!;
    public DataTemplate? OrderAddressDataTemplate { get; set; }
    public DataTemplate? PaymentDataTemplate { get; set; }
}