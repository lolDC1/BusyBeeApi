namespace BusyBee.Core.Models.CategoryOfCategories;

public class CategoryOfCategoriesCreateCommand
{
    public string Title { get; set; } = null!;
    public Guid? ParentId { get; set; }
}