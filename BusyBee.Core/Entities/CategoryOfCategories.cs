using BusyBee.Core.Entities.Base;

namespace BusyBee.Core.Entities;

public class CategoryOfCategories : CategoryBase
{
    public List<CategoryOfCategories> ChildCategories { get; set; } = null!;
    public List<CategoryOfTasks> CategoriesOfTasks { get; set; } = null!;
}