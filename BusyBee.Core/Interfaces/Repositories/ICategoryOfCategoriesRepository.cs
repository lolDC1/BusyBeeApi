using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories.Base;
using BusyBee.Core.Models.CategoryOfCategories;
using BusyBee.Core.Models.Common;

namespace BusyBee.Core.Interfaces.Repositories;

public interface
    ICategoryOfCategoriesRepository : IEntityRepository<CategoryOfCategories, Guid, ListItem<Guid>, CategoryOfCategoriesQueryParams>
{
}