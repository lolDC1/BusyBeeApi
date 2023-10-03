using BusyBee.Core.Models.DataTemplate;

namespace BusyBee.Core.Models.Category;

public class CategoryDataTemplatesResponse
{
    public DataTemplateResponse? OrderAddressDataTemplate { get; set; }
    public DataTemplateResponse? PaymentDataTemplate { get; set; }
}