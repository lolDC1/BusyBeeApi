using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories.Base;
using BusyBee.Core.Models.City;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Review;

namespace BusyBee.Core.Interfaces.Repositories;

public interface IReviewRepository : IEntityRepository<Review, Guid, ListItem<Guid>, ReviewQueryParams>
{
}