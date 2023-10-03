using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Services.Domain.Base;
using BusyBee.Core.Models.City;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Review;

namespace BusyBee.Core.Interfaces.Services.Domain;

public interface IReviewService : IEntityCrudService<
    Guid,
    ReviewCommand,
    ReviewCommand,
    ReviewResponse,
    ReviewResponse,
    ListItem<Guid>,
    ReviewQueryParams>
{
}