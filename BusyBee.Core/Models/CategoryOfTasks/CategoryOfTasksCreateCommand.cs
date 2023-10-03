using BusyBee.Core.Enums;
using BusyBee.Core.Models.DataTemplate;

namespace BusyBee.Core.Models.CategoryOfTasks;

public class CategoryOfTasksCreateCommand
{
    public string Title { get; set; } = null!;
    public Guid? ParentId { get; set; }
    
    public OrderAddressType OrderAddressType { get; set; }
    public DataTemplateCreateCommand? PaymentDataTemplate { get; set; }
    
    // public Guid? OrderAddressDataTemplateId { get; set; }
    // public Guid? PaymentDataTemplateId { get; set; }
    //
    // public DataTemplateCreateCommand? OrderAddressDataTemplate { get; set; }
}