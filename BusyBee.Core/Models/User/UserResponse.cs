using BusyBee.Core.Enums;
using BusyBee.Core.Models.User.UserPortfolioFile;

namespace BusyBee.Core.Models.User;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public Guid? CityId { get; set; }
    public string? CityName { get; set; }
    public DateOnly? Birthday { get; set; }
    public Gender? Gender { get; set; }
    public string? AboutMyself { get; set; }
    public string? Phone { get; set; }
    public string? ContactEmail { get; set; }
    public string? PhotoFilename { get; set; }
    public string? VideoLink { get; set; }
    public List<UserPortfolioFileResponse> PortfolioFiles { get; set; } = null!;
    public List<string> OrderCategories { get; set; } = null!;
    public List<string> OrderCities { get; set; } = null!;
}