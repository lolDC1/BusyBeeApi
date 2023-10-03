using BusyBee.Api.Common;
using BusyBee.Core.Models.User.UserPortfolioFile;

namespace BusyBee.Api.Models.User;

public class UserPortfolioFileCommandDto : UserPortfolioFileCommand, IFormFileDto
{
    public IFormFile? File { get; set; }
}