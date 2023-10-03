namespace BusyBee.Core.Models.Category;

public class CategoryResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public int CountOfTasks { get; set; }
    public Guid? ParentId { get; set; }
    public string? IconFilename { get; set; }

    public CategoryResponse[]? Children { get; set; }
}