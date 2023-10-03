using System.Linq.Expressions;
using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Models.CategoryOfTasks;
using BusyBee.Core.Models.Common;
using BusyBee.Persistence.Repositories.CrudBase;

namespace BusyBee.Persistence.Repositories;

public class CategoryOfTasksRepository :
    UnitOfWorkEntityRepositoryBase<CategoryOfTasks, Guid, DatabaseContext, ListItem<Guid>, CategoryOfTasksQueryParams>,
    ICategoryOfTasksRepository
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryOfCategoriesRepository" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    public CategoryOfTasksRepository(DatabaseContext context, RepositoryCommonDependencies dependencies)
        : base(context, dependencies)
    {
    }

    protected override Func<string, Expression<Func<CategoryOfTasks, bool>>> SearchPredicate =>
        query => x => x.Title.Contains(query);

    protected override Func<string, Expression<Func<CategoryOfTasks, bool>>> TypeaheadPredicate =>
        query => x => x.Title.StartsWith(query);

    protected override IReadOnlyDictionary<string, Expression<Func<CategoryOfTasks, object?>>> SortingConfiguration { get; } =
        new Dictionary<string, Expression<Func<CategoryOfTasks, object?>>>
        {
            [nameof(CategoryOfTasks.Id)] = x => x.Id,
            [nameof(CategoryOfTasks.Title)] = x => x.Title
        };

    protected override async Task<IQueryable<CategoryOfTasks>> IncludeOwnedPropertiesAsync(IQueryable<CategoryOfTasks> query,
        CancellationToken token = default)
    {
        query = await base.IncludeOwnedPropertiesAsync(query, token);
        return query;
    }


    protected override async Task<IQueryable<CategoryOfTasks>> ApplyFilteringAsync(IQueryable<CategoryOfTasks> query,
        CategoryOfTasksQueryParams? request, CancellationToken token = default)
    {
        if (request is null) return query;

        query = await base.ApplyFilteringAsync(query, request, token);

        return query;
    }
}