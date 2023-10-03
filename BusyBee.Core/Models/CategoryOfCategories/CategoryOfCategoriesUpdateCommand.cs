namespace BusyBee.Core.Models.CategoryOfCategories;

public class CategoryOfCategoriesUpdateCommand
{
    public string Title { get; set; } = null!;
    public Guid? ParentId { get; set; }
}