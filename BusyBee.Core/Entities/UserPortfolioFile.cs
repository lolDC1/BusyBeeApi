using BusyBee.Core.Common;

namespace BusyBee.Core.Entities;

public class UserPortfolioFile : BaseAuditableEntity
{
    public string Filename { get; set; } = null!;
    public string OriginalName { get; set; } = null!;

    public User User { get; set; } = null!;
}