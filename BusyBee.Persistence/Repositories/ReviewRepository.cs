using System.Linq.Expressions;
using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Models.City;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Review;
using BusyBee.Persistence.Repositories.CrudBase;

namespace BusyBee.Persistence.Repositories;

public class ReviewRepository : UnitOfWorkEntityRepositoryBase<Review, Guid, DatabaseContext, ListItem<Guid>, ReviewQueryParams>,
    IReviewRepository
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ReviewRepository" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    public ReviewRepository(DatabaseContext context, RepositoryCommonDependencies dependencies)
        : base(context, dependencies)
    {
    }

    protected override Func<string, Expression<Func<Review, bool>>> SearchPredicate =>
        query => x => x.Text.Contains(query);

    protected override Func<string, Expression<Func<Review, bool>>> TypeaheadPredicate =>
        query => x => x.Text.StartsWith(query);

    protected override IReadOnlyDictionary<string, Expression<Func<Review, object?>>> SortingConfiguration { get; } =
        new Dictionary<string, Expression<Func<Review, object?>>>
        {
            [nameof(Review.Id)] = x => x.Id,
            [nameof(Review.Text)] = x => x.Text
        };

    protected override async Task<IQueryable<Review>> ApplyFilteringAsync(IQueryable<Review> query,
        ReviewQueryParams? request, CancellationToken token = default)
    {
        if (request is null) return query;

        query = await base.ApplyFilteringAsync(query, request, token);

        return query;
    }
}