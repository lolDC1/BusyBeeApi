using BusyBee.Core.Enums;

namespace BusyBee.Core.Models.User;

public class UserCommand
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public Guid? CityId { get; set; }
    public DateTime? Birthday { get; set; }
    public Gender? Gender { get; set; }
    public string? Phone { get; set; }
    public string? ContactEmail { get; set; }
    public string? AboutMyself { get; set; }
    public string? VideoLink { get; set; }
}