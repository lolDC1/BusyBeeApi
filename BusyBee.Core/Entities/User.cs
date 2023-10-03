using BusyBee.Core.Common;
using BusyBee.Core.Enums;

namespace BusyBee.Core.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public Guid? CityId { get; set; }
    public DateOnly? Birthday { get; set; }
    public Gender? Gender { get; set; }
    public string? AboutMyself { get; set; }
    public string? Phone { get; set; }
    public string? ContactEmail { get; set; }
    public string? PhotoFilename { get; set; }
    public string? VideoLink { get; set; }
    public bool IsDeleted { get; set; }

    public City? City { get; set; }
    public List<Task> Tasks { get; set; } = null!;
    public List<Task> AssignedTasks { get; set; } = null!;
    public List<UserPortfolioFile> PortfolioFiles { get; set; } = null!;
}