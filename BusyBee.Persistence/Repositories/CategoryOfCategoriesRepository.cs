using System.Linq.Expressions;
using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Models.CategoryOfCategories;
using BusyBee.Core.Models.Common;
using BusyBee.Persistence.Repositories.CrudBase;

namespace BusyBee.Persistence.Repositories;

public class CategoryOfCategoriesRepository :
    UnitOfWorkEntityRepositoryBase<CategoryOfCategories, Guid, DatabaseContext, ListItem<Guid>, CategoryOfCategoriesQueryParams>,
    ICategoryOfCategoriesRepository
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryOfCategoriesRepository" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    public CategoryOfCategoriesRepository(DatabaseContext context, RepositoryCommonDependencies dependencies)
        : base(context, dependencies)
    {
    }

    protected override Func<string, Expression<Func<CategoryOfCategories, bool>>> SearchPredicate =>
        query => x => x.Title.Contains(query);

    protected override Func<string, Expression<Func<CategoryOfCategories, bool>>> TypeaheadPredicate =>
        query => x => x.Title.StartsWith(query);

    protected override IReadOnlyDictionary<string, Expression<Func<CategoryOfCategories, object?>>> SortingConfiguration { get; } =
        new Dictionary<string, Expression<Func<CategoryOfCategories, object?>>>
        {
            [nameof(CategoryOfCategories.Id)] = x => x.Id,
            [nameof(CategoryOfCategories.Title)] = x => x.Title
        };

    protected override async Task<IQueryable<CategoryOfCategories>> IncludeOwnedPropertiesAsync(IQueryable<CategoryOfCategories> query,
        CancellationToken token = default)
    {
        query = await base.IncludeOwnedPropertiesAsync(query, token);
        return query;
    }


    protected override async Task<IQueryable<CategoryOfCategories>> ApplyFilteringAsync(IQueryable<CategoryOfCategories> query,
        CategoryOfCategoriesQueryParams? request, CancellationToken token = default)
    {
        if (request is null) return query;

        query = await base.ApplyFilteringAsync(query, request, token);

        return query;
    }
}