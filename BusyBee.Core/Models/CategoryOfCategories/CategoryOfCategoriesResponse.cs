using BusyBee.Core.Common;

namespace BusyBee.Core.Models.CategoryOfCategories;

public class CategoryOfCategoriesResponse : IEntity, IIconFilename
{
    public string Title { get; set; } = null!;
    public int CountOfTasks { get; set; }
    public Guid? ParentId { get; set; }
    public Guid Id { get; set; }
    public string? IconFilename { get; set; }
}