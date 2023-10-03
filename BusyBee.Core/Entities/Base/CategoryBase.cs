using BusyBee.Core.Common;

namespace BusyBee.Core.Entities.Base;

public abstract class CategoryBase : BaseEntity
{
    public string Title { get; set; } = null!;
    public Guid? ParentId { get; set; }
    public string? IconFilename { get; set; }

    public CategoryOfCategories? Parent { get; set; }
}