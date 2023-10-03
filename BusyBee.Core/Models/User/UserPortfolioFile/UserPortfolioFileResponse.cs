namespace BusyBee.Core.Models.User.UserPortfolioFile;

public class UserPortfolioFileResponse
{
    public Guid Id { get; set; }
    public string Url { get; set; } = null!;
    public string OriginalName { get; set; } = null!;
}