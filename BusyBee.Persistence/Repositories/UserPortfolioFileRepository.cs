using System.Linq.Expressions;
using BusyBee.Core.Entities;
using BusyBee.Core.Interfaces.Repositories;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.Task;
using BusyBee.Core.Models.User.UserPortfolioFile;
using BusyBee.Persistence.Repositories.CrudBase;

namespace BusyBee.Persistence.Repositories;

public class UserPortfolioFileRepository :
    UnitOfWorkEntityRepositoryBase<UserPortfolioFile, Guid, DatabaseContext, ListItem<Guid>, UserPortfolioFileQueryParams>,
    IUserPortfolioFileRepository
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserPortfolioFileRepository" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    public UserPortfolioFileRepository(DatabaseContext context, RepositoryCommonDependencies dependencies)
        : base(context, dependencies)
    {
    }

    protected override Func<string, Expression<Func<UserPortfolioFile, bool>>> SearchPredicate =>
        query => x => x.Id.ToString().Contains(query);

    protected override Func<string, Expression<Func<UserPortfolioFile, bool>>> TypeaheadPredicate =>
        query => x => x.Id.ToString().StartsWith(query);

    protected override IReadOnlyDictionary<string, Expression<Func<UserPortfolioFile, object?>>> SortingConfiguration { get; } =
        new Dictionary<string, Expression<Func<UserPortfolioFile, object?>>>
        {
            [nameof(User.Id)] = x => x.Id
        };

    protected override async Task<IQueryable<UserPortfolioFile>> ApplyFilteringAsync(IQueryable<UserPortfolioFile> query,
        UserPortfolioFileQueryParams? request, CancellationToken token = default)
    {
        if (request is null) return query;

        query = await base.ApplyFilteringAsync(query, request, token);

        return query;
    }
}