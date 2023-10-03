using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories.Base;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Task;
using BusyBee.Core.Models.User.UserPortfolioFile;

namespace BusyBee.Core.Interfaces.Repositories;

public interface IUserPortfolioFileRepository : IEntityRepository<UserPortfolioFile, Guid, ListItem<Guid>, UserPortfolioFileQueryParams>
{
}