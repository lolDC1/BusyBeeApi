using BusyBee.Core.Interfaces.Services.Domain.Common;
using BusyBee.Core.Models.CategoryOfCategories;
using BusyBee.Core.Models.Common;

namespace BusyBee.Core.Interfaces.Services.Domain;

public interface ICategoryOfCategoriesService : ICategoryCommonService<
    Guid,
    CategoryOfCategoriesCreateCommand,
    CategoryOfCategoriesUpdateCommand,
    CategoryOfCategoriesResponse,
    CategoryOfCategoriesResponse,
    ListItem<Guid>,
    CategoryOfCategoriesQueryParams>
{
}