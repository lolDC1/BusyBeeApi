using System.Linq.Expressions;
using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Models.City;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Task;
using BusyBee.Persistence.Repositories.CrudBase;

namespace BusyBee.Persistence.Repositories;

public class CityRepository :
    UnitOfWorkEntityRepositoryBase<City, Guid, DatabaseContext, ListItem<Guid>, CityQueryParams>,
    ICityRepository
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CityRepository" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    public CityRepository(DatabaseContext context, RepositoryCommonDependencies dependencies)
        : base(context, dependencies)
    {
    }

    protected override Func<string, Expression<Func<City, bool>>> SearchPredicate =>
        query => x => x.Name.Contains(query);

    protected override Func<string, Expression<Func<City, bool>>> TypeaheadPredicate =>
        query => x => x.Name.StartsWith(query);

    protected override IReadOnlyDictionary<string, Expression<Func<City, object?>>> SortingConfiguration { get; } =
        new Dictionary<string, Expression<Func<City, object?>>>
        {
            [nameof(City.Id)] = x => x.Id,
            [nameof(City.Name)] = x => x.Name
        };

    protected override async Task<IQueryable<City>> ApplyFilteringAsync(IQueryable<City> query,
        CityQueryParams? request, CancellationToken token = default)
    {
        if (request is null) return query;

        query = await base.ApplyFilteringAsync(query, request, token);

        return query;
    }
}