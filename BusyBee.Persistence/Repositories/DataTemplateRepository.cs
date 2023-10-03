using System.Linq.Expressions;
using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.DataTemplate;
using BusyBee.Persistence.Repositories.CrudBase;
using Microsoft.EntityFrameworkCore;

namespace BusyBee.Persistence.Repositories;

public class DataTemplateRepository :
    UnitOfWorkEntityRepositoryBase<DataTemplate, Guid, DatabaseContext, ListItem<Guid>, DataTemplateQueryParams>,
    IDataTemplateRepository
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryOfCategoriesRepository" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    public DataTemplateRepository(DatabaseContext context, RepositoryCommonDependencies dependencies)
        : base(context, dependencies)
    {
    }

    protected override Func<string, Expression<Func<DataTemplate, bool>>> SearchPredicate =>
        query => x => x.Id.ToString().Contains(query);

    protected override Func<string, Expression<Func<DataTemplate, bool>>> TypeaheadPredicate =>
        query => x => x.Id.ToString().StartsWith(query);

    protected override IReadOnlyDictionary<string, Expression<Func<DataTemplate, object?>>> SortingConfiguration { get; } =
        new Dictionary<string, Expression<Func<DataTemplate, object?>>>
        {
            [nameof(DataTemplate.Id)] = x => x.Id,
            [nameof(DataTemplate.EstimatedCost)] = x => x.EstimatedCost
        };

    protected override async Task<IQueryable<DataTemplate>> IncludeOwnedPropertiesAsync(IQueryable<DataTemplate> query,
        CancellationToken token = default)
    {
        query = await base.IncludeOwnedPropertiesAsync(query, token);

        query = query
            .Include(x => x.DataTemplateItems)
            .ThenInclude(x => x.DataTemplateAdditional);

        return query;
    }


    protected override async Task<IQueryable<DataTemplate>> ApplyFilteringAsync(IQueryable<DataTemplate> query,
        DataTemplateQueryParams? request, CancellationToken token = default)
    {
        if (request is null) return query;

        query = await base.ApplyFilteringAsync(query, request, token);

        return query;
    }
}